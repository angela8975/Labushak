using System.Text.RegularExpressions;

namespace lab4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] value = { "23.78 USD", "22 UDD", "0,002 US" };
            string[] wrongvalue = { "22 UDD", "0,002 US" };
            string pattern = @"^\d+(.\d*)? USD|UA|EU$";
            string pattern2 = @"^\d+(.\d*)?";
            string replacement = "USD";

            foreach (string v in value)
            {
                if (Regex.IsMatch(v, pattern))
                {

                    Console.WriteLine($"Corect value {v}");
                }
                else
                {
                    Console.WriteLine("\nInvalid value");

                    Console.Write("Maybe you mean: ");
                    Console.WriteLine($"{Regex.Matches(v, pattern2)[0].Value} {replacement}");
                }
            }

            foreach (string l in wrongvalue)
            {
                if (Regex.IsMatch(l, pattern))
                {
                    Console.WriteLine(l);
                }
                else
                {
                    Console.WriteLine("\nInvalid value");

                    Console.Write("Maybe you mean: ");
                    Console.WriteLine($"{Regex.Matches(l, pattern2)[0].Value} {replacement}");

                }
            }
            Console.ReadKey();
        }


    }
}
