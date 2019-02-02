using System.Linq;
using Virm.Core.Environment;
using Virm.Core.LangStructures.Exceptions;

namespace Virm.Core.LangStructures
{
    internal static class VirmBasicTypes
    {
        public static VirmContainer Resolve(string args)
        {
            if(args.Contains('"'))
            {
                return Str(args);
            }
            else if(int.TryParse(args, out int intResult))
            {
                return VirmContainer.Create(intResult);
            }
            else if(float.TryParse(args, out float floatResult))
            {
                return VirmContainer.Create(floatResult);
            }

            throw new VirmArgumentException($"Can't resolve type of ({args})");
        }

        public static VirmContainer Str(string args)
        {
            if(args.Count(x => x == '"') != 2)
            {
                throw new VirmArgumentException("Wrong string format");
            }

            VirmContainer container = new VirmContainer();
            container.AddValue(args.Trim('"'));

            return container;
        }

    }
}
