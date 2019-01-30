using System;

namespace Virm.Core.Interpreter
{
    internal class VirmIntpNode
    {
        public VirmIntpNode(Type type, string title, string description)
        {
            Type = type;
            Title = title;
            Description = description;
        }

        public Type Type { get; }
        public string Title { get; }
        public string Description { get; }
    }
}
