using Virm.Core.LangStructures.Exceptions;
using Virm.Core.LangStructures.Interfaces;

namespace Virm.Core.LangStructures
{
    public class VirmClass : IVirmObject
    {
        public string Name { get; set; }

        public IVirmObject[] Members { get; set; }

        public object Data { get { return this; } set { throw new VirmException(); } }

        public IVirmObject Create(object obj)
        {
            throw new System.NotImplementedException();
        }
    }
}
