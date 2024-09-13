using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace ClassLibrary
{
    public class Staff : Employee
    {
        public decimal Allowance { get; set; }
        public Staff() {
        }
        public Staff(string fullName, DateTime birthDate, string gender, string employeeNumber, DateTime hireDate, decimal salary, decimal allowance) : 
            base(fullName, birthDate, gender, employeeNumber, hireDate, salary) {
            this.Allowance = allowance;
        }
        public void PaymentSlip() {
            var takeHomePay = this.Salary + this.Allowance;
            Console.WriteLine($"Take Home Pay: {takeHomePay.ToString("C", CultureInfo.CreateSpecificCulture("id-ID"))}");
        }
    }
}
