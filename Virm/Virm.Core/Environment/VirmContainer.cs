using System.Collections.Generic;
using System.Linq;
using Virm.Core.LangStructures.Exceptions;

namespace Virm.Core.Environment
{
    public class VirmContainer
    {
        private List<VirmContainerEntity> content;

        public VirmContainer()
        {
            content = new List<VirmContainerEntity>();
        }

        public void AddValue(object value, string name)
        {
            content.Add(new VirmContainerEntity()
            {
                Object = value,
                Name = name,
                Type = value.GetType()
            });

        }

        public void AddValue<T>(object value)
        {
            AddValue<T>(value, null);
        }

        public void AddValue<T>(object value, string name)
        {
            content.Add(new VirmContainerEntity()
            {
                Object = value,
                Type = typeof(T),
                Name = name
            });
        }

        public void AddValue(object value)
        {
            content.Add(new VirmContainerEntity()
            {
                Object = value,
                Type = value.GetType(),
                Name = null
            }
            );
        }

        public T GetValue<T>()
        {
            bool condition = 
                (content.Where(x => x.Type == typeof(T)))
                .Count() > 0;

            if (!condition)
                throw new VirmArgumentException($"That container has no object of {typeof(T)}");

            var a = content.First(x => x.Type == typeof(T));
            var value = a.Object;
            return (T)value;
        }

        public object this[string index]
        {
            get
            {
                return content.First(x => x.Name == index).Object;
            }

            set
            {
                AddValue(value, index);
            }
        }

        public static VirmContainer Create(params object[] values)
        {
            VirmContainer container = new VirmContainer();

            foreach (var value in values)
            {
                container.AddValue(value);
            }

            return container;
        }
    }
}
