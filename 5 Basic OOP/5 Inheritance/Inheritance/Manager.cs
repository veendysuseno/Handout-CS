using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance {
    public class Manager : Employee {
        public double BonusPercentage { get; set; }
        public string ManagerType { get; set; }
        public string Branch { get; set; }
        public List<Employee> Subordinates { get; set; }

        //Base keyword, digunakan pada consturctor untuk menginherit constructor parentnya
        public Manager():base() {
        }

        public Manager(string name, DateTime birthDate, string birthPlace, string gender, string identityCardNumber, string employeeNIK, string department, int grade, decimal salary, DateTime hiredDate,
            double bonusPercentage, string managerType, string branch, List<Employee> subordinates)
            : base(name, birthDate, birthPlace, gender, identityCardNumber, employeeNIK, department, grade, salary, hiredDate) {
            this.BonusPercentage = bonusPercentage;
            this.ManagerType = managerType;
            this.Branch = branch;
            this.Subordinates = subordinates;
        }

        public Manager(string name, DateTime birthDate, string birthPlace, string gender, string identityCardNumber, string religion, char bloodType, int height, double weight, string citizenship, string employeeNIK, string department, int grade, decimal salary, DateTime hiredDate,
           double bonusPercentage, string managerType, string branch, List<Employee> subordinates)
           : base(name, birthDate, birthPlace, gender, identityCardNumber, religion, bloodType, height, weight, citizenship, employeeNIK, department, grade, salary, hiredDate) {
            this.BonusPercentage = bonusPercentage;
            this.ManagerType = managerType;
            this.Branch = branch;
            this.Subordinates = subordinates;
        }

        public decimal CalculateAnnualBonus() {
            decimal percentage = Convert.ToDecimal(this.BonusPercentage);
            decimal salary = this.Salary;
            decimal annualBonus = percentage * 12 * salary;
            return annualBonus;
        }

        public void PrintManagerialInfo() {
            string managerialInfo = String.Format("He/She is {0} of {1}.", this.ManagerType, this.Branch);
            Console.WriteLine(managerialInfo);
        }

        //Overriding method adalah proses dimana class yang menurunkan menggunakan method yang sama, pada saat object manager dibuat, method dengan signature yang sama akan di replace.

        /*
         * Menggunakan kata "new", sehingga tidak mengakibatkan warning dan confusion.
         * Penggunaan kata new ini disebut juga dengan teknik Method Hiding.
         */
        public new void PrintEmployeeInfo() {
            string printInformation = String.Format("Manager NIK: {0}\nDepartment: {1}\nGrade : {2}", this.EmployeeNIK, this.Department, this.Grade);
            Console.WriteLine(printInformation);
        }

    }
}
