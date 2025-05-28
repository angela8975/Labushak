namespace lab8._2 {
    class Program
    {
        static void Main()
        {
            Suitcase suitcase = new Suitcase("Чорна", "TravelPro", 4.2, 30, new Item[100], 0);
            suitcase.OnItemAdded += item =>
            {
                Console.WriteLine($"Додано {item.Name}, Об'єм {item.Volume}");

            };
            try
            {
                suitcase.AddItem(new Item("Книга", 5));
                suitcase.AddItem(new Item("Ноутбук", 10));
                suitcase.AddItem(new Item("Одяг", 15));
                suitcase.AddItem(new Item("Пляшка", 2));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Помилка:" + ex.Message);
            }
            Console.WriteLine("\n=======Вміст валізи=========");
            Item[] contents = suitcase._Contents;
            for (int i = 0; i < contents.Length; i++)
            {
                Console.WriteLine($"{i + 1}.{contents[i].Name}- об'єм: {contents[i].Volume} ");
            }
            Console.WriteLine($"Загальний зайнятий об'єм : {suitcase.CurrentVolume}/{suitcase._MaxVolume}");

        }
    }

}
