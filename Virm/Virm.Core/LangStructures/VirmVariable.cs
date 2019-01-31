using Virm.Core.LangStructures.Interfaces;

namespace Virm.Core.LangStructures
{
    public class VirmVariable
    {

        public string Name { get; private set; }
        public IVirmObject Value { get; set; }

        public VirmVariable(string name)
        {
            Name = name;
        }

        public VirmVariable(string name, IVirmObject value)
        {
            Name = name;
            Value = value;
        }

        public IVirmObject Get()
        {
            return Value;
        }
        
        public void Set(IVirmObject value)
        {
            Value = value;
        }
    }
}
