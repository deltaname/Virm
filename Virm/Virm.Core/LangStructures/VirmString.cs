using Virm.Core.LangStructures.Interfaces;

namespace Virm.Core.LangStructures
{
    public class VirmString : IVirmObject
    {
        public object Data { get; set; }

        /// <summary>
        /// Create a string
        /// </summary>
        /// <param name="obj">String</param>
        /// <returns>Object of VirmString type</returns>
        public IVirmObject Create(object obj)
        {
            if (!(obj is string))
                Data = obj.ToString();
            else
                Data = obj;

            return this;
        }
    }
}
