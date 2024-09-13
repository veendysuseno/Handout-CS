using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance {
    public class PhdStudent : Student {
        public PhdStudent() : base() {

        }
        public PhdStudent(string name, DateTime birthDate, string birthPlace, string gender, string identityCardNumber,
            string university, string universityLocation, string faculty, DateTime enrollmentDate, int gpa)
            : base(name, birthDate, birthPlace, gender, identityCardNumber, university, universityLocation, faculty, enrollmentDate, gpa) {
        }
        public PhdStudent(string name, DateTime birthDate, string birthPlace, string gender, string identityCardNumber, string religion, char bloodType, int height, double weight, string citizenship,
            string university, string universityLocation, string faculty, DateTime enrollmentDate, int gpa)
            : base(name, birthDate, birthPlace, gender, identityCardNumber, religion, bloodType, height, weight, citizenship, university, universityLocation, faculty, enrollmentDate, gpa) {
        }

        /*
         * Salah satu alternative dari overriding method adalah dengan menggunakan kata "override".
         * Pada saat suatu method ingin di override, method parentnya harus bersifat virtual atau abstract atau override lainnya lagi.
         * Override akan menghasilkan hasil yang berbeda dari new, akan bisa dilihat di Program.cs
         */
        public override void PrintEducationInformation() {
            int semester = GetSemesterOfStudyDuration();
            string educationInfo = String.Format("{0} has research in {1}", this.Name, this.University);
            Console.WriteLine(educationInfo);
        }
    }
}
