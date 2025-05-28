using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace lab6._2
{
    class Express : Train
    {
        public int Speed { get; set; }

        public Express(string name, int carriages, int speed) : base(name, carriages)
        {
            if (speed <= 0)
                throw new ArgumentOutOfRangeException("Швидкість повинна бути > 0.");
            Speed = speed;
        }

        public Express(string name) : this(name, 5, 200) { }

        public override void DisplayInfo()
        {
            Console.WriteLine($"[Експрес] Назва: {Name}, Вагонів: {Carriages}, Швидкість: {Speed} км/год");
        }
    }
}
