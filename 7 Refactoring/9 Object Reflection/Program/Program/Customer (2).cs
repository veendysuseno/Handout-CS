using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace Program
{
    public class Customer : Stakeholder
    {
        public decimal Balance { get; set; }
        public Customer() : base() {
        }
        public Customer(string name, DateTime birthDate, string companyName, decimal balance) : base(name, birthDate, companyName) {
            this.Balance = balance;
        }
        public void CheckBalance() {
            Console.WriteLine($"Balance is: {this.Balance.ToString("C", CultureInfo.CreateSpecificCulture("id-ID"))}");
        }
        public decimal TransferMoneyTo(decimal total, string destination) {
            this.Balance -= total;
            Console.WriteLine($"Transfer {total} to {destination}, Current Balance: {this.Balance.ToString("C", CultureInfo.CreateSpecificCulture("id-ID"))}");
            return this.Balance;
        }
    }
}
