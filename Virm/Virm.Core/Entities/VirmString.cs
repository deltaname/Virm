using Virm.Core.Interfaces;

namespace Virm.Core.Entities
{
    public class VirmString : IVirmUnit
    {
        public VirmString(string data)
        {
            Data = data;
        }

        public void Apply(IVirmStack stack)
        {
            stack.Push(this);
        }

        public readonly string Data;
    }
}
