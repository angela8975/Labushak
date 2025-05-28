using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7
{
    public interface IContainer<TElement>
    {
        int Count { get; }
        object this[int index] { get; set; }
        void Add(TElement element);
        void Delete(TElement element);
    }
}
