using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lab7
{
    public class Student : IFileContainer<Exam>
    {
        private Person person;
        private Education educationForm;
        private int groupNumber;
        private List<Exam> exams;
        private bool isDataSaved;

        public Student(Person person, Education educationForm, int groupNumber, Exam[] exams)
        {
            this.person = person;
            this.educationForm = educationForm;
            this.groupNumber = groupNumber;
            this.exams = exams?.ToList() ?? new List<Exam>();
            this.isDataSaved = false;
        }

        public Student()
        {
            Random rnd = new Random();
            person = new Person();
            educationForm = (Education)rnd.Next(0, 3);
            groupNumber = rnd.Next(100, 200);
            exams = new List<Exam> { new Exam(), new Exam() };
            isDataSaved = false;
        }

        public Person PersonInfo { get => person; set => person = value; }
        public Education EducationForm { get => educationForm; set => educationForm = value; }

        public int GroupNumber
        {
            get => groupNumber;
            set
            {
                if (value < 1 || value > 999) throw new ArgumentException("Недійсний номер групи");
                groupNumber = value;
            }
        }

        public Exam[] Exams { get => exams.ToArray(); set => exams = value?.ToList() ?? new List<Exam>(); }

        public double AverageMark
        {
            get
            {
                if (exams.Count == 0) return 0;
                return exams.Average(e => e.Mark);
            }
        }

        // Реалізація IContainer<Exam>
        public int Count => exams.Count;

        public object this[int index]
        {
            get
            {
                if (index < 0 || index >= exams.Count)
                    throw new IndexOutOfRangeException("Індекс поза межами масиву");
                return exams[index];
            }
            set
            {
                if (index < 0 || index >= exams.Count)
                    throw new IndexOutOfRangeException("Індекс поза межами масиву");
                if (value is Exam exam)
                {
                    exams[index] = exam;
                    isDataSaved = false;
                }
                else
                    throw new ArgumentException("Значення має бути типу Exam");
            }
        }

        public void Add(Exam element)
        {
            if (element != null)
            {
                exams.Add(element);
                isDataSaved = false;
            }
        }

        public void Delete(Exam element)
        {
            if (exams.Remove(element))
            {
                isDataSaved = false;
            }
        }

        // Реалізація IFileContainer<Exam>
        public bool IsDataSaved => isDataSaved;

        public void Save(string fileName)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(fileName, false, Encoding.UTF8))
                {
                    // Зберігаємо дані студента
                    writer.WriteLine($"{person.FirstName}|{person.LastName}|{person.BDate:yyyy-MM-dd}");
                    writer.WriteLine($"{(int)educationForm}|{groupNumber}");
                    writer.WriteLine(exams.Count);

                    // Зберігаємо іспити
                    foreach (var exam in exams)
                    {
                        writer.WriteLine($"{exam.Subject}|{exam.Mark}|{exam.Date:yyyy-MM-dd}");
                    }
                }
                isDataSaved = true;
            }
            catch (Exception ex)
            {
                throw new IOException($"Помилка при збереженні файлу: {ex.Message}");
            }
        }

        public void Load(string fileName)
        {
            try
            {
                using (StreamReader reader = new StreamReader(fileName, Encoding.UTF8))
                {
                    // Завантажуємо дані студента
                    string[] personData = reader.ReadLine()?.Split('|');
                    if (personData?.Length == 3)
                    {
                        person = new Person(personData[0], personData[1], DateTime.Parse(personData[2]));
                    }

                    string[] studentData = reader.ReadLine()?.Split('|');
                    if (studentData?.Length == 2)
                    {
                        educationForm = (Education)int.Parse(studentData[0]);
                        groupNumber = int.Parse(studentData[1]);
                    }

                    int examCount = int.Parse(reader.ReadLine() ?? "0");
                    exams.Clear();

                    // Завантажуємо іспити
                    for (int i = 0; i < examCount; i++)
                    {
                        string[] examData = reader.ReadLine()?.Split('|');
                        if (examData?.Length == 3)
                        {
                            var exam = new Exam(examData[0], int.Parse(examData[1]), DateTime.Parse(examData[2]));
                            exams.Add(exam);
                        }
                    }
                }
                isDataSaved = true;
            }
            catch (Exception ex)
            {
                throw new IOException($"Помилка при завантаженні файлу: {ex.Message}");
            }
        }

        public void AddExams(params Exam[] newExams)
        {
            foreach (var exam in newExams)
            {
                Add(exam);
            }
        }

        public override string ToString()
        {
            string examInfo = exams.Count == 0 ? "Немає іспитів" :
                string.Join("\n  ", exams.Select(e => e.ToString()));

            return $"{person}, {educationForm}, Група: {groupNumber}\nІспити:\n  {examInfo}";
        }

        public string ToShortString()
        {
            return $"{person.ToShortString()}, {educationForm}, Група: {groupNumber}, Середній бал: {AverageMark:F2}";
        }
    }
}

