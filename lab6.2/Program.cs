using System.Diagnostics;

namespace lab6._2
{
    class Program
    {
        static void Main()
        {
            List<Transport> transports = new List<Transport>();

            try
            {
                transports.Add(new Car("Toyota", 1));
                transports.Add(new Car("BMW"));
                transports.Add(new Train("Intercity", 10));
                transports.Add(new Train("Night Express"));
                transports.Add(new Express("Hyundai", 8, 250));
                transports.Add(new Express("SuperFast"));

                Console.WriteLine("Інформація про транспорт:");
                foreach (var t in transports)
                {
                    t.DisplayInfo();
                }

                // Варіант запиту: кількість автомобілів (на автостоянці)
                int carCount = 0;
                foreach (var t in transports)
                {
                    if (t is Car) carCount++;
                }

                Console.WriteLine($"\nКількість транспортних засобів на автостоянці (автомобілів): {carCount}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
            }

            if (transports.Count == 0)
            {
                Console.WriteLine("Результат порожній. Немає транспортних засобів.");
            }
        }
    }
}
