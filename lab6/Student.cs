using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    public class Student
    {
        public string FullName { get; set; }
        public string Major { get; set; }
        public int AdmissionYear { get; set; }
        public double AverageGrade { get; set; }

        public Student(string fullName, string major, int admissionYear, double averageGrade)
        {
            FullName = fullName;
            Major = major;
            AdmissionYear = admissionYear;
            AverageGrade = averageGrade;
        }

        public void UpdateFullName(string newName) => FullName = newName;
        public void UpdateMajor(string newMajor) => Major = newMajor;
        public void UpdateAdmissionYear(int newYear) => AdmissionYear = newYear;

        public virtual void UpdateAverageGrade(double newGrade) => AverageGrade = newGrade;

        public override string ToString()
        {
            return $"Студент: {FullName}, Напрям: {Major}, Рік вступу: {AdmissionYear}, Середній бал: {AverageGrade}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Student other)
            {
                return FullName == other.FullName &&
                       Major == other.Major &&
                       AdmissionYear == other.AdmissionYear &&
                       AverageGrade == other.AverageGrade;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FullName, Major, AdmissionYear, AverageGrade);
        }
    }
}
