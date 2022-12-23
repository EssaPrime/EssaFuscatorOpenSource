using EssaFuscator.Bytecode_Library.Bytecode;
using EssaFuscator.Bytecode_Library.IR;

namespace EssaFuscator.Obfuscator.Opcodes
{
    public class OpBNOT : VOpcode
    {
        public override bool IsInstruction(Instruction instruction) =>
            instruction.OpCode == Opcode.BNOT;

        public override string GetObfuscated(ObfuscationContext context) =>
            "Stk[Inst[OP_A]]=~Stk[Inst[OP_B]];";
    }
}