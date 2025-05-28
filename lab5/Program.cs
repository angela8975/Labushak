using lab5task1;

class Program
{
    static void Main()
    {
        Student student = new Student();
        Console.WriteLine("Коротко:");
        Console.WriteLine(student.ToShortString());

        Console.WriteLine($"\nФорма навчання: {student.EducationForm}\n");

        Console.WriteLine("Повна інформація:");
        Console.WriteLine(student);

        Console.WriteLine("\nПісля додавання іспитів:");
        student.AddExams(new Exam(), new Exam());

        foreach (var exam in student.Exams)
            Console.WriteLine(exam);

        Console.WriteLine("\nСтуденти зі стипендією (середній бал >= 85):");
        Student[] group = new Student[5];
        for (int i = 0; i < group.Length; i++)  
            group[i] = new Student();

        foreach (var s in group)
        {
            if(s.AverageMark>=85)
                Console.WriteLine(s.ToShortString());
        }
    }
} 

