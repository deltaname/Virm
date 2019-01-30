using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virm.Core.Interfaces
{
    internal interface IVirmCommand : IVirmUnit
    {
        string Title { get; }
        string Description { get; }
        string Symbol { get; }

        void Create(string input);
    }
}
