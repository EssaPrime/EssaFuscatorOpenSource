using System;
using System.Linq;
using System.Collections.Generic;
using MoonSharp.Interpreter;

namespace EssaFuscator.Obfuscator.VM_Generation
{
    // written by federal - 26.04.2021
    public static class AdvancedCFGenerator
    {
        public static MoonSharp.Interpreter.Script iptr = new Script(CoreModules.Preset_SoftSandbox);
        public static Random rnd = new Random();
        public static T[] Shuffle<T>(T[] array)
        {
            int n = array.Length;
            while (n > 1)
            {
                int k = rnd.Next(n--);
                T temp = array[n];
                array[n] = array[k];
                array[k] = temp;
            }
            return array;
        }


        public static string IntToHex(int n)
        {

            string hexValue = n.ToString("X");
            hexValue = hexValue.ToLower().Replace("-", "");
            return "0x" + hexValue;
        }
        public static class ForeskinConfusion
        { // created by big boy federal --> foreskin confusion because it uses 'for' loops and basically fuck you
            public class Opcode
            {
                public string GetOpcode(int recurses)
                {
                    recurses--;
                    if (recurses < 0)
                    {
                        post++;
                        if (post > debugletters.Length)
                        {
                            throw new Exception("debug letter index out of bounds. Reduce the recurse argument");
                        }
                        return " DEBUGDATA=DEBUGDATA..('" + debugletters[post - 1] + "') ";

                    }
                    string ret = "";
                    int type = 0;// rnd.Next(0,2);
                    if (type == 0)
                    {
                        int uptype = rnd.Next(0, 4);
                        int downtype = rnd.Next(0, 4);

                        if (recurses == 0)
                        {
                            uptype = 3;
                            downtype = 3; // skip over
                        }

                        int n = rnd.Next(100, 2000);
                        ret = @"
if ChangeINDX(" + IntToHex(rnd.Next(1000, 9999)) + @", " + IntToHex(rnd.Next(1000, 9999)) + @" + _LVAR, " + (IntToHex(n * 2)) + @") " + (new string[] { ">", "<", "<=", ">=" })[rnd.Next(0, 4)] + @" " + (IntToHex(n)) + @" then
" + (uptype == 0 ? GetOpcode(-1) : "") + @"
" + GetOpcode(recurses) + @"
" + (uptype == 1 ? GetOpcode(-1) : "") + @"
else
" + (downtype == 0 ? GetOpcode(-1) : "") + @"
" + GetOpcode(recurses) + @"
" + (downtype == 1 ? GetOpcode(-1) : "") + @"
end
";
                    }
                    return ret;
                }
                public int post { get; set; }
            }
            public static string debugletters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            public static string GetIndexFunction()
            {
                string ret = "";
                int aType = rnd.Next(0, 2);
                int ltType = rnd.Next(0, 2);
                int argType = rnd.Next(0, 2);

                ret = @"
local function ChangeINDX(" + (argType == 0 ? "a, b" : "b, a") + @", c)
    b = (_INDX + b) % 3
    _INDX = ((b ~= 0) and _INDX + ((" + (ltType == 0 ? "b < 2" : "1 == b") + @") and " + (aType == 0 ? "-a or a" : "a or -a") + @") or _INDX * a) % c
    return _INDX
end
";

                return ret;

            }
            public static string ConfuseChunks(string[] lines, string[] fakeLines)
            {
                bool canAddDebounce = false;
                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i].Contains("HASDONE"))
                    {
                        canAddDebounce = true;
                        break;
                    }
                }
                Opcode o = new Opcode();
                o.post = 0;
                string s = @"
local DEBUGDATA = ('');
local _INDX = 0;
" + (canAddDebounce ? "local HASDONE = 0;" : "") + @"
" + GetIndexFunction() + @"

for _LVAR=" + IntToHex(rnd.Next(0, 3)) + @", " + IntToHex(rnd.Next(25, 35)) + @" do 
" + o.GetOpcode(3) + @"
end

";

                string resp = iptr.DoString(s + "\nreturn DEBUGDATA").String;

                List<string> _lettersSerialized = new List<string>();
                List<string> _lettersUsed = new List<string>();

                for (int i = 0; i < resp.Length; i++)
                {
                    string c = resp[i].ToString();
                    if (!_lettersUsed.Contains(c))
                    {
                        _lettersUsed.Add(c);
                        _lettersSerialized.Add(c);
                    }
                }

