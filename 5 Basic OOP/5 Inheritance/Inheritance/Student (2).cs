using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance {
    public class Student : Person {

        public string University { get; set; }
        public string UniversityLocation { get; set; }
        public string Faculty { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public int GPA { get; set; }

        //Base keyword, digunakan pada consturctor untuk menginherit constructor parentnya
        public Student() : base() {
        }

        public Student(string name, DateTime birthDate, string birthPlace, string gender, string identityCardNumber, 
            string university, string universityLocation, string faculty, DateTime enrollmentDate, int gpa)
            : base(name, birthDate, birthPlace, gender, identityCardNumber) {
            this.University = university;
            this.UniversityLocation = universityLocation;
            this.Faculty = faculty;
            this.EnrollmentDate = enrollmentDate;
            this.GPA = GPA;
        }

        public Student(string name, DateTime birthDate, string birthPlace, string gender, string identityCardNumber, string religion, char bloodType, int height, double weight, string citizenship,
            string university, string universityLocation, string faculty, DateTime enrollmentDate, int gpa)
            : base(name, birthDate, birthPlace, gender, identityCardNumber, religion, bloodType, height, weight, citizenship) {
            this.University = university;
            this.UniversityLocation = universityLocation;
            this.Faculty = faculty;
            this.EnrollmentDate = enrollmentDate;
            this.GPA = GPA;
        }

        public int GetYearsOfStudyDuration() {
            DateTime today = DateTime.Today;
            DateTime enrollmentDate = EnrollmentDate;
            int age = today.Year - enrollmentDate.Year;
            return age;
        }

        public int GetSemesterOfStudyDuration() {
            int semester = GetYearsOfStudyDuration() / 2;
            return semester;
        }

        public virtual void PrintEducationInformation() {
            int semester = GetSemesterOfStudyDuration();
            string educationInfo = String.Format("{0} is study in {1} on Semester {2}", this.Name, this.University, semester);
            Console.WriteLine(educationInfo);
        }
    }
}
