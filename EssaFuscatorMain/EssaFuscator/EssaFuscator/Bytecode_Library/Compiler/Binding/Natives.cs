#pragma warning disable CA2101 
#pragma warning disable CA1401

using System.Runtime.InteropServices;

namespace Compiler.Binding
{
    public static class Lua51Natives
    {
        private const string LuaLibraryName = @"../LuaCompiler-O.dll";
        
        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_call(nint state, int arguments, int results);
        
        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_close(nint state);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_gettop(nint state);
        
        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_next(nint state, int index);
        
        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_pushboolean(nint state, int boolean);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_pushcclosure(nint state, nint function, int upvalues);
        
        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_pushlstring(nint state, byte[] buffer, nuint size);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_setfield(nint state, int index, string key);
        
        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_getfield(nint state, int index, string field);
        
        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_pushnil(nint state);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_pushnumber(nint state, double number);
        
        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_pushvalue(nint state, int index);
        
        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_rawgeti(nint state, int index, int integer);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_settop(nint state, int index);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_toboolean(nint state, int index);
        
        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nint lua_tolstring(nint state, int index, out nuint length);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern double lua_tonumber(nint state, int index);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nint lua_topointer(nint state, int index);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nint lua_tothread(nint state, int index);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nint lua_touserdata(nint state, int index);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_type(nint state, int index);
        
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        
        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int luaL_callmeta(nint state, int @object, string name);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int luaL_loadbuffer(nint state, byte[] buffer, nuint size, string name);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nint luaL_newstate();

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void luaL_openlibs(nint state);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int luaL_ref(nint state, int index);
    }
}