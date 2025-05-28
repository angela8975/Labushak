using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7
{
    public interface IFileContainer<TElement> : IContainer<TElement>
    {
        void Save(string fileName);
        void Load(string fileName);
        bool IsDataSaved { get; }
    }
}

