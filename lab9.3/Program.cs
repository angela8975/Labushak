namespace lab9._3
{
    
    class Program
    {
        static SongCollection collection = new();

        static void Main()
        {
            while (true)
            {
                Console.WriteLine("\n1. Додати пісню");
                Console.WriteLine("2. Видалити пісню");
                Console.WriteLine("3. Редагувати пісню");
                Console.WriteLine("4. Пошук пісні за виконавцем");
                Console.WriteLine("5. Показати всі пісні");
                Console.WriteLine("6. Зберегти у файл");
                Console.WriteLine("7. Завантажити з файлу");
                Console.WriteLine("8. Вихід");
                Console.Write("Вибір: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        collection.AddSong(CreateSongFromInput());
                        break;
                    case "2":
                        Console.Write("Введіть назву пісні для видалення: ");
                        var titleToDelete = Console.ReadLine();
                        if (collection.RemoveSong(titleToDelete))
                            Console.WriteLine("Пісню видалено.");
                        else Console.WriteLine("Пісню не знайдено.");
                        break;
                    case "3":
                        Console.Write("Назва пісні для редагування: ");
                        var titleToEdit = Console.ReadLine();
                        var newSong = CreateSongFromInput();
                        if (collection.EditSong(titleToEdit, newSong))
                            Console.WriteLine("Пісню оновлено.");
                        else Console.WriteLine("Пісню не знайдено.");
                        break;
                    case "4":
                        Console.Write("Ім'я виконавця: ");
                        var performer = Console.ReadLine();
                        var results = collection.SearchByPerformer(performer);
                        foreach (var song in results) Console.WriteLine(song + "\n");
                        if (results.Count == 0) Console.WriteLine("Нічого не знайдено.");
                        break;
                    case "5":
                        foreach (var song in collection.Songs)
                            Console.WriteLine(song + "\n");
                        break;
                    case "6":
                        collection.SaveToFile("songs.json");
                        Console.WriteLine("Колекцію збережено.");
                        break;
                    case "7":
                        collection.LoadFromFile("songs.json");
                        Console.WriteLine("Колекцію завантажено.");
                        break;
                    case "8":
                        return;
                    default:
                        Console.WriteLine("Невірний вибір.");
                        break;
                }
            }
        }

        static Song CreateSongFromInput()
        {
            Console.Write("Назва: ");
            string title = Console.ReadLine();
            Console.Write("Автор (П.І.Б.): ");
            string author = Console.ReadLine();
            Console.Write("Композитор: ");
            string composer = Console.ReadLine();
            Console.Write("Рік написання: ");
            int year = int.Parse(Console.ReadLine());
            Console.Write("Текст пісні: ");
            string lyrics = Console.ReadLine();
            Console.Write("Виконавці (через кому): ");
            string[] performers = Console.ReadLine().Split(',');

            return new Song
            {
                Title = title,
                Author = author,
                Composer = composer,
                Year = year,
                Lyrics = lyrics,
                Performers = Array.ConvertAll(performers, p => p.Trim())
            };
        }
    }

}
