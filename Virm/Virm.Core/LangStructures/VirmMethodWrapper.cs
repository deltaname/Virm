using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virm.Core.LangStructures
{
    internal enum VirmMethodType
    {
        ArgAction,
        ArgFunction,
        NoArgAction,
        NoArgFunction
    }

    internal class VirmMethodWrapper
    {
        public VirmMethodType MethodType { get; set; }
        public object Method { get; set; }
    }
}
