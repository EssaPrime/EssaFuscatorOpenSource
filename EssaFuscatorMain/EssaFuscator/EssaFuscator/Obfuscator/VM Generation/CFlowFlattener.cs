using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EssaFuscator.Obfuscator.VM_Generation {
    public static class CFlowFlattener {
	    private static readonly Random Rng = new();

	    private static string SwapStatement(string left, string @operator, string right) {
			var shouldSwap = Rng.Next(1, 3) == 2;
			//System.Windows.Forms.MessageBox.Show(shouldSwap.ToString());
			if (shouldSwap) {
				@operator = @operator.Replace("<", "_TEMPORARY1").Replace(">", "<").Replace("_TEMPORARY1", ">");
				return right + " " + @operator + " " + left;
			}
			else {
				return left + " " + @operator + " " + right;
			}
		}

	    private static string GetStatement(string[] lines, int[] linePositions, int luaVer = 1) {
		    switch (linePositions.Length)
			{
				case 0:
					return "";
				case 1:
					return " " + lines[linePositions[0]] + " ";
				case 2:
				{
					var line1 = lines[linePositions[0]];
					var line2 = lines[linePositions[1]];

					var statement = "";
					var cflowType = Rng.Next(0, 6);
					var cflowModel = Rng.Next(0, 3);
					//cftype = 0;
					
					switch (luaVer)
					{
						case 0:
							switch (cflowModel) {
								case 0:
									statement = cflowType switch
									{
										0 => "if " + SwapStatement("Enum", ">", linePositions[0].ToString()) +
										     " then " + line2 + " else " + line1 + " end ",
										1 => "if " + SwapStatement("Enum", "==", linePositions[0].ToString()) +
										     " then " + line1 + " else " + line2 + " end ",
										2 => "if " + SwapStatement("Enum", "<", linePositions[1].ToString()) +
										     " then " + line1 + " else " + line2 + " end ",
										3 => "if " + SwapStatement("Enum", "==", linePositions[1].ToString()) +
										     " then " + line2 + " else " + line1 + " end ",
										4 => "if " + SwapStatement("Enum", "~=", linePositions[0].ToString()) +
										     " then " + line2 + " else " + line1 + " end ",
										5 => "if " + SwapStatement("Enum", "~=", linePositions[1].ToString()) +
										     " then " + line1 + " else " + line2 + " end ",
										_ => statement
									};
									break;
								case 1:
									cflowType = Rng.Next(0, 2);
									statement = cflowType switch
									{
										0 => "if " +
										     SwapStatement("Enum", (new[] {"~=", ">", ">="})[Rng.Next(0, 3)],
											     (linePositions[0] - Rng.Next(1, 5)).ToString()) + " then " +
										     @" repeat if " +
										     SwapStatement("Enum", (new[] {"<", "~="})[Rng.Next(0, 2)],
											     linePositions[1].ToString()) + " then " + line1 + " break; end; " + line2 +
										     " until true; " + " else " + (Rng.Next(0, 2) == 1 ? line1 : line2) + " end ",
										1 => "if " +
										     SwapStatement("Enum", (new[] {"~=", ">", ">="})[Rng.Next(0, 3)],
											     (linePositions[0] - Rng.Next(1, 5)).ToString()) + " then " +
										     @" repeat if " +
										     SwapStatement("Enum", (new[] {">", "~="})[Rng.Next(0, 2)],
											     linePositions[0].ToString()) + " then " + line2 + " break; end; " + line1 +
										     " until true; " + " else " + (Rng.Next(0, 2) == 1 ? line1 : line2) + " end ",
										_ => statement
									};
									break;

								case 2:
									cflowType = Rng.Next(0, 2);
									statement = cflowType switch
									{
										0 => "if " +
										     SwapStatement("Enum", (new[] {"~=", ">", ">="})[Rng.Next(0, 3)],
											     (linePositions[0] - Rng.Next(1, 5)).ToString()) + " then " +
										     @" for i=" + Rng.Next(10, 50) + ", " + Rng.Next(52, 99) + " do if " +
										     SwapStatement("Enum", (new[] {"<", "~="})[Rng.Next(0, 2)],
											     linePositions[1].ToString()) + " then " + line1 + " break; end; " +
										     line2 + " break; end; " + " else " +
										     (Rng.Next(0, 2) == 1 ? line1 : line2) + " end ",
										1 => "if " +
										     SwapStatement("Enum", (new[] {"~=", ">", ">="})[Rng.Next(0, 3)],
											     (linePositions[0] - Rng.Next(1, 5)).ToString()) + " then " +
										     @" for i=" + Rng.Next(10, 50) + ", " + Rng.Next(52, 99) + " do if " +
										     SwapStatement("Enum", (new[] {">", "~="})[Rng.Next(0, 2)],
											     linePositions[0].ToString()) + " then " + line2 + " break; end; " +
										     line1 + " break; end; " + " else " +
										     (Rng.Next(0, 2) == 1 ? line1 : line2) + " end ",
										_ => statement
									};
									break;

							}

							break;
						case 1:
							cflowModel = Rng.Next(0, 2);
							switch (cflowModel) {
								case 0:
									statement = cflowType switch
									{
										0 => "if " + SwapStatement("Enum", ">", linePositions[0].ToString()) +
										     " then " + line2 + " else " + line1 + " end ",
										1 => "if " + SwapStatement("Enum", "==", linePositions[0].ToString()) +
										     " then " + line1 + " else " + line2 + " end ",
										2 => "if " + SwapStatement("Enum", "<", linePositions[1].ToString()) +
										     " then " + line1 + " else " + line2 + " end ",
										3 => "if " + SwapStatement("Enum", "==", linePositions[1].ToString()) +
										     " then " + line2 + " else " + line1 + " end ",
										4 => "if " + SwapStatement("Enum", "~=", linePositions[0].ToString()) +
										     " then " + line2 + " else " + line1 + " end ",
										5 => "if " + SwapStatement("Enum", "~=", linePositions[1].ToString()) +
										     " then " + line1 + " else " + line2 + " end ",
										_ => statement
									};
									break;
								case 1:
									var labelName = GetRandom(8);
									cflowType = Rng.Next(0, 2);
									statement = cflowType switch
									{
										0 => "if " +
										     SwapStatement("Enum", (new[] {"~=", ">", ">="})[Rng.Next(0, 3)],
											     (linePositions[0] - Rng.Next(1, 5)).ToString()) + " then " + @" if " +
										     SwapStatement("Enum", (new[] {"<", "~="})[Rng.Next(0, 2)],
											     linePositions[1].ToString()) + " then " + line1 + " gotostatement__" +
										     labelName + "(GOTOCALL); end " + line2 + " " + " ::" + labelName +
										     ":: else " + (Rng.Next(0, 2) == 1 ? line1 : line2) + " end ",
										1 => "if " +
										     SwapStatement("Enum", (new[] {"~=", ">", ">="})[Rng.Next(0, 3)],
											     (linePositions[0] - Rng.Next(1, 5)).ToString()) + " then " + @" if " +
										     SwapStatement("Enum", (new[] {">", "~="})[Rng.Next(0, 2)],
											     linePositions[0].ToString()) + " then " + line2 + " gotostatement__" +
										     labelName + "(GOTOCALL); end; " + line1 + " ::" + labelName + ":: else " +
										     (Rng.Next(0, 2) == 1 ? line1 : line2) + " end ",
										_ => statement
									};
									break;

						

							}

							break;
					}

					return statement;
				}
				case 3:
					break;
			}


			var middle = linePositions.Length / 2;
			var rest = linePositions.Length - middle;

			var smaller = linePositions.Take(middle).ToArray();
			var bigger = linePositions.Skip(middle).Take(rest).ToArray();

			var str = "";
			var cflowType2 = Rng.Next(0, 4);
			//cftype2 = 2;
			str = cflowType2 switch
			{
				0 => " if " + SwapStatement("Enum", "<=", smaller[^1].ToString()) + " then " +
				     GetStatement(lines, smaller, luaVer) + " else " + GetStatement(lines, bigger, luaVer) + " end ",
				1 => " if " + SwapStatement("Enum", "<", (smaller[^1] + 1).ToString()) + " then " +
				     GetStatement(lines, smaller, luaVer) + " else " + GetStatement(lines, bigger, luaVer) + " end ",
				2 => " if " + SwapStatement("Enum", ">", (smaller[^1]).ToString()) + " then " +
				     GetStatement(lines, bigger, luaVer) + " else " + GetStatement(lines, smaller, luaVer) + " end ",
				3 => " if " + SwapStatement("Enum", ">=", (smaller[^1] + 1).ToString()) + " then " +
				     GetStatement(lines, bigger, luaVer) + " else " + GetStatement(lines, smaller, luaVer) + " end ",
				_ => str
			};
			
			return str;
	    }

	    private static readonly Random NonRepeatingRng = new();
	    private static readonly List<string> TakenRandoms = new();

		private static string GetRandom(int len = 8, bool isAlphanumeric = true) {
			var ret = "";
			const string ldb = "abcdefghijklmnoprstuvyzqwxABCDEFGHJKLMOPRITSUVYZQWX_";

			for (var i = 0; i < len; i++) {
				ret += isAlphanumeric ? (ldb[NonRepeatingRng.Next(0, ldb.Length)].ToString()) : "\\" + NonRepeatingRng.Next(0, 256);

			}
			
			if (TakenRandoms.IndexOf(ret) != -1) {
				ret = GetRandom(len, isAlphanumeric);
			}
			TakenRandoms.Add(ret);
			return ret;
		}
		
		public static string Generate(string[] lines, int luaVer = 1) => GetStatement(lines, Enumerable.Range(0, lines.Length).ToArray(), luaVer);
    }
}
