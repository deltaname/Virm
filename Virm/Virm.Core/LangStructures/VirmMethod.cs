using System;
using System.Reflection;
using Virm.Core.LangStructures.Exceptions;
using Virm.Core.LangStructures.Interfaces;

namespace Virm.Core.LangStructures
{
    public class VirmMethod : IVirmObject
    {
        public VirmMethod(string name)
        {
            Name = name;
        }

        public object Data { get; set; }

        public string Name { get; set; }

        public IVirmObject Create(object obj)
        {
            if (obj == null)
            {
                string message = "Object creation exception: the parameter can't be null";
                throw new VirmCreationException(message);
            }

            if (!(obj is Delegate) && !(obj is MethodInfo))
            {
                string message = "Object creation exception: the parameter must be delegate or method info";
                throw new VirmCreationException(message);
            }
            
            Data = obj;

            if (obj is Delegate)
            {
                Data = obj;
                info = ((Delegate)Data).Method;
            }
            if (obj is MethodInfo)
            {
                Data = Delegate.CreateDelegate(typeof(Func<object[], object[]>), (MethodInfo)obj);
                info = (MethodInfo)obj;
            }
            return this;
        }

        public object GetReturnType()
        {
            return info.ReturnType;
        }
        
        public object GetParamCount()
        {
            return info.GetParameters().Length;
        }

        public object Execute()
        {
            if (info.GetParameters().Length > 0)
            {
                string message = $"Method call exception caused by {info.Name}: wrong parameters count";
                throw new VirmArgumentException(message);
            }

            Delegate method = (Delegate)Data;
            return method.DynamicInvoke(null);
        }

        public object Execute(object[] param)
        {
            if (info.GetParameters().Length != param.Length)
            {
                string message = $"Method call exception caused by {info.Name}: wrong parameters count";
                throw new VirmArgumentException(message);
            }

            Delegate method = (Delegate)Data;
            return method.DynamicInvoke(param);
        }

        private MethodInfo info;
    }
}
