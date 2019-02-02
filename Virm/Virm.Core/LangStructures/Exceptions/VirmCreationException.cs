using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virm.Core.LangStructures.Exceptions
{
    public class VirmCreationException : VirmException
    {
        public VirmCreationException(string message) : base($"[Virm] Creation exception: {message}")
        {

        }
    }
}
