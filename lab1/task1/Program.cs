namespace task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double x = 6.251, y = 0.827, z = 25.001;
            double b = Math.Pow(y, 3 * Math.Sqrt(Math.Abs(x))) + Math.Pow(Math.Cos(y), 3) *
                (Math.Abs(x - y) * (1 + (Math.Pow(Math.Sin(z), 2) / Math.Sqrt(x + y)))) / (Math.Exp(Math.Abs(x - y)) + x / 2);
            Console.WriteLine($"b({x,3:F3}, {y,3:F3}, {z,3:F3})= {y,3:F3}");
            Console.ReadKey();

        }
    }
}
