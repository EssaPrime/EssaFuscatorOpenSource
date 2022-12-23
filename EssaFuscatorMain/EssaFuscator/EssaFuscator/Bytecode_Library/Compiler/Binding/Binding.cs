using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using Compiler.Binding.Objects;
using static Compiler.Binding.Lua51Natives;

namespace Compiler.Binding
{
    public sealed class Binding
    {
        // ReSharper disable once CollectionNeverQueried.Local
        private readonly HashSet<LuaNativeFunction> _functions = new();
        
        private nint _state;

        private int Top 
        { 
            get => lua_gettop(_state); 
            set => lua_settop(_state, value); 
        }

        public object? this[int index] => Get(index);
        
        public object? this[string field] 
        { 
            get
            {
                var top = Top;

                GetField(-10002, field);

                var @object = this[-1];

                Top = top;

                return @object;
            }
            set
            {
                var top = Top;

                Push(value);

                SetField(-10002, field);

                Top = top;
            }
        }
        
        public Binding()
        {
            _state = luaL_newstate();

            if (_state == 0)
                throw new Exception("Lua state is NULL.");

            luaL_openlibs(_state);
        }

        ~Binding()
        {
            if (_state == 0)
                return;

            lua_close(_state);

            _state = 0;
        }
        
        public void GetField(int index, string field)
        {
            lua_getfield(_state, index, field);
        }

        public void SetField(int index, string field)
        {
            lua_setfield(_state, index, field);
        }
        
        public object?[] Call(LuaFunction function, params object?[] arguments)
        {
            var top = Top;

            Push(function);

            foreach (var argument in arguments)
                Push(argument);

            lua_call(_state, arguments.Length, -1);

            var returns = new List<object?>();

            for (var index = Top; index >= top; index--)
            {
                returns.Add(this[-1]);

                Top = index - 1;
            }

            Top = top;

            return returns.ToArray();
        }
        
        private int Type(int index) => lua_type(_state, index);
        
        private void Push(object? @object)
        {
            switch (@object)
            {
                case double or float or decimal:
                {
                    lua_pushnumber(_state, Convert.ToDouble(@object));

                    break;
                }
                case int or long or uint or ulong or byte or char or short or ushort or nint or nuint:
                {
                    lua_pushnumber(_state, Convert.ToInt64(@object));

                    break;
                }
                case string @string:
                {
                    Push(Encoding.UTF8.GetBytes(@string));

                    break;
                }
                case bool @bool:
                {
                    lua_pushboolean(_state, @bool ? 1 : 0);

                    break;
                }
                case byte[] buffer:
                {
                    lua_pushlstring(_state, buffer, (nuint)buffer.Length);

                    break;
                }
                case LuaTable table:
                {
                    lua_rawgeti(_state, -10000, table.GetHashCode());

                    break;
                }
                case LuaFunction function:
                {
                    lua_rawgeti(_state, -10000, (int)function.GetPointer());

                    break;
                }
                case LuaNativeFunction function:
                {
                    _functions.Add(function);

                    lua_pushcclosure(_state, Marshal.GetFunctionPointerForDelegate(function), 0);

                    break;
                }
                default:
                {
                    lua_pushnil(_state);

                    break;
                }
            }
        }

        private object? Get(int index)
        {
            switch (Type(index))
            {
                case 1:
                {
                    return lua_toboolean(_state, index) != 0;
                }
                case 2:
                {
                    var top = Top;

                    lua_pushvalue(_state, index);

                    var function = new LuaUserData(lua_touserdata(_state, -10000), this);

                    Top = top;

                    return function;
                }
                case 3:
                {
                    return lua_tonumber(_state, index);
                }
                case 4:
                {
                    var buffer = lua_tolstring(_state, index, out var pointer);

                    if (buffer == 0)
                        return null;

                    var length = (int)pointer;

                    if (length == 0)
                        return "";

                    var output = new byte[length];

                    Marshal.Copy(buffer, output, 0, length);

                    return Encoding.GetEncoding(28591).GetString(output);
                }
                case 5:
                {
                    var top = Top;

                    lua_pushvalue(_state, index);

                    var table = new LuaTable(luaL_ref(_state, -10000), this);

                    Top = top;

                    return table;
                }
                case 6:
                {
                    var top = Top;

                    lua_pushvalue(_state, index);

                    var table = new LuaFunction(luaL_ref(_state, -10000), this);

                    Top = top;

                    return table;
                }
                case 7:
                {
                    var top = Top;

                    lua_pushvalue(_state, index);

                    var function = new LuaUserData(lua_touserdata(_state, -10000), this);

                    Top = top;

                    return function;
                }
                case 8:
                {
                    var top = Top;

                    lua_pushvalue(_state, index);
                    
                    var function = new LuaThread(lua_tothread(_state, -10000), this);

                    Top = top;

                    return function;
                }
                default:
                {
                    return null;
                }
            }
        }

        private string AsString(int index)
        {
            var top = Top;

            lua_pushvalue(_state, index);

            if (luaL_callmeta(_state, -1, "__tostring") == 0)
            {
                switch (Type(-1))
                {
                    case 0:
                    {
                        Push("nil");

                        break;
                    }
                    case 1:
                    {
                        Push((bool)this[-1]! ? "true" : "false");

                        break;
                    }
                    case 2:
                    {
                        Push($"userdata: {lua_topointer(_state, -1):X}");

                        break;
                    }
                    case 3:
                    {
                        Push(this[-1]!.ToString());

                        break;
                    }
                    case 4:
                    {
                        Push(this[-1]);

                        break;
                    }
                    case 5:
                    {
                        Push($"table: {lua_topointer(_state, -1):X}");

                        break;
                    }
                    case 6:
                    {
                        Push($"function: {lua_topointer(_state, -1):X}");

                        break;
                    }
                    case 7:
                    {
                        Push($"userdata: {lua_topointer(_state, -1):X}");

                        break;
                    }
                    case 8:
                    {
                        Push($"thread: {lua_topointer(_state, -1):X}");

                        break;
                    }
                    default:
                    {
                        Push(null);

                        break;
                    }
                }
            }

            var @string = this[-1];

            Top = top;

            return (string)@string!;
        }

        public string AsString(object? @object)
        {
            var top = Top;

            Push(@object);

            var @string = AsString(-1);

            Top = top;

            return @string;
        }

        public (bool, object?) LoadString(string source)
        {
            var top = Top;

            var buffer = Encoding.UTF8.GetBytes(source);

            var status = luaL_loadbuffer(_state, buffer, (nuint)buffer.Length, "C#");

            var @return = (status == 0, Get(-1));

            Top = top;

            return @return;
        }

        public (bool, object?[]) DoString(string source)
        {
            var status = LoadString(source);
            
            if (!status.Item1)
                return (status.Item1, new[] { status.Item2 });

            var function = (LuaFunction)status.Item2!;
            
            return (true, function.Call());
        }

        public Dictionary<object, object> GetDictionaryFromTable(LuaTable table)
        {
            var dictionary = new Dictionary<object, object>();

            var top = Top;

            Push(table);

            Push(null);

            while (lua_next(_state, -2) != 0)
            {
                dictionary[this[-2]!] = this[-1]!;

                Top = -2;
            }

            Top = top;

            return dictionary;
        }
    }
}