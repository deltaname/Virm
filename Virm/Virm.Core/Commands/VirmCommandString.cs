using System;
using Virm.Core.Entities;
using Virm.Core.Interfaces;

namespace Virm.Core.Commands
{
    internal class VirmCommandString : IVirmCommand
    {
        public string Title => "String";

        public string Description => "Put string to stack";

        public string Symbol => "string";

        public void Apply(IVirmStack stack)
        {
            stack.Push(new VirmString(data));
        }

        public void Create(string input)
        {
            int startIndex = input.IndexOf('"');
            if (startIndex < 0)
                throw new ArgumentException();

            int curIndex = startIndex + 1;

            while(input[curIndex] != '"')
            {
                curIndex++;
            }

            data = input.Substring(startIndex + 1, curIndex - startIndex - 1);
        }

        private string data;
    }
}
