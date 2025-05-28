using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace lab6._2
{
    class Train : Transport
    {
        public int Carriages { get; set; }

        public Train(string name, int carriages) : base(name)
        {
            if (carriages <= 0)
                throw new ArgumentOutOfRangeException("Кількість вагонів повинна бути > 0.");
            Carriages = carriages;
        }

        public Train(string name) : this(name, 5) { }

        public override void DisplayInfo()
        {
            Console.WriteLine($"[Поїзд] Назва: {Name}, Вагонів: {Carriages}");
        }
    }
}
