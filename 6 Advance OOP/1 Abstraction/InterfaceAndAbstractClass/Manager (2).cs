using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceAndAbstractClass {

    /*
     * Manager adalah class yang meng-inherit Employee dan IResident.
     */

    public class Manager : Employee, IResident {

        public string VisaStatus { get; set; }
        public string TaxFileNumber { get; set; }
        public DateTime VisaGrantTime { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public string IDCardNumber { get; set; }
        public string Citizenship { get; set; }
        public string MaritalStatus { get; set; }

        public Manager(string visaStatus, string taxFileNumber, DateTime visaGrantTime, string firstName, string lastName, string gender, DateTime birthDate, string birthPlace, string iDCardNumber, string citizenship, string maritalStatus) {
            VisaStatus = visaStatus;
            TaxFileNumber = taxFileNumber;
            VisaGrantTime = visaGrantTime;
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            BirthDate = birthDate;
            BirthPlace = birthPlace;
            IDCardNumber = iDCardNumber;
            Citizenship = citizenship;
            MaritalStatus = maritalStatus;
        }

        public int CalculateAge() {
            int age = DateTime.Today.Year - this.BirthDate.Year;
            return age;
        }

        public override void EmployeeInformation() {
            Console.WriteLine("The employee number of {0} is {1}, and he/she is start working from {2}", this.FirstName, this.EmployeeNumber, this.HireDate);
        }

        public void PayTax() {
            decimal annualSalary = GetAnnualSalary();
            decimal totalTax;
            if (annualSalary > 40000000) {
                totalTax = 0.1m * annualSalary;
            } else {
                totalTax = 0.05m * annualSalary;
            }
            Console.WriteLine("{0} must pay {1} annually from his/her salary", this.FirstName, totalTax);
        }

        public void PrintBiodata() {
            string fullName = String.Format("{0} {1}", this.FirstName, this.LastName);
            Console.WriteLine("Nama dari orang ini {0}, Jenis Kelamin {1}, Status Pernikahan {2}", fullName, this.Gender, this.MaritalStatus);
        }

        public void PrintPersonIdentity() {
            Console.WriteLine("Nomor Kartu Identitas {0}, Kewarganegaraan {1}", this.IDCardNumber, this.Citizenship);
        }

        public void ResidencyInformation() {
            Console.WriteLine("{0} grant a {1}, on {2}", this.FirstName, this.VisaStatus, this.VisaGrantTime);
        }
    }
}
