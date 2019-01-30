using System;
using System.Collections.Generic;
using System.Linq;
using Virm.Core.Interfaces;
using Virm.Core.Interpreter;

namespace Virm.Core
{
    public class VirmInterpreter : IVirmInterpreter
    {
        public VirmInterpreter()
        {
            CreateCommandsDictionary();
        }

        public IVirmUnit InterpretLine(string data)
        {
            data = data.Trim();
            int index = data.IndexOf(' ');

            string com = string.Empty;

            if (index > 0)
                com = data.Substring(0, index);
            else
                com = data;

            IVirmCommand command = CreateCommandInstance(dictionary[com].Type);

            string parm = string.Empty;

            if(index > 0)
                parm = data.Substring(index, data.Length - index);

            command.Create(parm);

            return command;
        }

        public bool TryInterpretLine(string data, out IVirmUnit unit)
        {
            throw new System.NotImplementedException();
        }

        private void CreateCommandsDictionary()
        {
            IEnumerable<Type> types = GetCommandsFromReflection();
            dictionary = new Dictionary<string, VirmIntpNode>(types.Count());

            foreach (var type in types)
            {
                var command = CreateCommandInstance(type);

                dictionary.Add(
                    command.Symbol,
                    new VirmIntpNode
                    (
                        type,
                        command.Title,
                        command.Description
                    )
                );
            }
        }

        private static IEnumerable<Type> GetCommandsFromReflection()
        {
            return AppDomain
                .CurrentDomain
                .GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(x => typeof(IVirmCommand)
                .IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract);

        }

        private IVirmCommand CreateCommandInstance(Type type)
        {
            return (IVirmCommand)Activator.CreateInstance(type);
        }

        private Dictionary<string, VirmIntpNode> dictionary;
    }
}
