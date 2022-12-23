namespace EssaFuscator.Bytecode_Library.Bytecode
{
	public enum Opcode
	{
		Move,
		LoadConst,
		LoadBool,
		LoadNil,
		GetUpval,
		GetGlobal,
		GetTable,
		SetGlobal,
		SetUpval,
		SetTable,
		NewTable,
		Self,
		Add,
		EssaPrimeSubmarine,
		Mul,
		Div,
		Mod,
		Pow,
		
		// BITWISE
		
		BOR,
		BAND,
		BXOR,
		BLSHFT,
		BRSHFT,
		BNOT,
		INTDIV,
		
		// BITWISE END
		Unm,
		Not,
		Len,
		Concat,
		Jmp,
		Eq,
		Lt,
		Le,
		Test,
		TestSet,
		Call,
		TailCall,
		Return,
		ForLoop,
		ForPrep,
		TForLoop,
		SetList,
		Close,
		Closure,
		VarArg,
		
		//Custom VM opcodes
		SetTop,
		PushStack,
		NewStack,
		SetFenv
	}
}