using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ClassLibrary
{
    public class Manager : Employee
    {
        public decimal Bonus { get; set; }
        public List<Staff> Subordinates { get; set; }
        public Manager() {
        }
        public Manager(string fullName, DateTime birthDate, string gender, string employeeNumber, DateTime hireDate, decimal salary, decimal bonus) : 
            base(fullName, birthDate, gender, employeeNumber, hireDate, salary) {
            this.Bonus = bonus;
        }
        public void PaymentSlip() {
            var takeHomePay = this.Salary * (1 - (this.Bonus / 100));
            Console.WriteLine($"Take Home Pay: {takeHomePay.ToString("C", CultureInfo.CreateSpecificCulture("id-ID"))}");
        }
    }
}
