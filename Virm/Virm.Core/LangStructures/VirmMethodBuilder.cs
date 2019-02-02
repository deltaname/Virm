using System;
using System.Linq;
using System.Reflection;
using Virm.Core.Environment;
using Virm.Core.Extensions;
using Virm.Core.LangStructures.Exceptions;

namespace Virm.Core.LangStructures
{
    internal class VirmMethodBuilder
    {
        public VirmMethodWrapper Create(object obj)
        {
            VirmMethodWrapper wrapper = new VirmMethodWrapper();

            CheckNull(obj);
            CheckNotMethod(obj);
            CreateFromMethodInfo(obj, wrapper);

            return wrapper;
        }
        

        private void CreateFromMethodInfo(object obj, VirmMethodWrapper wrapper)
        {
            MethodInfo info = obj as MethodInfo;

            var argAttr = GetAttributes<VirmArgumentAttribute>(info);
            var retAttr = GetAttributes<VirmReturnAttribute>(info);

            if (argAttr.Length == 0)
            {
                if (retAttr.Length == 0)
                {
                    wrapper.MethodType = VirmMethodType.NoArgAction;
                    wrapper.Method = Delegate.CreateDelegate(typeof(Action), info);
                }
                else
                {
                    wrapper.MethodType = VirmMethodType.NoArgFunction;
                    wrapper.Method = Delegate.CreateDelegate(typeof(Func<VirmContainer>), info);
                }
            }
            else
            {
                if (retAttr.Length == 0)
                {
                    wrapper.MethodType = VirmMethodType.ArgAction;
                    wrapper.Method = Delegate.CreateDelegate(typeof(Action<VirmContainer>), info);
                }
                else
                {
                    wrapper.MethodType = VirmMethodType.ArgFunction;
                    wrapper.Method = Delegate.CreateDelegate(typeof(Func<VirmContainer, VirmContainer>), info);
                }
            }
        }

        private static void CheckNotMethod(object obj)
        {
            if (!(obj is Delegate) && !(obj is MethodInfo))
            {
                string message = "Object creation exception: the parameter must be delegate or method info";
                throw new VirmCreationException(message);
            }
        }

        private static void CheckNull(object obj)
        {
            if (obj == null)
            {
                string message = "Object creation exception: the parameter can't be null";
                throw new VirmCreationException(message);
            }
        }

        private static T[] GetAttributes<T>(MethodInfo info) where T : System.Attribute
        {
            return info
                .GetCustomAttributes<T>()
                .ToArray();
        }
    }
}
