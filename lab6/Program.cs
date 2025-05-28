namespace lab6
{
    class Program
    {
        static void Main()
        {
            Student[] students = new Student[3];

            students[0] = new Student("Іваненко Олена", "Інформатика", 2022, 89.5);
            students[1] = new PostgraduateStudent("Петренко Сергій", "Математика", 2020, 91.0, "д-р наук Сидоренко", "денна");
            students[2] = new PostgraduateStudent("Коваль Анна", "Фізика", 2021, 88.0, "канд. наук Шевченко", "заочна");

            Console.WriteLine("Інформація про студентів:\n");

            foreach (var student in students)
            {
                Console.WriteLine(student.ToString());
            }

            Console.WriteLine("\nТест оновлення балів:\n");
            students[1].UpdateAverageGrade(93.2);

            Console.WriteLine(students[1].ToString());
        }
    }
}