                if (_lettersSerialized.Count < lines.Length)
                {

                    return ConfuseChunks(lines, fakeLines);
                }
                for (int i = 0; i < _lettersSerialized.Count; i++)
                {
                    if (i < lines.Length)
                    {
                        s = s.Replace("DEBUGDATA=DEBUGDATA..('" + _lettersSerialized[i] + "')", "\n" + lines[i] + "\n");
                    }
                    else
                    {
                        s = s.Replace("DEBUGDATA=DEBUGDATA..('" + _lettersSerialized[i] + "')", "");
                    }
                }
                int fakeOpcodeIdx = 0;
                for (int i = 0; i < debugletters.Length; i++)
                {
                    if (s.Contains("DEBUGDATA=DEBUGDATA..('" + debugletters[i] + "')") && fakeOpcodeIdx < fakeLines.Length)
                    {
                        s = s.Replace("DEBUGDATA=DEBUGDATA..('" + debugletters[i] + "')", fakeLines[fakeOpcodeIdx]);
                        fakeOpcodeIdx++;
                    }
                }

                return s.Replace("local DEBUGDATA = ('');", "");
            }

        }
        public static List<int> takenRandomNumbers = new List<int>();
        public static int GetRandomNumber(int min, int max) {
            int ret = 0;
            ret = _rnd.Next(min, max);


            if (takenRandomNumbers.IndexOf(ret) != -1) {
                ret = GetRandomNumber(min, max);
            }
            takenRandomNumbers.Add(ret);
            return ret;

        }
        public static Random _rnd = new Random();
        public static class LoopFuckifier
        {
            public class Opcode
            {
                public string GetOpcode()
                {
                    post++;
                    return @"
		local OP_IDX = " +  GetRandomNumber(111, 99999) + @"
        if not _USED[OP_IDX] then
            _USED[OP_IDX] = 0x1
            DEBUGDATA=DEBUGDATA..('" + debugletters[post - 1] + @"')
        end
";
                }
                public int post { get; set; }
            }
            public static string debugletters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            public static string GetWhileLoop(Opcode o, int recurses = 1)
            {
                recurses--;
                bool canrecall = recurses > -1;
                int a = rnd.Next(1000, 9999);
                int cflownum = rnd.Next(1000, 9999);
                string s = @"
while _IDX < " + IntToHex(rnd.Next(100, 1000)) + @" and _NUM % " + IntToHex((a * 2)) + @" < " + IntToHex(a) + @" do
    _IDX = _IDX + 1
    _NUM = (_NUM " + (new string[] { "-", "+", "*" })[rnd.Next(0, 3)] + @" " + rnd.Next(10, 1024) + @") % " + rnd.Next(100, 50000) + @"
    local _ADDVAL = _IDX + _NUM
    if (_NUM % " + IntToHex(cflownum * 2) + @") " + (new string[] { ">", "<", "<=", ">=" })[rnd.Next(0, 4)] + @" " + IntToHex(cflownum) + @" then
       _NUM = (_NUM " + (new string[] { "-", "+", "*" })[rnd.Next(0, 3)] + @" " + IntToHex(rnd.Next(10, 1024)) + @") % " + IntToHex(rnd.Next(100, 50000)) + @"
        " + (canrecall ? GetWhileLoop(o, recurses) : o.GetOpcode()) + @"
    elseif _NUM % 2 ~= 0 then
       _NUM = (_NUM " + (new string[] { "-", "+", "*" })[rnd.Next(0, 3)] + @" " + IntToHex(rnd.Next(10, 1024)) + @") % " + IntToHex(rnd.Next(100, 50000)) + @"
        " + (canrecall ? GetWhileLoop(o, recurses) : o.GetOpcode()) + @"
    else
       _NUM = (_NUM " + (new string[] { "-", "+", "*" })[rnd.Next(0, 3)] + @" " + IntToHex(rnd.Next(10, 1024)) + @") % " + IntToHex(rnd.Next(100, 50000)) + @"
        _IDX = _IDX + 1
        " + (canrecall ? GetWhileLoop(o, recurses) : o.GetOpcode()) + @"
    end
end
";
                return s;

            }
            public static string ConfuseChunks(string[] lines)
            {
                if (lines[0].Contains("shouldskip")) // FIXME
                {
                    string ret = "";
                    for (int i = 0; i < lines.Length; i++)
                    {
                        ret += lines[i] + "  \n  ";
                    }
                    return ret;
                }
                Opcode o = new Opcode();
                string s = @"
local DEBUGDATA = ('');
local _NUM = 42069;
local _IDX = 0;
local _USED = {};
while _IDX < " + rnd.Next(100, 1000) + @" do
		_IDX = _IDX + 1;
		" + GetWhileLoop(o, 1) + @"
		_NUM = (_NUM " + (new string[] { "-", "+", "*" })[rnd.Next(0, 3)] + @" " + rnd.Next(10, 1024) + @") % " + rnd.Next(100, 50000) + @"
        
end

";
                string resp = iptr.DoString(s + "\nreturn DEBUGDATA").String;
                if (resp.Length < lines.Length)
                {


                    return ConfuseChunks(lines);
                }
                for (int i = 0; i < resp.Length; i++)
                {
                    if (i < lines.Length)
                    {
                        s = s.Replace("DEBUGDATA=DEBUGDATA..('" + resp[i] + "')", "\n" + lines[i] + "\n");
                    }
                    else
                    {
                        s = s.Replace("DEBUGDATA=DEBUGDATA..('" + resp[i] + "')", "");
                    }
                }

                for (int i = 0; i < debugletters.Length; i++)
                {
                    s = s.Replace("DEBUGDATA=DEBUGDATA..('" + debugletters[i] + "')", "\nStack[Instruction[OP_A]] = Constants[Instruction[OP_B]];\n"); // fake shit ignore
                }

                return s.Replace("local DEBUGDATA = ('');", "");
            }

        }


        public static class NumberGenerator
        {


            private static string[] GetNames(int arglen)
            {
                string ret = "";
                List<string> namelist = new List<string>();
                for (int i = 0; i < arglen; i++)
                {
                    namelist.Add("fArg" + i);
                }
                return namelist.ToArray();

            }

            private static string GetCallExpression(string[] names, bool canRecurse = false, int recursesLeft = 2)
            {
                recursesLeft--;
                if (recursesLeft < 1)
                {
                    canRecurse = false;
                }
                string ret = names[rnd.Next(0, names.Length)] + "(";
                string serializedargs = ret;
                for (int i = 0; i < names.Length; i++)
                {
                    serializedargs += (!canRecurse) ? names[rnd.Next(0, names.Length)] : GetCallExpression(names, rnd.Next(3, 7) == 4, recursesLeft);
                    if (rnd.Next(0, 6) == 3)
                    {
                        serializedargs += (" and ") + ((!canRecurse) ? names[rnd.Next(0, names.Length)] : GetCallExpression(names, rnd.Next(3, 7) == 4, recursesLeft));
                    }



                    if (i != names.Length - 1)
                    {
                        serializedargs += ", ";
                    }
                }

                return serializedargs + ")";

            }

            private static string GenerateNode(int arglen)
            {
                string ret = "";
                string[] argnames = Shuffle(GetNames(arglen));
                string serializedargs = "";
                for (int i = 0; i < arglen; i++)
                {
                    serializedargs += argnames[i];
                    if (i != arglen - 1)
                    {
                        serializedargs += ", ";
                    }
                }
                bool returnType = rnd.Next(0, 2) == 1;
                int cflownum = rnd.Next(100, 1000);
                ret += @"
function(" + serializedargs + @")
    if recurses > " + rnd.Next(100, 500) + @" then
        return fArg" + rnd.Next(0, arglen) + @"
    end
    recurses = recurses + 1
    num = (num " + (new string[] { "-", "+", "*" })[rnd.Next(0, 3)] + @" " + rnd.Next(10, 1024) + @") % " + rnd.Next(100, 50000) + @"

    if (num % " + cflownum * 2 + @") " + (new string[] { ">", "<", "<=", ">=" })[rnd.Next(0, 4)] + @" " + cflownum + @" then
        
        
        " + (rnd.Next(0, 2) == 1 ? @"num = (num " + (new string[] { "-", "+", "*" })[rnd.Next(0, 3)] + @" " + rnd.Next(10, 1024) + @") % " + rnd.Next(100, 50000) : "") + @"
        
        return " + (!returnType ? GetCallExpression(argnames, true) : "fArg" + rnd.Next(0, arglen)) + @"
    else        
        return " + (returnType ? GetCallExpression(argnames, true) : "fArg" + rnd.Next(0, arglen)) + @"
    end
    return " + (returnType ? GetCallExpression(argnames, true) : "fArg" + rnd.Next(0, arglen)) + @"
end;";


                return ret;
            }

            public static string ConfuseNumber(int n)
            {
                Console.WriteLine("[0x01]: generating cflow");
                int arglen = rnd.Next(1, 5);
                string[] argnames = Shuffle(GetNames(arglen));
                string serializedargs = "";
                for (int i = 0; i < arglen; i++)
                {
                    serializedargs += argnames[i];
                    if (i != arglen - 1)
                    {
                        serializedargs += ", ";
                    }
                }
                string argpart = "";
                for (int i = 0; i < arglen; i++)
                {
                    string a = GenerateNode(arglen);
                    argpart += a.Substring(0, a.Length - 1);
                    if (i < arglen - 1)
                    {
                        argpart += ",";
                    }
                }
                string ret = @"

(function()
local recurses,num=0,1;

(function(" + serializedargs + @")

	" + GetCallExpression(argnames, true) + @"

end)(" + argpart + @")

return num;
end)()
";


                double t = iptr.DoString("return " + ret).Number;
                double diff = (double)n - t;
                ret = "(" + diff + " + " + ret + ")";

                double check = iptr.DoString("return " + ret).Number;
                if (check != (double)n)
                {
                    Console.WriteLine("[0x03]: failed cflow - but don't worry");
                    return n + "";
                }
                Console.WriteLine("[0x02]: generated cflow");
                return ret;
            }
        }


    }
}
