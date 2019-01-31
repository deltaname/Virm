using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Virm.Core.LangStructures.Exceptions;
using Virm.Core.LangStructures.Interfaces;

namespace Virm.Core.LangStructures
{
    public class VirmNum : IVirmObject
    {
        public object Data { get; set; }

        /// <summary>
        /// Create 32 bits float number
        /// </summary>
        /// <param name="number">Number</param>
        /// <returns>Object of VirmNumber</returns>
        public IVirmObject Create(object number)
        {
            if (number == null || number is VirmNull)
            {
                string message = "Object creation exception: the parameter can't be null";
                throw new VirmCreationException(message);
            }

            float data = 0;

            try
            {
                data = Convert.ToSingle(number);
            }
            catch (System.FormatException)
            {
                string message = "Object creation exception: the parameter must be a number.";
                throw new VirmCreationException(message);
            }

            Data = data;
            return this;
        }
    }
}
