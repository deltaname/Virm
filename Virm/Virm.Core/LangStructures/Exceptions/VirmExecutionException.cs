using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virm.Core.LangStructures.Exceptions
{
    public class VirmExecutionException : VirmException
    {
        public VirmExecutionException(string message) : base($"[Virm] Execution exception: {message}")
        {
            
        }
    }
}
