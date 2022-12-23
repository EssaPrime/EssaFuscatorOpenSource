namespace Compiler.Binding.Objects
{
    public sealed class LuaThread
    {
        private readonly Binding _binding;

        private readonly nint _reference;

        public LuaThread(nint reference, Binding binding)
        {
            _binding = binding;

            _reference = reference;
        }

        public override int GetHashCode() => (int)_reference;

        public override string ToString() => _binding.AsString(this);
    }
}