using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5task1
{
    public class Student
    {
        private Person person;
        private Education educationForm;
        private int groupNumber;
        private Exam[] exams;

        public Student(Person person, Education educationForm, int groupNumber, Exam[] exams)
        {
            this.person = person;
            this.educationForm = educationForm;
            this.groupNumber = groupNumber;
            this.exams = exams;
        }
        public Student() { 
        
            Random rnd = new Random();
            person = new Person();
            educationForm = (Education)rnd.Next(0,3);    
            groupNumber = rnd.Next(100,200);
            exams = new Exam[] { new Exam(), new Exam() };
        }
        public Person PersonInfo { get => person; set => person = value; }
        public Education EducationForm { get => educationForm; set => educationForm = value; }
        public int GroupNumber
        {
            get => groupNumber;
            set
            {
                if (value<1||value>999) throw new ArgumentException("Недійсний номер групи");
                groupNumber = value; 
            }
        }
        public Exam[] Exams { get => exams; set => exams = value; }

        public double AverageMark
        {
            get
            {
                if(exams.Length == 0) return 0;
                double sum = 0;
                foreach (var exam in exams) sum += exam.Mark;
                return sum/exams.Length;
            }
        }
        public void AddExams (params Exam[] newExams)
        {
            int oldLength = exams.Length;
            Array.Resize(ref exams, oldLength + newExams.Length);
            for (int i = 0; i < newExams.Length; i++)
            {
                exams[oldLength + i] = newExams[i];
            }
        }
        public override string ToString()
        {
            string examInfo;

            if (exams.Length == 0)
            {
                examInfo = "Немає іспитів";
            }
            else
            {
                examInfo = "";
                for (int i = 0; i < exams.Length; i++)
                {
                    examInfo += exams[i].ToString();
                    if (i < exams.Length - 1)
                    {
                        examInfo += "\n  ";
                    }
                }
            }

            return $"{person}, {educationForm}, Група: {groupNumber}\nІспити:\n  {examInfo}";
        }
        public string ToShortString()
        {
            return $"{person.ToShortString()}, {educationForm}, Група: {groupNumber}, Середній бал: { AverageMark:F2}";
        }
    }

}
