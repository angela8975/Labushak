using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace lab5task1
{
    public class Exam
    {
        public string Subject { get; set; }
        public int Mark {  get; set; }
        public DateTime Date { get; set; }

        public Exam(string subject, int mark, DateTime date)
        {
            Subject = subject;
            Mark = mark;
            Date = date;
        }
        public Exam() {
            string[] subjects = { "Математика", "Фізика", "Програмування", "Англійська" };
            Random rnd = new Random();
            Subject = subjects[rnd.Next(subjects.Length)];
            Mark = rnd.Next(60, 100);
            Date = DateTime.Today.AddDays(-rnd.Next(30,120));
        }
        public override string ToString() => $"{Subject} - {Mark}, {Date:yyyy.MM.dd}";
    }
}
