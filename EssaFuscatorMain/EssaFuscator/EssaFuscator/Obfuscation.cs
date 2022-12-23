using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using EssaFuscator.Bytecode_Library.Bytecode;
using EssaFuscator.Bytecode_Library.IR;
using EssaFuscator.Obfuscator;
using EssaFuscator.Obfuscator.Control_Flow;
using EssaFuscator.Obfuscator.Encryption;
using EssaFuscator.Obfuscator.VM_Generation;

using System.Text.RegularExpressions;
using EssaFuscator.Obfuscator.Rewriters;
using Loretta.CodeAnalysis;
using Loretta.CodeAnalysis.Lua;
using Loretta.CodeAnalysis.Lua.Experimental;
using LuaCompiler_Test;

using Loretta.CodeAnalysis.Lua.Experimental.Minifying;
using Loretta.CodeAnalysis.Lua.Syntax;


namespace EssaFuscator.Core
{
	public static class Obfuscation
	{
		public static Random Random = new();
		private static Encoding _fuckingLua = Encoding.GetEncoding(28591);
		private static Random _random = new();

        /// <summary>
        ///  Can't be fucked to implement this right now
        /// </summary>
        /// <returns>Empty Dictionary(string, 2)</returns>
        private static Dictionary<string, bool> GetFFlags()
        {
	        return new Dictionary<string, bool>();
        }
        
        private static string RandomString()
		{
			const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
			var stringChars = new char[8];
			var random = new Random();

			for (var i = 0; i < stringChars.Length; i++)
				stringChars[i] = chars[random.Next(chars.Length)];

			return new string(stringChars);
		}
        
		public static readonly string EssaFingerprint = $"{RandomString()}";
		public static (bool, string) Obfuscate(string path, string input,string watermark, ObfuscationSettings settings, out string error)
		{
			var source = File.Exists(input) ? File.ReadAllText(input) : input;
			
			try
			{
				Console.WriteLine("Obfuscating...");

				var sourceTree = LuaSyntaxTree.ParseText(source, new LuaParseOptions(LuaSyntaxOptions.Lua53));
				source = sourceTree.WithRootAndOptions(new LuaIntegerSolver().Visit(sourceTree.GetRoot()), new LuaParseOptions(LuaSyntaxOptions.Lua53)).GetRoot().ToFullString();
				
				var headChunk = new Deserializer(LuaCompiler.Compile(source)).DecodeFile();
				var context = new ObfuscationContext(headChunk);
                var vm = new Generator(context).GenerateVM(settings);
                var syntaxTree = LuaSyntaxTree.ParseText(vm, options: new LuaParseOptions(LuaSyntaxOptions.All), path: path);

                var nodey = syntaxTree;

                File.WriteAllText("failedfile.lua", nodey.GetRoot().NormalizeWhitespace().ToFullString());

                if (settings.PaidVersion)
                {
	                Console.WriteLine("proxifying");
	                nodey = nodey.WithRootAndOptions(new LocalProfixier().Visit(nodey.GetRoot()), nodey.Options);
                }
                
                nodey = nodey.Minify();


                var minifiedVm = nodey.GetRoot().ToFullString();
                
                File.WriteAllText("temp/out.lua", minifiedVm);
                
                error = "Fine";

                return (true, minifiedVm);
			}
			catch (Exception e)
			{
				Console.WriteLine("ERROR");
				Console.WriteLine(e);

				error = e.ToString();
				return (false, "error");
			}

			return (false, "passed return");
		}
	}
}