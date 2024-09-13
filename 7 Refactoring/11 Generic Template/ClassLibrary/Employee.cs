using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Employee : Person
    {
        public string EmployeeNumber { get; set; }
        public DateTime HireDate { get; set; }
        public decimal Salary { get; set; }
        public Employee() {
        }
        public Employee(string fullName, DateTime birthDate, string gender, string employeeNumber, DateTime hireDate, decimal salary) : base(fullName, birthDate, gender) {
            this.EmployeeNumber = employeeNumber;
            this.HireDate = hireDate;
            this.Salary = salary;
        }
        public void PrintEmployeeInfo() {
            Console.WriteLine($"Employee Number: {this.EmployeeNumber}, Full Name: {this.FullName}");
        }
        public int GetWorkingMonthDuration() {
            var daysDuration = (DateTime.Today - this.HireDate).Days;
            return daysDuration / 30;
        }
    }
}
