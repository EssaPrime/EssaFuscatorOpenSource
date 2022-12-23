namespace EssaFuscator.Obfuscator
{
	public record struct ObfuscationSettings(bool AntiTamper = false, bool PaidVersion = false)
	{
		public bool EncryptStrings = false;
		public bool EncryptImportantStrings = true;
		public bool BytecodeCompress = true;
		public int DecryptTableLen = 500;
		public bool PreserveLineInfo = true;
		public bool Mutate = true;
		public bool SuperOperators = true;
		public int MaxMiniSuperOperators = 100;
		public int MaxMegaSuperOperators = 50;
		public int MaxMutations = 150;
		public bool AntiTamper = AntiTamper;
		public bool PaidVersion = PaidVersion;
	}
}