using Virm.Core.LangStructures.Exceptions;
using Virm.Core.LangStructures.Interfaces;

namespace Virm.Core.LangStructures
{
    public class VirmNull : IVirmObject
    {
        private const string SET_EXCEPTION_MESSAGE = "Object argument exception: null did not contain any data";
        private const string GET_EXCEPTION_MESSAGE = "Object argument exception: can't set any data to null";
        private const string CREATE_EXCEPTION_MESSAGE = "Object creation exception: can't create null";

        public object Data { get { throw new VirmArgumentException(SET_EXCEPTION_MESSAGE); } set { throw new VirmArgumentException(GET_EXCEPTION_MESSAGE); } }

        public IVirmObject Create(object obj)
        {
            throw new VirmCreationException(CREATE_EXCEPTION_MESSAGE);
        }
    }
}
