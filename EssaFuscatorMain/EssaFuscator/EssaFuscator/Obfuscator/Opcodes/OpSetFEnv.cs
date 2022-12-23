using EssaFuscator.Bytecode_Library.Bytecode;
using EssaFuscator.Bytecode_Library.IR;

namespace EssaFuscator.Obfuscator.Opcodes
{
	public class OpSetFEnv : VOpcode
	{
		public override bool IsInstruction(Instruction instruction) =>
			instruction.OpCode == Opcode.SetFenv;

		public override string GetObfuscated(ObfuscationContext context) =>
			"Env = Stk[Inst[OP_A]]";
	}
}