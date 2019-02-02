using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Virm.Core.LangStructures;

namespace Virm.Core.Execution
{
    internal class VirmExecMethod : VirmExecNode
    {
        public VirmMethod Method { get; set; }
    }
}
