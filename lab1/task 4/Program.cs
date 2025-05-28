namespace task_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] lines = File.ReadAllLines("input.txt");

                if (lines.Length < 4)
                {
                    Console.WriteLine("Недостатньо рядків");
                    return;
                }
               
                double FuelCapasity = double.Parse(lines[0]);  // Емкость бака
                double DistanseAB = double.Parse(lines[1]);
                double DistanseBC = double.Parse(lines[2]);
                double CargoWeigth = double.Parse(lines[3]);  //Вес груза

                if (CargoWeigth > 2000)
                {
                    Console.WriteLine("більше, ніж 2000 кг літак не піднімає");
                    return;
                }
                
                double fuelConsumptionPerKm = CalFuelConsuption(CargoWeigth); // Расчет расхода топлива на километр

                double FuelForDistanseAB = DistanseAB * fuelConsumptionPerKm;
                double FuelForDistanseBC = DistanseBC * fuelConsumptionPerKm;  // Расчет необходимого топлива для участков пути

                if (FuelCapasity < FuelForDistanseAB)
                {
                    Console.WriteLine("Політ неможливий");
                    return;
                }

                double RemainingAB = FuelCapasity - FuelForDistanseAB; // Расчет оставшегося топлива после прибытия в B

                double MinForRefuelingB = Math.Max(0, DistanseBC - RemainingAB);
                Console.WriteLine($"Мінімальна кількість палива для дозаправки у пункті B: {MinForRefuelingB} літрів ");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Виникла помилка: {ex.Message}");
            }
        }
        static double CalFuelConsuption(double weigth)    // Метод для расчета расхода топлива в зависимости от веса груза
        {
            switch (weigth)
            {
                case <= 500:
                    return 1;
                case <= 1000:
                    return 4;
                case <= 1500:
                    return 7;
                default: // weigth <= 2000
                    return 9;
            }
        }
    }
}
