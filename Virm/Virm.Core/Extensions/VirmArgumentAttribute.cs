using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virm.Core.Extensions
{
    [AttributeUsage(AttributeTargets.Method)]
    public class VirmArgumentAttribute : Attribute
    {
        public VirmArgumentAttribute(string name, Type type)
        {
            ArgumentName = name;
            ArgumentType = type;
        }
        
        public VirmArgumentAttribute(string name)
        {
            ArgumentName = name;
        }

        public readonly string ArgumentName;
        public readonly Type ArgumentType;
    }
}
