namespace task1
{
    internal class Program
    {
        static void Main()
        {
            double a = 1; // Значення параметра a
            double xStart = 1, xEnd = 7, dx = 0.25;

            Console.WriteLine("x\t y(x)");
            for (double x = xStart; x <= xEnd; x += dx)
            {
                double numerator = Math.Pow((a + 1) * x, 1 / 4) + Math.Exp(-Math.Pow(x, 3));
                double denominator = Math.Sqrt(2 * a * x);
                double y = denominator != 0 ? numerator / denominator : double.NaN; // Уникнення ділення на нуль

                Console.WriteLine($"{x:F2}\t {y:F4}");
            }
        }
    }
}
