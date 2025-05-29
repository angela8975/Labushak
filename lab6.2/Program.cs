using System.Diagnostics;

namespace lab6._2
{
    class Program
{
    static void Main()
    {
        Transport[] transports = new Transport[10];
        int count = 0;

        try
        {
            transports[count++] = new Car("Toyota", 1);
            transports[count++] = new Car("BMW");
            transports[count++] = new Train("Intercity", 10);
            transports[count++] = new Train("Night Express");
            transports[count++] = new Express("Hyundai", 8, 250);
            transports[count++] = new Express("SuperFast");

            Console.WriteLine("Інформація про транспорт:");
            for (int i = 0; i < count; i++)
            {
                transports[i].DisplayInfo();
            }

            // Варіант запиту: кількість автомобілів (на автостоянці)
            int carCount = 0;
            for (int i = 0; i < count; i++)
            {
                if (transports[i] is Car)
                    carCount++;
            }

            Console.WriteLine($"\nКількість транспортних засобів на автостоянці (автомобілів): {carCount}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }

        if (count == 0)
        {
            Console.WriteLine("Результат порожній. Немає транспортних засобів.");
        }
    }
}
}
