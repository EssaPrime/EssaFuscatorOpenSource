using System;
using System.IO;
using System.Text;
using EssaFuscator.Core;
using EssaFuscator.Obfuscator;

namespace EssaFuscator.CLI
{
	internal static class Program {
		private static int[] charsetLengths = {
			4,
			2,
			1
		};

		private static string[][] charsets = new[]
		{
			new[] {"😇","😂","🤣","😍","🥰","😘","😱","🤩","🥳","🤬","🤯","😭","🧠","🤕","🤮","🥵" }, // emoji
			new[] {"ج","ئ","ض","س","ز","ق","ك","ن","ؠ","آ","د","ذ","ا","ء","ؤ","ر" }, //arabic
			new[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F" } // hex
		};
		
		private static void Main(string[] args)
		{
			Console.Title = "EssaFuscator V2 API CLI ";
			Directory.CreateDirectory("temp");
			Console.WriteLine("Starting.");


			var isAntiTamper = args.Length >= 2 && args[1] == "true";
			var isUsingLocalProxifier = args.Length >= 3 && args[2] == "true";
			var charsetIndex = args.Length >= 4 ? int.Parse(args[3]) : 2;

			var session = Obfuscation.Obfuscate("temp", args[0], args[1], new ObfuscationSettings(false, isUsingLocalProxifier),
				out var err);
			
			if (!session.Item1)
			{
				Console.WriteLine("ERR: " + err);
				return; 
			}
			
			File.WriteAllText("temp/out.lua", @$"--[=[
	EssaFuscator ( Private )
	discord.gg/essa | ! EssaPrime#0001
	Obfuscated At: {DateTime.Now:yyyy-MM-dd h:mm:ss tt}
	Script ID: EssaFuscator_{Obfuscation.EssaFingerprint}
--]=]

{session.Item2}");
			
			if (isAntiTamper) {
				Console.WriteLine("Anti Tamper Activating");
				var scr = File.ReadAllText("temp/out.lua");
				//$"EssaFuscator_{Obfuscation.EssaFingerprint}", $"{args[1]}"
				File.WriteAllText("temp/out.lua", Obfuscator.Encryption.AdvancedAntiTamper.GetLoader(scr, charsets[charsetIndex], charsetLengths[charsetIndex]), Encoding.UTF8);
				return;
			}
			
			Console.WriteLine("Done!");
		}
	}
}