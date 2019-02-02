using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Virm.Core.Extensions;
using Virm.Core.LangStructures;

namespace Virm.Core.Environment
{
    internal class VirmReflection
    {
        public VirmMethod[] GetCommandsFromReflection()
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            List<VirmMethod> virmCommands = new List<VirmMethod>();

            List<MethodInfo> reflectionMethods = new List<MethodInfo>();
            foreach (var assembly in assemblies)
            {
                MethodInfo[] methods = GetMethodsWithCommandAttribute(assembly);

                reflectionMethods.AddRange(methods);
            }

            foreach (var method in reflectionMethods)
            {
                VirmMethod virmCommand = WrapMethodToCommand(method);
                virmCommands.Add(virmCommand);
            }

            return virmCommands.ToArray();
        }

        private static VirmMethod WrapMethodToCommand(MethodInfo method)
        {
            string name = method.GetCustomAttribute<VirmCommandAttribute>().CommandName;

            VirmMethod virmCommand = new VirmMethod(name).Create(method) as VirmMethod;
            return virmCommand;
        }
        private static MethodInfo[] GetMethodsWithCommandAttribute(Assembly assembly)
        {
            return assembly
                .DefinedTypes
                .SelectMany(x => x.DeclaredMethods)
                .Where(x => x.GetCustomAttributes(typeof(VirmCommandAttribute), false).Length > 0)
                .ToArray();
        }
    }
}
