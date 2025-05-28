using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    public class PostgraduateStudent : Student
    {
        public string SupervisorName { get; set; }
        public string StudyForm { get; set; }

        public PostgraduateStudent(string fullName, string major, int admissionYear, double averageGrade,
                                   string supervisorName, string studyForm)
            : base(fullName, major, admissionYear, averageGrade)
        {
            SupervisorName = supervisorName;
            StudyForm = studyForm;
        }

        public void UpdateSupervisor(string newSupervisor) => SupervisorName = newSupervisor;
        public void UpdateStudyForm(string newForm) => StudyForm = newForm;

        public override void UpdateAverageGrade(double newGrade)
        {
            Console.WriteLine($"[Аспірант] Оновлення середнього балу для {FullName}");
            base.UpdateAverageGrade(newGrade);
        }

        public override string ToString()
        {
            return base.ToString() + $", Науковий керівник: {SupervisorName}, Форма навчання: {StudyForm}";
        }

        public override bool Equals(object obj)
        {
            if (obj is PostgraduateStudent other)
            {
                return base.Equals(other) &&
                       SupervisorName == other.SupervisorName &&
                       StudyForm == other.StudyForm;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), SupervisorName, StudyForm);
        }
    }
}
