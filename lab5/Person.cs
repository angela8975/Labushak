using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5task1
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private DateTime bDate;

        public Person(string firstName, string lastName, DateTime bDate) { 
        
            this.firstName = firstName;
            this.lastName = lastName;   
            this.bDate = bDate;
        }
        public Person()
        {
            Random rnd = new Random();
            string[] names = { "Іван", "Марія", "Олена", "Петро" };
            string[] surnames = { "Шевченко", "Бондар", "Коваль", "Гончар" };
            this.firstName = names[rnd.Next(names.Length)];
            this.lastName = surnames[rnd.Next(surnames.Length)];
            this.bDate = new DateTime(rnd.Next(1990, 2008), rnd.Next(1, 13), rnd.Next(1, 28));

        }
        public string FirstName { get=> firstName; set => firstName = value; }
        public string LastName { get=> lastName; set => lastName = value; }
        public DateTime BDate { get => bDate; set => bDate = value; }
        public int BYear { get => bDate.Year; set => bDate = new DateTime(value, bDate.Month, bDate.Day); }

        public override string ToString() => $"{firstName} {lastName}, {bDate:yyyy.MM.dd}";

        public string ToShortString() => $"{firstName} {lastName}";
       

    }
}
