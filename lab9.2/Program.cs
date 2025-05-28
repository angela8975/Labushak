using System.Text.RegularExpressions;

namespace lab9._2
{
    class Program
    {
        static void Main()
        {
            Console.Write("ВВедіть шлях до файлу : ");
            string textPath = Console.ReadLine();

            Console.Write("Введіть шлях до файлу зі словами для цензури: ");
            string wordsPath = Console.ReadLine();

            if (File.Exists(textPath) && File.Exists(wordsPath))
            {
                string text = File.ReadAllText(textPath);
                string[] bannedWords = File.ReadAllLines(wordsPath);

                foreach (string word in bannedWords)
                {
                    string pattern = $@"\b{Regex.Escape(word)}\b";
                    string replacement = new string('*', word.Length);
                    text = Regex.Replace(text, pattern, replacement, RegexOptions.IgnoreCase);

                    string outputPath = "result.txt";
                    File.WriteAllText(outputPath, text);
                    Console.WriteLine($"результат записано у файл: {outputPath}");

                }

            }
            else
            {
                Console.WriteLine("Один аб два файла не знайдено.");
            }


        }
    }
}
