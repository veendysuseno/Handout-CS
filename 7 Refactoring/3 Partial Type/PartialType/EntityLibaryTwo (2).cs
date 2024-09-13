using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartialType {
    public partial class Employee {
        public decimal Salary { get; set; }
        public string BirthCountry { get; set; }
        public string BirthCity { get; set; }

        public void PrintSalary() {
            Console.WriteLine("Gaji karyawan: {0}", this.Salary.ToString("C2", CultureInfo.CreateSpecificCulture("id-ID")));
        }

        public void PrintName() {
            Console.WriteLine("Nama karyawan: {0} {1}", this.FirstName, this.LastName);
        }

        partial void CalculateBonus(decimal bonusPercentage) {
            decimal totalBonus = bonusPercentage * this.Salary;
            Console.WriteLine("Total bonus adalah: {0}", totalBonus.ToString("C2", CultureInfo.CreateSpecificCulture("id-ID")));
        }
    }

    public partial struct Assignment {
        public void PrintAssignmentInformation() {
            Console.WriteLine("Pekerjaannya: {0} di department {1}", this.JobTitle, this.Department);
        }

        public void PrintAllJobDescription() {
            foreach (string jobDesc in this.JobDescription) {
                Console.WriteLine(jobDesc);
            }
        }
    }

    public partial interface IPerson {
        DateTime BirthDate { get; set; }
        string BirthPlace { get; set; }
        string IDCardNumber { get; set; }
    }

    public partial class Customer : IResident {
        public string VisaStatus { get; set; }
        public string TaxFileNumber { get; set; }
        public DateTime VisaGrantTime { get; set; }
    }

}
