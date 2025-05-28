namespace lab8._3
{
    class Program
    {
        static void Main()
        {
            int[] numbers = { -5, 0, 7, 14, 21, 3, 8, 256 };
            string text = "Сьогдні день програміста, лямбда!";
            string[] searchWords = { " лямбда", "виняток", "валіза" };

            NumberAnalyzer analyzer = new NumberAnalyzer(numbers);
            Console.WriteLine($"Кратних 7: {analyzer.CountMultiplesOfSeven()}");
            Console.WriteLine($"Позитиних чисел: {analyzer.CountPositiveNumbers()}");

            DateChecker dateChecker = new DateChecker();
            Console.WriteLine($"256 - день програміста? {dateChecker.IsProgrammersDay(256)}");

            TextAnalyzer textAnalyzer = new TextAnalyzer(text);
            Console.WriteLine($"Чи містить слово програміста ? {textAnalyzer.ContainsWord("програміста")}");
            Console.WriteLine($"Чи містить хоча б одне зі слів ? {textAnalyzer.ContainsAnyWords(searchWords)}");
        }
    }
}