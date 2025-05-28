namespace lab4._2
{
    class Program
    {
        static void Main()
        {
            string inputText = "";
            Console.WriteLine("Оберіть джерело тексту:");
            Console.WriteLine("1 – Ввести текст з клавіатури");
            Console.WriteLine("2 – Зчитати текст з файлу");
            Console.Write("Ваш вибір: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.WriteLine("Введіть текст:");
                inputText = Console.ReadLine();
            }
            else if (choice == "2")
            {
                Console.Write("Введіть ім'я файлу (наприклад, input.txt): ");
                string fileName = Console.ReadLine();
                if (File.Exists(fileName))
                {
                    inputText = File.ReadAllText(fileName);
                }
                else
                {
                    Console.WriteLine("Файл не знайдено.");
                    return;
                }
            }
            else
            {
                Console.WriteLine("Невірний вибір.");
                return;
            }

            // Обробка: залишаємо лише слова з латинських літер, без повторюваних символів
            string[] words = inputText.Split(new[] { ' ', '\t', '\n', '\r', ',', '.', ';', ':', '!', '?' },
                                             StringSplitOptions.RemoveEmptyEntries);
            var uniqueLetterWords = words
                .Where(word => word.All(char.IsLetter) && word.All(c => c < 128 && c > 0)) // тільки латинські
                .Where(word =>
                {
                    string lower = word.ToLower();
                    return lower.Distinct().Count() == lower.Length;
                })
                .ToList();

            // Виведення результату
            Console.WriteLine("\nСлова без повторюваних літер:");
            foreach (var word in uniqueLetterWords)
                Console.WriteLine(word);

            // Запис у файл
            File.WriteAllLines("result.txt", uniqueLetterWords);
            Console.WriteLine("\nРезультат збережено у файлі result.txt");
        }
    }
}
