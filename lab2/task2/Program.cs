namespace task2
{
    internal class Program
    {
        static void Main()
        {
            double[] testValues = { 0.5, 0.9, 0.99 };

            Console.WriteLine("Calculating y(x) = ln((1+x)/(1-x)) using series approximation");
            Console.WriteLine("S(x) = 2·(x/1 + x³/3 + x⁵/5 + x⁷/7 + ...)");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("x\t| Series S(x)\t| Function y(x)\t| Difference");
            Console.WriteLine("--------------------------------------------------");

            for (int i = 0; i < testValues.Length; i++)
            {
                double x = testValues[i];
                double seriesResult = CalculateSeries(x);
                double functionResult = CalculateFunction(x);
                double difference = Math.Abs(seriesResult - functionResult);

                Console.WriteLine($"{x, -5:F2}\t| {seriesResult,9:F4}\t| {functionResult,9:F4}\t| {difference:E6}");
            }
        }

        static double CalculateSeries(double x)
        {
            double sum = 0;
            double term;
            int n = 0;

            do
            {
                int power = 2 * n + 1;
                term = Math.Pow(x, power) / power;
                sum += term;
                n++;
            } while (Math.Abs(term) >= 1e-6);

            return 2 * sum;
        }

        
        static double CalculateFunction(double x)
        {
            return Math.Log((1 + x) / (1 - x));
        }
    }
}
