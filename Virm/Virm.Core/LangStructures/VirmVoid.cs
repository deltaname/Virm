using Virm.Core.LangStructures.Exceptions;
using Virm.Core.LangStructures.Interfaces;

namespace Virm.Core.LangStructures
{
    public class VirmVoid : IVirmObject
    {
        private const string SET_EXCEPTION_MESSAGE = "Object argument exception: void did not contain any data";
        private const string GET_EXCEPTION_MESSAGE = "Object argument exception: can't set any data to void";
        private const string CREATE_EXCEPTION_MESSAGE = "Object creation exception: can't create void";

        public object Data { get { throw new VirmArgumentException(GET_EXCEPTION_MESSAGE); } set { throw new VirmArgumentException(SET_EXCEPTION_MESSAGE); } }

        public IVirmObject Create(object obj)
        {
            throw new VirmCreationException(CREATE_EXCEPTION_MESSAGE);
        }
    }
}
