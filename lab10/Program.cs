using System.Text.Json;
using System.Xml.Serialization;

namespace lab10
{
    class Program
    {
        static void Main()
        {
            Bus[] buses = new Bus[]
            {
            new Bus { BusNumber = 101, DriverName = "Іваненко Іван", TravelTime = new TimeSpan(2, 30, 0), Destination = "Київ" },
            new Bus { BusNumber = 102, DriverName = "Петренко Олексій", TravelTime = new TimeSpan(3, 15, 0), Destination = "Львів" },
            new Bus { BusNumber = 103, DriverName = "Сидорчук А.", TravelTime = new TimeSpan(1, 45, 0), Destination = "Київ" }
            };

            string jsonPath = "buses.json";
            string xmlPath = "buses.xml";

            // JSON серіалізація
            string json = JsonSerializer.Serialize(buses, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(jsonPath, json);
            Console.WriteLine("JSON серіалізація виконана.");

            // JSON десеріалізація
            Bus[] fromJson = JsonSerializer.Deserialize<Bus[]>(File.ReadAllText(jsonPath));
            Console.WriteLine("JSON десеріалізація виконана.");

            // XML серіалізація
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Bus[]));
            using (FileStream fs = new FileStream(xmlPath, FileMode.Create))
            {
                xmlSerializer.Serialize(fs, buses);
            }
            Console.WriteLine("XML серіалізація виконана.");

            // XML десеріалізація
            Bus[] fromXml;
            using (FileStream fs = new FileStream(xmlPath, FileMode.Open))
            {
                fromXml = (Bus[])xmlSerializer.Deserialize(fs);
            }
            Console.WriteLine("XML десеріалізація виконана.");

            // Запит користувача
            Console.Write("Введіть пункт призначення: ");
            string inputDest = Console.ReadLine();

            Console.WriteLine($"\nАвтобуси, які їдуть до '{inputDest}' з ПІБ водія <= 17 символів:");
            foreach (var bus in fromXml)
            {
                if (bus.Destination.Equals(inputDest, StringComparison.OrdinalIgnoreCase) &&
                    bus.DriverName.Length <= 17)
                {
                    Console.WriteLine($"Номер: {bus.BusNumber} | Водій: {bus.DriverName}");
                }
            }
        }
    }
}
