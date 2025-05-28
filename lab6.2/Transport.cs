using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6._2
{
    abstract class Transport
    {
        public string Name { get; set; }

        public Transport(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Назва не може бути порожньою.");
            Name = name;
        }

        public abstract void DisplayInfo();
    }
}
