using System.Collections.Generic;
using System.Linq;
using System.Text;
using Virm.Core.Environment;
using Virm.Core.LangStructures;

namespace Virm.Core
{
    public class VirmMachine
    {
        public List<VirmMethod> commands = new List<VirmMethod>();

        public VirmMachine()
        {
            VirmReflection refl = new VirmReflection();
            commands.AddRange(refl.GetCommandsFromReflection());
        }

        public void Execute(string code)
        {
            StringBuilder builder = new StringBuilder();

            int index = 0;

            while(index < code.Length && code[index] != ' ')
            {
                builder.Append(code[index]);
                index++;
            }

            string command = builder.ToString();
            index++;

            builder.Clear();

            while(index < code.Length)
            {
                builder.Append(code[index]);
                index++;
            }

            string args = builder.ToString();

            var codeParts = code.Split(null);
            var commandName = codeParts[0];

            var commandInstance = commands.First(x => x.Name == commandName);
            commandInstance.Execute(new object[] { new object[] { args } });

            //TODO: FIX WRONG ARGUMENT CALL
        }
    }
}
