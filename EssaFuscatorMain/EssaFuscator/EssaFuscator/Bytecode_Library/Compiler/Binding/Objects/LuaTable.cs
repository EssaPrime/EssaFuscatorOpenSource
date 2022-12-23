using System.Collections;
using System.Collections.Generic;

namespace Compiler.Binding.Objects
{
    public sealed class LuaTable : IEnumerable
    {
        private readonly Binding _binding;

        private readonly int _reference;

        public LuaTable(int reference, Binding binding)
        {
            _binding = binding;

            _reference = reference;
        }

        public Dictionary<object, object> Dictionary => _binding.GetDictionaryFromTable(this);
        
        public IEnumerator GetEnumerator() => Dictionary.GetEnumerator();

        public override int GetHashCode() => _reference;

        public override string ToString() => _binding.AsString(this);
    }
}