using System.Text.RegularExpressions;

namespace lab9
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введіть шлях до файлу:");
            string path = Console.ReadLine();
            if (File.Exists(path))
            {
                string text = File.ReadAllText(path);
                //Підрахунок кількості речень за розділовими знаками 
                int sentenseCount = Regex.Matches(text, @"[.!?]+").Count;
                //Кількість велких літер 
                int upperCount = text.Count(char.IsUpper);
                //Кількість малих літер
                int lowerCount = text.Count(char.IsLower);
                //Голосні літери 
                string vowelsList = "аеєиіїоуюяaeiouAEIOUАЕЄИІЇОУЮЯ";
                int vowelCount = text.Count(c => vowelsList.Contains(c));
                // Приголосні
                int consonantCount = text.Count(c => char.IsLetter(c) && !vowelsList.Contains(c));
                //Кількість цифр
                int digitCount = text.Count(char.IsDigit);

                Console.WriteLine($"Кількості речень: {sentenseCount}");
                Console.WriteLine($"Кількість великих літер: {upperCount}");
                Console.WriteLine($"Кількість малих літер: {lowerCount}");
                Console.WriteLine($"Кількість голосних літер: {vowelCount}");
                Console.WriteLine($"Кількість приголосних літер: {consonantCount}");
                Console.WriteLine($"Кількість цифр: {digitCount}");
            }
            else
            {
                Console.WriteLine("File doesnt exists");
            }

        }
    }
}
