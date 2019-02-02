using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virm.Core.Execution
{
    internal abstract class VirmExecNode
    {
        public VirmExecNode Next;
        public VirmExecNode Prev;
    }
}
