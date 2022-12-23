using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace EssaFuscator.Obfuscator.Encryption
{
    public class Decryptor
    {
        private int[] Table;
        private readonly string Name;

        public string Encrypt(byte[] bytes)
        {
            var L = Table.Length;

            var encrypted = bytes.Select((t, index) => (byte) (t ^ Table[index % L])).ToList();

            return
                $"((function(b)IB_INLINING_START(true);local function xor(b,c)IB_INLINING_START(true);local d,e=1,0;while b>0 and c>0 do local f,g=b%2,c%2;if f~=g then e=e+d end;b,c,d=(b-f)/2,(c-g)/2,d*2 end;if b<c then b=c end;while b>0 do local f=b%2;if f>0 then e=e+d end;b,d=(b-f)/2,d*2 end;return e end;local c=\"\"local e=string.sub;local h=string.char;local t = {{}} for j=0, 255 do local x=h(j);t[j]=x;t[x]=j;end;local f=\"{string.Join("", Table.Select(t => "\\" + t.ToString()))}\" for g=1,#b do local x=(g-1) % {Table.Length}+1 c=c..t[xor(t[e(b,g,g)],t[e(f, x, x)])];end;return c;end)(\"{string.Join("", encrypted.Select(t => "\\" + t.ToString()))}\"))";
        }

        public Decryptor(string name, int maxLen)
        {
            var r = new Random();

            Name = name;
            Table = Enumerable.Repeat(0, maxLen).Select(i => r.Next(0, 256)).ToArray();
        }
    }

    public class ConstantEncryption
    {
        private string _src;
        private ObfuscationSettings _settings;
        private Encoding _fuckingLua = Encoding.GetEncoding(28591);

        private Decryptor GenerateGenericDecryptor(MatchCollection matches)
        {
            var len = 0;

            for (var i = 0; i < matches.Count; i++)
            {
                var l = matches[i].Length;
                if (l > len)
                    len = l;
            }

            if (len > _settings.DecryptTableLen)
                len = _settings.DecryptTableLen;

            return new Decryptor("EssaFuscator_STR_DEC_GENERIC", len);
        }

        private static byte[] UnescapeLuaString(string str)
        {
            var bytes = new List<byte>();

            var i = 0;
            while (i < str.Length)
            {
                var cur = str[i++];
                if (cur == '\\')
                {
                    var next = str[i++];

                    switch (next)
                    {
                        case 'a':
                            bytes.Add((byte) '\a');
                            break;

                        case 'b':
                            bytes.Add((byte) '\b');
                            break;

                        case 'f':
                            bytes.Add((byte) '\f');
                            break;

                        case 'n':
                            bytes.Add((byte) '\n');
                            break;

                        case 'r':
                            bytes.Add((byte) '\r');
                            break;

                        case 't':
                            bytes.Add((byte) '\t');
                            break;

                        case 'v':
                            bytes.Add((byte) '\v');
                            break;

                        default:
                        {
                            if (!char.IsDigit(next))
                                bytes.Add((byte) next);
                            else // \001, \55h, etc
                            {
                                var s = next.ToString();
                                for (var j = 0; j < 2; j++, i++)
                                {
                                    if (i == str.Length)
                                        break;

                                    var n = str[i];
                                    if (char.IsDigit(n))
                                        s = s + n;
                                    else
                                        break;
                                }

                                bytes.Add((byte) int.Parse(s));
                            }

                            break;
                        }
                    }
                }
                else bytes.Add((byte) cur);
            }

            return bytes.ToArray();
        }

        /* NOTE TO USE LORETTA HERE */
        public string EncryptStrings()
        {
            const string encRegex = @"(['""])?(?(1)((?:[^\\]|\\.)*?)\1|\[(=*)\[(.*?)\]\3\])";

            if (_settings.EncryptStrings)
            {
                var r = new Regex(encRegex, RegexOptions.Singleline | RegexOptions.Compiled);

                var indDiff = 0;
                var matches = r.Matches(_src);

                var dec = GenerateGenericDecryptor(matches);

                foreach (Match m in matches)
                {
                    var before = _src.Substring(0, m.Index + indDiff);

                    var after = _src.Substring(m.Index + indDiff + m.Length);

                    var captured = AdvancedAntiTamper.SaveArabic(m.Groups[2].Value + m.Groups[4].Value);

                    if (captured.StartsWith("[STR_ENCRYPT]"))
                        captured = captured.Substring(13);
                    var nStr = before + dec.Encrypt(m.Groups[2].Value != ""
                        ? UnescapeLuaString(captured)
                        : _fuckingLua.GetBytes(captured));
                    nStr += after;
                    indDiff += nStr.Length - _src.Length;
                    _src = nStr;
                }
            }

            else
            {
                Console.WriteLine("Macro check");
                var r = new Regex(encRegex, RegexOptions.Singleline | RegexOptions.Compiled);
                var matches = r.Matches(_src);

                var indDiff = 0;
                var n = 0;

                foreach (Match m in matches)
                {
                    var captured = m.Groups[2].Value + m.Groups[4].Value;
                    var shouldEncrypt = true;
                    if (!captured.StartsWith("[STR_ENCRYPT]"))
                    {
                        shouldEncrypt = false;
                        captured = AdvancedAntiTamper.SaveArabic(captured);
                    }

                    //Console.WriteLine(captured);
                    if (shouldEncrypt)
                    {
                        captured = captured.Substring(13);
                        var dec = new Decryptor("EssaFuscator_STR_ENCRYPT" + n++, m.Length);

                        var before = _src.Substring(0, m.Index + indDiff);
                        var after = _src.Substring(m.Index + indDiff + m.Length);

                        var nStr = before + dec.Encrypt(m.Groups[2].Value != ""
                            ? UnescapeLuaString(captured)
                            : _fuckingLua.GetBytes(captured));
                        nStr += after;
                        indDiff += nStr.Length - _src.Length;
                        _src = nStr;
                    }
                    else
                    {
                        var before = _src.Substring(0, m.Index + indDiff);
                        var after = _src.Substring(m.Index + indDiff + m.Length);

                        var nStr = before + "'" + captured + "'";
                        nStr += after;
                        indDiff += nStr.Length - _src.Length;
                        _src = nStr;
                    }
                }
            }

            if (_settings.EncryptImportantStrings)
            {
                var r = new Regex(encRegex, RegexOptions.Singleline | RegexOptions.Compiled);
                var matches = r.Matches(_src);

                var indDiff = 0;
                var n = 0;

                var sTerms = new List<string>()
                    {"http", "function", "metatable", "local", "discord", "webhook", "php", "lua"};

                foreach (Match m in matches)
                {
                    var captured = m.Groups[2].Value + m.Groups[4].Value;
                    if (captured.StartsWith("[STR_ENCRYPT]"))
                        captured = captured.Substring(13);

                    var cont = false;

                    foreach (var search in sTerms)
                    {
                        if (captured.ToLower().Contains(search.ToLower()))
                            cont = true;
                    }

                    if (!cont)
                        continue;

                    var dec = new Decryptor("EssaFuscator_STR_ENCRYPT_IMPORTANT" + n++, m.Length);

                    var before = _src.Substring(0, m.Index + indDiff);
                    var after = _src.Substring(m.Index + indDiff + m.Length);

                    var nStr = before + dec.Encrypt(m.Groups[2].Value != ""
                        ? UnescapeLuaString(captured)
                        : _fuckingLua.GetBytes(captured));

                    nStr += after;

                    indDiff += nStr.Length - _src.Length;
                    _src = nStr;
                }
            }

            return _src;
        }

        public ConstantEncryption(ObfuscationSettings settings, string source)
        {
            _settings = settings;
            _src = source;
        }
    }
}