using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virm.Core.Extensions
{
    [AttributeUsage(AttributeTargets.Method)]
    public class VirmReturnAttribute : Attribute
    {
        public VirmReturnAttribute(Type type)
        {
            ReturnType = type;
        }

        public readonly Type ReturnType;
    }
}
