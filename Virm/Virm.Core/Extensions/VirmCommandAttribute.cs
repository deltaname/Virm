using System;

namespace Virm.Core.Extensions
{
    [AttributeUsage(AttributeTargets.Method)]
    public class VirmCommandAttribute : Attribute
    {
        public VirmCommandAttribute(string commandName)
        {
            CommandName = commandName;
        }

        public readonly string CommandName;
    }
}
