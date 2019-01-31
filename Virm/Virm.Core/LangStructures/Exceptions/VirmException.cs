using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virm.Core.LangStructures.Exceptions
{
    public class VirmException : SystemException
    {
        public VirmException() : base()
        {

        }

        public VirmException(string message) : base(message)
        {

        }
    }
}
