namespace task3
{
    internal class Program
    {
        
        static int CountAnswer(string[] q, int[] answer)
        {
            int score = 0;
            for(int i=0; i < q.Length; ++i)
            {
                Console.WriteLine(q[i]);
                Console.Write("Відповідь: ");
                if (int.TryParse(Console.ReadLine(), out int useranswer) && useranswer == answer[i])
                {
                    score++;
                }
            }
            return score;
        }
        static void Main()
        {
            string[] q = {
            "Професор ліг спати о 8 годині, а встав о 9 годині. Скільки годин проспав професор?",
            "На двох руках десять пальців. Скільки пальців на 10?",
            "Скільки цифр у дюжині?",
            "Скільки потрібно зробити розпилів, щоб розпиляти колоду на 12 частин?",
            "Лікар зробив три уколи в інтервалі 30 хвилин. Скільки часу він витратив?",
            " Скільки цифр 9 в інтервалі 1100?",
            "Пастух мав 30 овець. Усі, окрім однієї, розбіглися. Скільки овець лишилося?"
            };
            int[] answer = { 1, 50, 2, 11, 30, 1, 1 };

            int score = CountAnswer(q, answer);
            Console.WriteLine($"Ваш результат: {score} балів");
            switch (score)
            {
                case < 2:
                    Console.WriteLine("Вам треба відпочити!");
                    break;
                case <= 3: 
                    Console.WriteLine("Здібності нижче середнього");
                    break;
                case <= 4:
                    Console.WriteLine("Здібності середні");
                    break;
                case <= 5:
                    Console.WriteLine("Нормальний");
                    break;
                case <= 6:
                    Console.WriteLine("Ерудит");
                    break;
                case <= 7:
                    Console.WriteLine("Геній");
                    break;
            }
        }
    }
}
