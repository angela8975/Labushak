
using System;

class Program
{
    static void Main()
    {
        // === Action делегати ===
        Action displayTime = () => Console.WriteLine("Час: " + DateTime.Now.ToString("HH:mm:ss"));
        Action displayDate = () => Console.WriteLine("Дата: " + DateTime.Now.ToString("dd.MM.yyyy"));
        Action displayDayOfWeek = () => Console.WriteLine("День тижня: " + DateTime.Now.DayOfWeek);

        // Виклик Action-методів
        displayTime();
        displayDate();
        displayDayOfWeek();

        Console.WriteLine();

        // === Predicate делегати ===
        Predicate<int> isPrime = number =>
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            for (int i = 2; i <= Math.Sqrt(number); i++)
                if (number % i == 0) return false;
            return true;
        };

        Predicate<int> isFibonacci = number =>
        {
            bool IsPerfectSquare(int x) => (int)Math.Sqrt(x) * (int)Math.Sqrt(x) == x;
            return IsPerfectSquare(5 * number * number + 4) || IsPerfectSquare(5 * number * number - 4);
        };

        // Виклик Predicate-методів
        int testNumber = 13;
        Console.WriteLine($"{testNumber} є простим числом? {isPrime(testNumber)}");
        Console.WriteLine($"{testNumber} є числом Фібоначчі? {isFibonacci(testNumber)}");

        Console.WriteLine();

        // === Func делегати ===
        Func<double, double, double, double> triangleArea = (a, b, c) =>
        {
            double s = (a + b + c) / 2;
            return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
        };

        Func<double, double, double> rectangleArea = (length, width) => length * width;

        // Виклик Func-методів
        Console.WriteLine($"Площа трикутника зі сторонами 3, 4, 5: {triangleArea(3, 4, 5)}");
        Console.WriteLine($"Площа прямокутника зі сторонами 5 і 6: {rectangleArea(5, 6)}");
    }
}
