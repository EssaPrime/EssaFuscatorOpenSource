using EssaFuscator.Bytecode_Library.Bytecode;
using EssaFuscator.Bytecode_Library.IR;

namespace EssaFuscator.Obfuscator.Opcodes
{
	public class OpNewTableB0 : VOpcode
	{
		public override bool IsInstruction(Instruction instruction) =>
			instruction.OpCode == Opcode.NewTable && instruction.B == 0;

		public override string GetObfuscated(ObfuscationContext context) =>
			"Stk[Inst[OP_A]]={};";
	}
	
	public class OpNewTableB5000 : VOpcode
	{
		public override bool IsInstruction(Instruction instruction) =>
			instruction.OpCode == Opcode.NewTable && instruction.B > 5000;

		public override string GetObfuscated(ObfuscationContext context) =>
			"Stk[Inst[OP_A]]={};";
	}
	
	public class OpNewTableBElse : VOpcode
	{
		public override bool IsInstruction(Instruction instruction) =>
			instruction.OpCode == Opcode.NewTable && instruction.B > 0 && instruction.B <= 5000;

		public override string GetObfuscated(ObfuscationContext context) =>	
			"Stk[Inst[OP_A]]={table.unpack({}, 1, Inst[OP_B])};";
	}
}