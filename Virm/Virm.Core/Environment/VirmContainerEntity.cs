using System;

namespace Virm.Core.Environment
{
    internal class VirmContainerEntity
    {
        public string Name { get; set; }
        public Type Type { get; set; }
        public object Object { get; set; }
    }
}
