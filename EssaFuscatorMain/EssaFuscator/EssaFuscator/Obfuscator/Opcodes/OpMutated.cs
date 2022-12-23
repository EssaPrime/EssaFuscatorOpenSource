using System;
using System.Collections.Generic;
using System.Linq;
using EssaFuscator.Bytecode_Library.IR;

namespace EssaFuscator.Obfuscator.Opcodes
{
	public class OpMutated : VOpcode
	{
		public static Random rand = new Random();
		
		public VOpcode Mutated;
		public int[] Registers;

		public static string[] RegisterReplacements = {"OP__A", "OP__B", "OP__C"};
		
		public override bool IsInstruction(Instruction instruction) =>
			false;

		public bool CheckInstruction() =>
			rand.Next(1, 15) == 1;	
		
		public override string GetObfuscated(ObfuscationContext context)
		{
			return Mutated.GetObfuscated(context);
		}

		public override void Mutate(Instruction instruction)
		{
			Mutated.Mutate(instruction);
		}
	}
}