// ReSharper disable All
namespace EssaFuscator.Bytecode_Library.IR
{
	public enum ConstantType
	{
		Nil,
		Boolean,
		Number,
		String
	}
	
	public enum InstructionType
	{
		ABC,
		ABx,
		AsBx,
		AsBxC,
		sAxBC,
		Data
	}
}