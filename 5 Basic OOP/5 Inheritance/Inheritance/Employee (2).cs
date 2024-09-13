using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance {
    public class Employee : Person {
        public string EmployeeNIK { get; set; }
        public string Department { get; set; }
        public int Grade { get; set; }
        public decimal Salary { get; set; }
        public DateTime HiredDate { get; set; }

        //Base keyword, digunakan pada consturctor untuk menginherit constructor parentnya
        public Employee() : base() {

        }

        public Employee(string name, DateTime birthDate, string birthPlace, string gender, string identityCardNumber,
            string employeeNIK, string department, int grade, decimal salary, DateTime hiredDate)
            : base(name, birthDate, birthPlace, gender, identityCardNumber) {
            this.EmployeeNIK = employeeNIK;
            this.Department = department;
            this.Grade = grade;
            this.Salary = salary;
            this.HiredDate = hiredDate;
        }

        public Employee(string name, DateTime birthDate, string birthPlace, string gender, string identityCardNumber, string religion, char bloodType, int height, double weight, string citizenship,
           string employeeNIK, string department, int grade, decimal salary, DateTime hiredDate)
           : base(name, birthDate, birthPlace, gender, identityCardNumber, religion, bloodType, height, weight, citizenship) {
            this.EmployeeNIK = employeeNIK;
            this.Department = department;
            this.Grade = grade;
            this.Salary = salary;
            this.HiredDate = hiredDate;
        }

        public void PrintEmployeeInfo() {
            string printInformation = String.Format("Employee NIK: {0}\nDepartment: {1}\nGrade : {2}", this.EmployeeNIK, this.Department, this.Grade);
            Console.WriteLine(printInformation);
        }

        public int WorkingDurationInYears() {
            DateTime today = DateTime.Today;
            DateTime hiredDate = HiredDate;
            int duration = today.Year - hiredDate.Year;
            return duration;
        }

        public decimal AnnualSalary() {
            decimal annualSalary = 12 * this.Salary;
            return annualSalary;
        }

    }
}
