using System;
using System.Linq;
using System.Reflection;
using Virm.Core.Environment;
using Virm.Core.Extensions;
using Virm.Core.LangStructures.Exceptions;
using Virm.Core.LangStructures.Interfaces;

namespace Virm.Core.LangStructures
{
    internal class VirmMethod : IVirmObject
    {
        public VirmMethod(string name)
        {
            Name = name;
        }

        public object Data { get; set; }

        public string Name { get; set; }

        public IVirmObject Create(object obj)
        {
            VirmMethodBuilder builder = new VirmMethodBuilder();
            data = builder.Create(obj);

            return this;
        }

        internal VirmMethodType GetMethodType()
        {
            return data.MethodType;
        }

        public void ExecuteAction()
        {
            Action action = (Action)data.Method;
            action.Invoke();
        }

        public void ExecuteAction(VirmContainer args)
        {
            Action<VirmContainer> action = (Action<VirmContainer>)data.Method;
            action.Invoke(args);
        }

        public VirmContainer ExecuteFunc()
        {
            Func<VirmContainer> func = (Func<VirmContainer>)data.Method;
            return func.Invoke();
        }

        public VirmContainer ExecuteFunc(VirmContainer args)
        {
            Func<VirmContainer, VirmContainer> func = (Func<VirmContainer, VirmContainer>) data.Method;
            return func.Invoke(args);
        }

        private VirmMethodWrapper data;

    }
}
