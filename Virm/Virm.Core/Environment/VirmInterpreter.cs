using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Virm.Core.Execution;
using Virm.Core.LangStructures;

namespace Virm.Core.Environment
{
    internal class VirmInterpreter
    {
        private List<VirmMethod> commands = new List<VirmMethod>();

        public VirmInterpreter()
        {
            VirmReflection refl = new VirmReflection();
            commands.AddRange(refl.GetCommandsFromReflection());
        }

        public VirmMethod GetCommand(string code)
        {
            string commandName = code.Split(null)[0];
            VirmMethod method = commands.First(x => x.Name == commandName);
            return method;
        }

        public VirmExecNode[] InterpretCode(string code)
        {
            VirmExecNode node = UnwrapLine(code);
            return new VirmExecNode[] { node };
        }

        private VirmExecNode UnwrapLine(string code)
        {
            if(!code.Contains('('))
            {
                return UnpackBasicType(code);
            }

            if (!code.Contains('.') && code.Contains('('))
            {
                return UnpackCommand(code);
            }

            return null;
        }

        private VirmExecNode UnpackBasicType(string code)
        {
            var cont = VirmBasicTypes.Resolve(code);
            VirmExecContainer node = new VirmExecContainer();
            node.Container = cont;
            return node;
        }

        private VirmExecNode UnpackCommand(string code)
        {
            int firstBracet = code.IndexOf('(');
            int lastBracet = code.IndexOf(')');

            string commandName = code.Substring(0, firstBracet);
            string tail = code.Substring(firstBracet + 1, code.Length - firstBracet - 2);

            VirmExecMethod node = new VirmExecMethod();
            node.Next = UnwrapLine(tail);
            node.Next.Prev = node;

            node.Method = GetCommand(commandName);

            return node;
            
        }
    }
}
