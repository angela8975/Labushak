using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10
{
    [Serializable]
    public class Bus
    {
        public int BusNumber { get; set; }
        public string DriverName { get; set; }
        public TimeSpan TravelTime { get; set; }
        public string Destination { get; set; }

        public override string ToString()
        {
            return $"№ {BusNumber} | Водій: {DriverName} | Час: {TravelTime} | Пункт призначення: {Destination}";
        }
    }
}
