using EssaFuscator.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EssaFuscator.Core;

namespace EssaFuscator.Obfuscator.Encryption
{
    public static class AdvancedAntiTamper
    {
        private static readonly Random Rng = new();

        private const int OffsetDefault = 2677 + 8;

        private static string ToDecimals(string s)
        {
            return s.Aggregate("", (current, t) => current + ("\\" + (byte) (t)));
        }

        public static string SaveArabic(string s)
        {
            var bytes = Encoding.UTF8.GetBytes(s);
            var cleanedString = bytes.Aggregate("", (current, b) => current + ("\\" + b));


            return cleanedString;
        }

        private static string GenerateChunkLen(int offset)
        {
            Console.WriteLine("ADV3");
            var s = offset.ToString();
            var pad = new string(' ', 12 - s.Length);
            return ToDecimals(s) + pad;
        }

        public static string GetLoader(/*string localName, string watermarkData,*/ string rawScript, string[] charset, int byteLen)
        {
            Console.WriteLine("ADV4");
            const int keySize = 16;
            var offset = OffsetDefault;

            string localName = "_";
            string watermarkData = "__";
            offset += localName.Length;
            offset += watermarkData.Length;
            
            var scriptEncoded = "\\" + byteLen + " " + string.Join("", charset);
            var scriptLengthEncoded = 2 + (byteLen * 16);
            var decryptionArray = "";
            var decArr = new List<int>() { };
            for (var i = 0; i < keySize; i++)
            {
                var val = Rng.Next(10, 200);
                decryptionArray += "\\" + val;
                decArr.Add(val);
            }

            var offsetDiff = Rng.Next(30, 500);
            var sb = new StringBuilder();
            rawScript = "dumptostring" + rawScript;
            for (var i = 0; i < rawScript.Length; i++)
            {
                int val = (byte) rawScript[i];
                val += decArr[i % keySize] + offsetDiff;
                val %= 256;
                var s = val % 16;
                var f = (val - s) / 16;

                scriptLengthEncoded += byteLen * 2;
                sb.Append(charset[f] + "" + charset[s]);
            }

            scriptEncoded += sb.ToString();

            offset += scriptLengthEncoded;
            var offsetPadded = GenerateChunkLen(offset + offsetDiff);

            return @$"--[=[
	EssaFuscator ( 2.8.A | Premium )
	discord.gg/obfuscate | essafuscator.net
	Obfuscated At: {DateTime.Now:yyyy-MM-dd h:mm:ss tt}
	Script ID: EssaFuscator_{Obfuscation.EssaFingerprint}
--]=]

local " + localName + @" = """ + watermarkData + @"""

local d = {} local dKy = '" + decryptionArray +
                   @"' for i=1,#dKy do d[i-1] = string.byte(dKy:sub(i,i)) end local f = """ + scriptEncoded +
                   @""" local c = string.dump(debug.getinfo(1).func) local j = {string.find(c, ""\108\117\97\46\43"")} local z = (j[2] - j[1]) - tonumber(""" +
                   offsetPadded +
                   @""") local eSt = load([[return '']])(); local e = eSt local w = e local Q = w local eX = {} local nL = false for i = 0, 255 do eX[i] = string.char(i) eX[eX[i]] = i end local o = #{0x192} local x = #{} local nSzE = 1 local nDxi = 1 local function rNtX() local rC = f:sub(nDxi, nDxi + (nSzE - 1)) nDxi = nDxi + nSzE return rC end nSzE = string.byte(rNtX()) nDxi = nDxi + 1 local cHs = {} for i = 1, 16 do cHs[rNtX()] = i - 1 end local nGT = {} local xTL = (#f - 1 - (16) * nSzE) / nSzE / 2 for i = 1, xTL do local P = eX[(((cHs[rNtX()]*16+cHs[rNtX()]) + 4096 - (-z + d[x])) % 256)] if o == #{} then  table.insert(nGT, P) elseif o == #{31} then Q = Q .. P else w = w .. P end if P == ""g"" then o = #{} elseif P == ""p"" and (not nL) then o = #{31, 31} nL = true end x = (x + 1) % 16 end if (pcall((eSt)[Q], load)) then while (eSt) do end end local jj jj = function(o) return o(jj) end local pS = function(...) return jj(jj) end local m = _ENV[w] _ENV[w] = pS local ze = load(table.concat(nGT)) _ENV[w] = m ze{}";
        }
    }
}