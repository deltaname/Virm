using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virm.Core.LangStructures.Exceptions
{
    public class VirmArgumentException : VirmException
    {
        public VirmArgumentException(string message) : base(message) 
        {

        }
    }
}
