using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace lab6._2
{
    class Car : Transport
    {
        public int ParkingSpot { get; set; }

        public Car(string name, int spot) : base(name)
        {
            if (spot < 0)
                throw new ArgumentOutOfRangeException("Номер місця повинен бути >= 0.");
            ParkingSpot = spot;
        }

        public Car(string name) : this(name, 0) { }

        public override void DisplayInfo()
        {
            Console.WriteLine($"[Автомобіль] Назва: {Name}, Паркомісце: {ParkingSpot}");
        }
    }

}
