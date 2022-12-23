using System.Security;

using System.Runtime.InteropServices;

namespace Compiler.Binding.Objects
{
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int LuaNativeFunction(nint state);

    public sealed class LuaFunction
    {
        private readonly Binding _binding;

        private readonly nint _reference;

        public LuaFunction(nint reference, Binding binding)
        {
            _binding = binding;

            _reference = reference;
        }

        public object?[] Call(params object?[] arguments) => _binding.Call(this, arguments);
        
        public nint GetPointer() => _reference;

        public override int GetHashCode() => (int)_reference;

        public override string ToString() => _binding.AsString(this);
    }
}