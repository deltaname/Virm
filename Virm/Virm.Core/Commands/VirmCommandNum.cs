using Virm.Core.Entities;
using Virm.Core.Interfaces;

namespace Virm.Core.Commands
{
    internal class VirmCommandNum : IVirmCommand
    {
        public string Title => "Number";

        public string Description => "Put number to stack";

        public string Symbol => "num";

        public void Apply(IVirmStack stack)
        {
            stack.Push(new VirmNum(data));
        }

        public void Create(string input)
        {
            data = float.Parse(input);
        }

        private float data;
    }
}
