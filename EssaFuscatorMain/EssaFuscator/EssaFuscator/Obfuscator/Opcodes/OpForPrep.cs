using EssaFuscator.Bytecode_Library.Bytecode;
using EssaFuscator.Bytecode_Library.IR;

namespace EssaFuscator.Obfuscator.Opcodes
{
	public class OpForPrep : VOpcode
	{
		public override bool IsInstruction(Instruction instruction) =>
			instruction.OpCode == Opcode.ForPrep;

		public override string GetObfuscated(ObfuscationContext context) =>
			"local A=Inst[OP_A];Stk[A]=Stk[A]-Stk[A+2];InstrPoint=InstrPoint+Inst[OP_B];";
	}
}