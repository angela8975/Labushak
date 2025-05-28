using System;


namespace lab7
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=== Демонстрація роботи з інтерфейсами ===\n");

            Student student = new Student();

            // Створюємо студента
            Console.WriteLine("Початкові дані студента:");
            Console.WriteLine(student.ToShortString());
            Console.WriteLine($"Кількість іспитів: {student.Count}");

            // Демонстрація IContainer
            Console.WriteLine("\n=== Робота з IContainer ===");

            // Додаємо іспит
            Exam newExam = new Exam("Історія", 95, DateTime.Today.AddDays(-10));
            student.Add(newExam);
            Console.WriteLine($"Додали іспит. Кількість іспитів: {student.Count}");

            // Робота з індексатором
            Console.WriteLine($"Перший іспит: {student[0]}");

            // Видаляємо іспит
            student.Delete(newExam);
            Console.WriteLine($"Видалили іспит. Кількість іспитів: {student.Count}");

            // Демонстрація IFileContainer
            Console.WriteLine("\n=== Робота з IFileContainer ===");
            Console.WriteLine($"Дані збережені: {student.IsDataSaved}");

            try
            {
                student.Save("student_data.txt");
                Console.WriteLine($"Збережено у файл. Дані збережені: {student.IsDataSaved}");

                Student loadedStudent = new Student();
                loadedStudent.Load("student_data.txt");
                Console.WriteLine("Завантажено з файлу:");
                Console.WriteLine(loadedStudent.ToShortString());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
            }

            // Демонстрація IComparable
            Console.WriteLine("\n=== Демонстрація IComparable ===");
            Person person1 = new Person("Іван", "Іванов", new DateTime(1995, 5, 15));
            Person person2 = new Person("Марія", "Петрова", new DateTime(1998, 3, 20));

            int comparison = person1.CompareTo(person2);
            Console.WriteLine($"Порівняння осіб (за датою народження): {comparison}");
            Console.WriteLine($"{person1} vs {person2}");

            // Демонстрація ICloneable
            Console.WriteLine("\n=== Демонстрація ICloneable ===");
            Person clonedPerson = (Person)person1.Clone();
            Console.WriteLine($"Оригінал: {person1}");
            Console.WriteLine($"Клон: {clonedPerson}");
            Console.WriteLine($"Це різні об'єкти: {!ReferenceEquals(person1, clonedPerson)}");

            // Тест виключення для індексатора
            Console.WriteLine("\n=== Тест виключення для індексатора ===");
            try
            {
                var invalidExam = student[100]; // Має викликати виключення
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine($"Перехоплено виключення: {ex.Message}");
            }
        }
    }
}
