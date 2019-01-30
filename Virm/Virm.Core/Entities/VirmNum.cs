using Virm.Core.Interfaces;

namespace Virm.Core.Entities
{
    public class VirmNum : IVirmUnit
    {
        public VirmNum(float data)
        {
            Data = data;
        }

        public VirmNum(int data)
        {
            Data = data;
        }

        public void Apply(IVirmStack stack)
        {
            stack.Push(this);
        }

        public readonly float Data;
    }
}
