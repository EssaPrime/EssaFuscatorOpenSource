using EssaFuscator.Bytecode_Library.Bytecode;
using EssaFuscator.Bytecode_Library.IR;

namespace EssaFuscator.Obfuscator.Opcodes
{
	public class OpMove : VOpcode
	{
		public override bool IsInstruction(Instruction instruction) =>
			instruction.OpCode == Opcode.Move;

		public override string GetObfuscated(ObfuscationContext context) =>
			"Stk[Inst[OP_A]]=Stk[Inst[OP_B]];";
	}
}