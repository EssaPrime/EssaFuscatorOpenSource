using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using EssaFuscator.Bytecode_Library.Bytecode;
using EssaFuscator.Bytecode_Library.IR;
using EssaFuscator.Extensions;
using EssaFuscator.Obfuscator.Opcodes;

namespace EssaFuscator.Obfuscator.VM_Generation
{

	class Base91
	{

		private static readonly char[] enctab = new char[] {
			'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M',
			'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
			'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
			'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
			'0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '!', '#', '$',
			'%', '&', '(', ')', '*', '+', ',', '.', '/', ':', ';', '<', '=',
			'>', '?', '@', '[', ']', '^', '_', '`', '{', '|', '}', '~', '"'
		};

		public StringBuilder Encode(byte[] ib, int count = -1)
		{
			if (ib == null)
				throw new ArgumentNullException(nameof(ib));
			if (count > ib.Length)
				throw new ArgumentOutOfRangeException(nameof(count));

			if (count == -1)
				count = ib.Length;
			int ebq = 0, en = 0;
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < count; ++i)
			{
				ebq |= (ib[i] & 255) << en;
				en += 8;
				if (en > 13)
				{
					int ev = ebq & 8191;

					if (ev > 88)
					{
						ebq >>= 13;
						en -= 13;
					}
					else
					{
						ev = ebq & 16383;
						ebq >>= 14;
						en -= 14;
					}
					sb.Append(enctab[ev % 91]);
					sb.Append(enctab[ev / 91]);
				}
			}
			if (en > 0)
			{
				sb.Append(enctab[ebq % 91]);
				if (en > 7 || ebq > 90)
					sb.Append(enctab[ebq / 91]);
			}
			return sb;
		}
	}
	public class Generator
	{
		private ObfuscationContext _context;
		
		public Generator(ObfuscationContext context) =>
			_context = context;

		public bool IsUsed(Chunk chunk, VOpcode virt)
		{
			bool isUsed = false;
			foreach (Instruction ins in chunk.Instructions)
				if (virt.IsInstruction(ins))
				{
					if (!_context.InstructionMapping.ContainsKey(ins.OpCode))
						_context.InstructionMapping.Add(ins.OpCode, virt);

					ins.CustomData = new CustomInstructionData {Opcode = virt};
					isUsed = true;
				}

			foreach (Chunk sChunk in chunk.Functions)
				isUsed |= IsUsed(sChunk, virt);

			return isUsed;
		}

		public static List<int> Compress(byte[] uncompressed)
		{
			// build the dictionary
			Dictionary<string, int> dictionary = new Dictionary<string, int>();
			for (int i = 0; i < 256; i++)
				dictionary.Add(((char)i).ToString(), i);
 
			string    w          = string.Empty;
			List<int> compressed = new List<int>();
 
			foreach (byte b in uncompressed)
			{
				string wc = w + (char)b;
				if (dictionary.ContainsKey(wc))
					w = wc;
				
				else
				{
					// write w to output
					compressed.Add(dictionary[w]);
					// wc is a new sequence; add it to the dictionary
					dictionary.Add(wc, dictionary.Count);
					w = ((char) b).ToString();
				}
			}
 
			// write remaining output if necessary
			if (!string.IsNullOrEmpty(w))
				compressed.Add(dictionary[w]);
 
			return compressed;
		}



		public static string ToBase36(ulong value)
        {
            const string base36 = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var sb = new StringBuilder(13);
            do
            {
                sb.Insert(0, base36[(byte)(value % 36)]);
                value /= 36;
            } while (value != 0);
            return sb.ToString();
        }

		public static string CompressedToString(List<int> compressed)
		{
			StringBuilder sb = new StringBuilder();
			foreach (int i in compressed)
			{
				string n = ToBase36((ulong)i);
				
				sb.Append(ToBase36((ulong)n.Length));
				sb.Append(n);
			}

			return sb.ToString();
		}

		public List<OpMutated> GenerateMutations(List<VOpcode> opcodes)
		{
			Random r = new Random();
			List<OpMutated> mutated = new List<OpMutated>();

			foreach (VOpcode opc in opcodes)
			{
				if (opc is OpSuperOperator)
					continue;

				for (int i = 0; i < r.Next(35, 50); i++)
				{
					int[] rand = {0, 1, 2};
					rand.Shuffle();

					OpMutated mut = new OpMutated();

					mut.Registers = rand;
					mut.Mutated = opc;
						
					mutated.Add(mut);
				}
			}

			mutated.Shuffle();
			return mutated;
		}

		public void FoldMutations(List<OpMutated> mutations, HashSet<OpMutated> used, Chunk chunk)
		{
			bool[] skip = new bool[chunk.Instructions.Count + 1];
			
			for (int i = 0; i < chunk.Instructions.Count; i++)
			{
				Instruction opc = chunk.Instructions[i];

				switch (opc.OpCode)
				{
					case Opcode.Closure:
						for (int j = 1; j <= ((Chunk) opc.RefOperands[0]).UpvalueCount; j++)
							skip[i + j] = true;

						break;
				}
			}
			
			for (int i = 0; i < chunk.Instructions.Count; i++)
			{
				if (skip[i])
					continue;
				
				Instruction opc = chunk.Instructions[i];
				CustomInstructionData data = opc.CustomData;
				
				foreach (OpMutated mut in mutations)
					if (data.Opcode == mut.Mutated && data.WrittenOpcode == null)
					{
						if (!used.Contains(mut))
							used.Add(mut);

						data.Opcode = mut;
						break;
					}
			}
			
			foreach (Chunk _c in chunk.Functions)
				FoldMutations(mutations, used, _c);
		}

		public List<OpSuperOperator> GenerateSuperOperators(Chunk chunk, int maxSize, int minSize = 5)
		{
			List<OpSuperOperator> results = new List<OpSuperOperator>();
			Random                r       = new Random();

			bool[] skip = new bool[chunk.Instructions.Count + 1];

			for (int i = 0; i < chunk.Instructions.Count - 1; i++)
			{
				switch (chunk.Instructions[i].OpCode)
				{
					case Opcode.Closure:
					{
						skip[i] = true;
						for (int j = 0; j < ((Chunk) chunk.Instructions[i].RefOperands[0]).UpvalueCount; j++)
							skip[i + j + 1] = true;
							
						break;
					}

					case Opcode.Eq:
					case Opcode.Lt:
					case Opcode.Le:
					case Opcode.Test:
					case Opcode.TestSet:
					case Opcode.TForLoop:
					case Opcode.SetList:
					case Opcode.LoadBool when chunk.Instructions[i].C != 0:
						skip[i + 1] = true;
						break;

					case Opcode.ForLoop:
					case Opcode.ForPrep:
					case Opcode.Jmp:
						chunk.Instructions[i].UpdateRegisters();
						
						skip[i + 1] = true;
						skip[i + chunk.Instructions[i].B + 1] = true;
						break;
				}
				
				if (chunk.Instructions[i].CustomData.WrittenOpcode is OpSuperOperator su && su.SubOpcodes != null)
					for (int j = 0; j < su.SubOpcodes.Length; j++)
						skip[i + j] = true;
			}
			
			int c = 0;
			while (c < chunk.Instructions.Count)
			{
				int targetCount = maxSize;
				OpSuperOperator superOperator = new OpSuperOperator {SubOpcodes = new VOpcode[targetCount]};

				bool d     = true;
				int cutoff = targetCount;

				for (int j = 0; j < targetCount; j++)
					if (c + j > chunk.Instructions.Count - 1 || skip[c + j])
					{
						cutoff = j; 
						d = false;
						break;
					}

				if (!d)
				{
					if (cutoff < minSize)
					{
						c += cutoff + 1;	
						continue;
					}
						
					targetCount = cutoff;	
					superOperator = new OpSuperOperator {SubOpcodes = new VOpcode[targetCount]};
				}
				
				for (int j = 0; j < targetCount; j++)
					superOperator.SubOpcodes[j] =
						chunk.Instructions[c + j].CustomData.Opcode;

				results.Add(superOperator);
				c += targetCount + 1;
			}

			foreach (var _c in chunk.Functions)
				results.AddRange(GenerateSuperOperators(_c, maxSize));
			
			return results;
		}

		public void FoldAdditionalSuperOperators(Chunk chunk, List<OpSuperOperator> operators, ref int folded)
		{
			bool[] skip = new bool[chunk.Instructions.Count + 1];
			for (int i = 0; i < chunk.Instructions.Count - 1; i++)
			{
				switch (chunk.Instructions[i].OpCode)
				{
					case Opcode.Closure:
					{
						skip[i] = true;
						for (int j = 0; j < ((Chunk) chunk.Instructions[i].RefOperands[0]).UpvalueCount; j++)
							skip[i + j + 1] = true;
							
						break;
					}

					case Opcode.Eq:
					case Opcode.Lt:
					case Opcode.Le:
					case Opcode.Test:
					case Opcode.TestSet:
					case Opcode.TForLoop:
					case Opcode.SetList:
					case Opcode.LoadBool when chunk.Instructions[i].C != 0:
						skip[i + 1] = true;
						break;

					case Opcode.ForLoop:
					case Opcode.ForPrep:
					case Opcode.Jmp:
						chunk.Instructions[i].UpdateRegisters();
						skip[i + 1] = true;
						skip[i + chunk.Instructions[i].B + 1] = true;
						break;
				}
				
				if (chunk.Instructions[i].CustomData.WrittenOpcode is OpSuperOperator su && su.SubOpcodes != null)
					for (int j = 0; j < su.SubOpcodes.Length; j++)
						skip[i + j] = true;
			}
			
			int c = 0;
			while (c < chunk.Instructions.Count)
			{
				if (skip[c])
				{
					c++;
					continue;
				}

				bool used = false;

				foreach (OpSuperOperator op in operators)
				{
					int targetCount = op.SubOpcodes.Length;
					bool cu = true;
					for (int j = 0; j < targetCount; j++)
					{
						if (c + j > chunk.Instructions.Count - 1 || skip[c + j])
						{
							cu = false;
							break;
						}
					}

					if (!cu)
						continue;


					List<Instruction> taken = chunk.Instructions.Skip(c).Take(targetCount).ToList();
					if (op.IsInstruction(taken))
					{
						for (int j = 0; j < targetCount; j++)
						{
							skip[c + j] = true;
							chunk.Instructions[c + j].CustomData.WrittenOpcode = new OpSuperOperator {VIndex = 0};
						}

						chunk.Instructions[c].CustomData.WrittenOpcode = op;

						used = true;
						break;
					}
				}

				if (!used)
					c++;
				else
					folded++;
			}

			foreach (var _c in chunk.Functions)
				FoldAdditionalSuperOperators(_c, operators, ref folded);
		}

		public string GenerateVM(ObfuscationSettings settings)
		{
			Random r = new Random();

			List<VOpcode> virtuals = Assembly.GetExecutingAssembly().GetTypes()
			                                 .Where(t => t.IsSubclassOf(typeof(VOpcode)))
			                                 .Select(Activator.CreateInstance)
			                                 .Cast<VOpcode>()
			                                 .Where(t => IsUsed(_context.HeadChunk, t))
			                                 .ToList();

			
			if (settings.Mutate)
			{
				List<OpMutated> muts = GenerateMutations(virtuals).Take(settings.MaxMutations).ToList();
				
				Console.WriteLine("Created " + muts.Count + " mutations.");
				
				HashSet<OpMutated> used = new HashSet<OpMutated>();
				FoldMutations(muts, used, _context.HeadChunk);
				
				Console.WriteLine("Used " + used.Count + " mutations.");
				
				virtuals.AddRange(used);
			}
			
			if (settings.SuperOperators)
			{
				int folded = 0;
				
				var megaOperators = GenerateSuperOperators(_context.HeadChunk, 30, 10).OrderBy(t => r.Next())
					.Take(settings.MaxMegaSuperOperators).ToList();
				
				Console.WriteLine("Created " + megaOperators.Count + " mega super operators.");
				
				virtuals.AddRange(megaOperators);
				
				FoldAdditionalSuperOperators(_context.HeadChunk, megaOperators, ref folded);
				
				var miniOperators = GenerateSuperOperators(_context.HeadChunk, 5).OrderBy(t => r.Next())
					.Take(settings.MaxMiniSuperOperators).ToList();
				
				Console.WriteLine("Created " + miniOperators.Count + " mini super operators.");
				
				virtuals.AddRange(miniOperators);
				
				FoldAdditionalSuperOperators(_context.HeadChunk, miniOperators, ref folded);
				
				Console.WriteLine("Folded " + folded + " instructions into super operators.");
			}

			string Reverse(string text)
			{
				char[] cArray = text.ToCharArray();
				string reverse = String.Empty;
				for (int i = cArray.Length - 1; i > -1; i--)
				{
					reverse += cArray[i];
				}
				return reverse;
			}


			virtuals.Shuffle();
			
			for (int i = 0; i < virtuals.Count; i++)
				virtuals[i].VIndex = i;

			string vm = "";

			byte[] bs = new Serializer(_context, settings).SerializeLChunk(_context.HeadChunk);
				vm += @"
local __Select__ = select
local __Wrap__ = coroutine.wrap

local fJVmEp = (function(__Select__, __Wrap__, EssaPrimeBite,EssaPrimeCharcoal,EssaPrimeSubmarine,Concat,LDExp,Setmetatable,Select,Unpack,ToNumber,Reverser,DaddyPrimeIsEssaPrimeSTRINGG)
";

			if (settings.BytecodeCompress)
			{
				vm += @"

local function EssaFlipMe(t)
	local tt={}
	for i,v in pairs(t) do
		tt[v]=i
	end
	return tt
end

    local EssaPrimePaint={EssaPrimeCharcoal(0x42),EssaPrimeCharcoal(0x43),EssaPrimeCharcoal(0x44),EssaPrimeCharcoal(0x45),EssaPrimeCharcoal(0x46),EssaPrimeCharcoal(0x47),EssaPrimeCharcoal(0x48),EssaPrimeCharcoal(0x49),EssaPrimeCharcoal(0x4A),EssaPrimeCharcoal(0x4B),EssaPrimeCharcoal(0x4C),EssaPrimeCharcoal(0x4D),EssaPrimeCharcoal(0x4E),EssaPrimeCharcoal(0x4F),EssaPrimeCharcoal(0x50),EssaPrimeCharcoal(0x51),EssaPrimeCharcoal(0x52),EssaPrimeCharcoal(0x53),EssaPrimeCharcoal(0x54),EssaPrimeCharcoal(0x55),EssaPrimeCharcoal(0x56),EssaPrimeCharcoal(0x57),EssaPrimeCharcoal(0x58),EssaPrimeCharcoal(0x59),EssaPrimeCharcoal(0x5A),EssaPrimeCharcoal(0x61),EssaPrimeCharcoal(0x62),EssaPrimeCharcoal(0x63),EssaPrimeCharcoal(0x64),EssaPrimeCharcoal(0x65),EssaPrimeCharcoal(0x66),EssaPrimeCharcoal(0x67),EssaPrimeCharcoal(0x68),EssaPrimeCharcoal(0x69),EssaPrimeCharcoal(0x6A),EssaPrimeCharcoal(0x6B),EssaPrimeCharcoal(0x6C),EssaPrimeCharcoal(0x6D),EssaPrimeCharcoal(0x6E),EssaPrimeCharcoal(0x6F),EssaPrimeCharcoal(0x70),EssaPrimeCharcoal(0x71),EssaPrimeCharcoal(0x72),EssaPrimeCharcoal(0x73),EssaPrimeCharcoal(0x74),EssaPrimeCharcoal(0x75),EssaPrimeCharcoal(0x76),EssaPrimeCharcoal(0x77),EssaPrimeCharcoal(0x78),EssaPrimeCharcoal(0x79),EssaPrimeCharcoal(0x7A),EssaPrimeCharcoal(0x30),EssaPrimeCharcoal(0x31),EssaPrimeCharcoal(0x32),EssaPrimeCharcoal(0x33),EssaPrimeCharcoal(0x34),EssaPrimeCharcoal(0x35),EssaPrimeCharcoal(0x36),EssaPrimeCharcoal(0x37),EssaPrimeCharcoal(0x38),EssaPrimeCharcoal(0x39),EssaPrimeCharcoal(0x21),EssaPrimeCharcoal(0x23),EssaPrimeCharcoal(0x24),EssaPrimeCharcoal(0x25),EssaPrimeCharcoal(0x26),EssaPrimeCharcoal(0x28),EssaPrimeCharcoal(0x29),EssaPrimeCharcoal(0x2A),EssaPrimeCharcoal(0x2B),EssaPrimeCharcoal(0x2C),EssaPrimeCharcoal(0x2E),EssaPrimeCharcoal(0x2F),EssaPrimeCharcoal(0x3A),EssaPrimeCharcoal(0x3B),EssaPrimeCharcoal(0x3C),EssaPrimeCharcoal(0x3D),EssaPrimeCharcoal(0x3E),EssaPrimeCharcoal(0x3F),EssaPrimeCharcoal(0x40),EssaPrimeCharcoal(0x5B),EssaPrimeCharcoal(0x5D),EssaPrimeCharcoal(0x5E),EssaPrimeCharcoal(0x5F),EssaPrimeCharcoal(0x60),EssaPrimeCharcoal(0x7B),EssaPrimeCharcoal(0x7C),EssaPrimeCharcoal(0x7D),EssaPrimeCharcoal(0x7E),EssaPrimeCharcoal(0x22)}    
    EssaPrimePaint[0] = EssaPrimeCharcoal(65)

local EssaPrimeCoating = EssaFlipMe(EssaPrimePaint)

			
 local function DaddyPrime(b)
        local c, d, e, f, g = #b, -1, '', 0, 0
        for h in b:gmatch('.') do

			local i = EssaPrimeCoating[h]

			if not i then

			else
				if d < 0 then
					d = i

				else
					d = d + i * 91

					f = f | (d << g)

					if d & 8191 then
						g = g + 13

					else
					g = g + 14

					end

					while true do
						e = e..EssaPrimeCharcoal(f & 255)

						f = f >> 8

						g = g - 8

						if not(g > 7) then

							break

						end
					end

					d = -1

				end
			end

		end

		if d + 1 > 0 then
			e = e..string.char((f | (d << g) & 255))

		end
		local b = Reverser(e)

		local i, j, k = '', '', { }
				local l = 256

		local m = { }

		for n = 0, l - 1 do
						m[n] = EssaPrimeCharcoal(n)

		end

		local h = 1

		local function o()

			local c = ToNumber(EssaPrimeSubmarine(b, h, h), 36)

			h = h + 1

			local p = ToNumber(EssaPrimeSubmarine(b, h, h + c - 1), 36)

			h = h + c

			return p

		end
		i = EssaPrimeCharcoal(o())

		k[1] = i

		while h < #b do
            local g = o()

			if m[g] then
				j = m[g]

			else
					j = i..EssaPrimeSubmarine(i, 1, 1)

			end
			m[l] = i..EssaPrimeSubmarine(j, 1, 1)

			k[#k + 1], i, l = j, j, l + 1
        end

		return Concat(k)

	end ";
				
				vm += "local WasHere = DaddyPrime(DaddyPrimeIsEssaPrimeSTRINGG) \n";
			}
			else
			{
				vm += "WasHere='";

				StringBuilder sb = new StringBuilder();
				foreach (byte b in bs)
				{
					sb.Append('\\');
					sb.Append(b);
				}

				vm += sb + "';\n";
			}

			int maxConstants = 0;

			void ComputeConstants(Chunk c)
			{
				if (c.Constants.Count > maxConstants)
					maxConstants = c.Constants.Count;
				
				foreach (Chunk _c in c.Functions)
					ComputeConstants(_c);
			}
			
			ComputeConstants(_context.HeadChunk);
			Console.WriteLine(Environment.CurrentDirectory);
			vm += VMStrings.VMP0;
			vm += VMStrings.VMP1(_context.PrimaryXorKey, settings.AntiTamper);
			
			for (int i = 0; i < (int) ChunkStep.StepCount; i++)
			{
				switch (_context.ChunkSteps[i])
				{
					case ChunkStep.ParameterCount:
						vm += "Chunk[4] = Essa8Bits();";
						break;
					case ChunkStep.Constants:
						vm +=
							$@"

								local ConstCount = Essa32Bits()
    							local Consts = {{}};

								for Idx=1,ConstCount do 
									local Type=Essa8Bits();
									local Cons;
	
									if(Type=={_context.ConstantMapping[1]}) then Cons=(Essa8Bits() ~= 0);
									elseif(Type=={_context.ConstantMapping[2]}) then Cons = EssaPrimeWater(EssaPrimeBitCreator, Essa32Bits);
									elseif(Type=={_context.ConstantMapping[3]}) then Cons=EssaPrimeStrings();
									end;
									
									Consts[Idx]=Cons;
								end;
								Chunk[2] = Consts
								";
						break;
					case ChunkStep.Instructions:
						vm +=
							$@"for Idx=1,Essa32Bits() do 
									local Data1=(Essa32Bits() ~{_context.IXorKey1});
									local Data2=(Essa32Bits()~{_context.IXorKey2}); 

									local Type=EssaPrimeBitCreator(Data1,1,2);
									local Opco=EssaPrimeBitCreator(Data2,1,11);
									
									local Inst=
									{{
										Opco,
										EssaPrimeBitCreator(Data1,3,11),
										nil,
										nil,
										Data2
									}};

									if (Type == 0) then Inst[OP_B]=EssaPrimeBitCreator(Data1,12,20);Inst[OP_C]=EssaPrimeBitCreator(Data1,21,29);
									elseif(Type==1) then Inst[OP_B]=EssaPrimeBitCreator(Data2,12,33);
									elseif(Type==2) then Inst[OP_B]=EssaPrimeBitCreator(Data2,12,32)-1048575;
									elseif(Type==3) then Inst[OP_B]=EssaPrimeBitCreator(Data2,12,32)-1048575;Inst[OP_C]=EssaPrimeBitCreator(Data1,21,29);
									end;
									
									Instrs[Idx]=Inst;end;";
						break;
					case ChunkStep.Functions:
						vm += "for Idx=1,Essa32Bits() do Functions[Idx-1]=EssaDeserlizer();end;";
						break;
					case ChunkStep.LineInfo:
						if (settings.PreserveLineInfo)
							vm += "for Idx=1,Essa32Bits() do Lines[Idx]=Essa32Bits();end;";
						break;
				}
			}

			vm += "return Chunk;end;";
			vm += settings.PreserveLineInfo ? VMStrings.VMP2_LI : VMStrings.VMP2;

			int maxFunc = 0;

			void ComputeFuncs(Chunk c)
			{
				if (c.Functions.Count > maxFunc)
					maxFunc = c.Functions.Count;
				
				foreach (Chunk _c in c.Functions)
					ComputeFuncs(_c);
			}
			
			ComputeFuncs(_context.HeadChunk);
			
			vm = vm.Replace("FUNC_CNT", string.Join(",", Enumerable.Repeat(0, maxFunc).Select(x => "0")));

			int maxInstrs = 0;

			void ComputeInstrs(Chunk c)
			{
				if (c.Instructions.Count > maxInstrs)
					maxInstrs = c.Instructions.Count;
				
				foreach (Chunk _c in c.Functions)
					ComputeInstrs(_c);
			}
			
			ComputeInstrs(_context.HeadChunk);
			
			vm = vm.Replace("INSTR_CNT", "");
			
			string GetStr(List<int> opcodes)
			{
				string str = "";
				
				if (opcodes.Count == 1)
					str += $"{virtuals[opcodes[0]].GetObfuscated(_context)}";

				else if (opcodes.Count == 2) 
				{
					if (r.Next(2) == 0)
					{
						str +=
							$"if Enum > {virtuals[opcodes[0]].VIndex} then {virtuals[opcodes[1]].GetObfuscated(_context)}";
						str += $"else {virtuals[opcodes[0]].GetObfuscated(_context)}";
						str += "end;";
					}
					else
					{
						str +=
							$"if Enum == {virtuals[opcodes[0]].VIndex} then {virtuals[opcodes[0]].GetObfuscated(_context)}";
						str += $"else {virtuals[opcodes[1]].GetObfuscated(_context)}";
						str += "end;";
					}
				}
				else
				{
					List<int> ordered = opcodes.OrderBy(o => o).ToList();
					var sorted = new[] { ordered.Take(ordered.Count / 2).ToList(), ordered.Skip(ordered.Count / 2).ToList() };
					
					str += "if Enum <= " + sorted[0].Last() + " then ";
					str += GetStr(sorted[0]);
					str += " else";
					str += GetStr(sorted[1]);
				}

				return str;
			}

			List<string> opcodesArray = new List<string>();

			foreach(VOpcode v in virtuals) {
				opcodesArray.Add(v.GetObfuscated(_context));
            }
			
			vm += CFlowFlattener.Generate(opcodesArray.ToArray()).Replace("gotostatement__", "goto ").Replace("(GOTOCALL);", "; ");
			Base91 base91 = new Base91();
			vm += settings.PreserveLineInfo ? $@"
				InstrPoint	= InstrPoint + 1;
			end;
		end;
A, B = _R(PCall(Loop))
		if not A[1] then
			local line = Chunk[7][InstrPoint] or '?'
			error('EssaEF Error: ' .. line .. ', Check Your Source Code!:' .. A[2])
		else
			return Unpack(A, 2, B)
		end;
	end;
end
local essaprimewasdaddybuttooba = function() return _ENV end;
return EssaSubway(EssaDeserlizer(), {{}}, essaprimewasdaddybuttooba())();
end)
local death death = function() return death() end " + (settings.AntiTamper ? @"if type(({...})[1]) ~= type({}) then death() end" : "") + $@"

return fJVmEp(select, coroutine.wrap, string['byte'],string['char'],string['sub'],table['concat'],math['ldexp'],setmetatable,select,table.unpack,tonumber,string['reverse'],'{base91.Encode(Encoding.UTF8.GetBytes(Reverse(CompressedToString(Compress(bs)))))}'); 
"
:
$@"
				InstrPoint	= InstrPoint + 1;
			end;
		end;
	end;
essaprimewasdaddybuttooba = function() return _ENV end;
return EssaSubway(EssaDeserlizer(), {{}}, essaprimewasdaddybuttooba())();
end)
local death death = function() return death() end " + (settings.AntiTamper ? @"if type(({...})[1]) ~= type({}) then death() end" : "") + $@"
return fJVmEp(select, coroutine.wrap, string['byte'],string['char'],string['sub'],table['concat'],math['ldexp'],setmetatable,select,table.unpack,tonumber,string['reverse'],'{base91.Encode(Encoding.UTF8.GetBytes(Reverse(CompressedToString(Compress(bs)))))}')

" ;

			vm = vm.Replace("OP_ENUM", "1")
				.Replace("OP_A", "2")
				.Replace("OP_B", "3")
				.Replace("OP_BX", "4")
				.Replace("OP_C", "5")
				.Replace("OP_DATA", "6");

			
			return vm;
		}
	}
}