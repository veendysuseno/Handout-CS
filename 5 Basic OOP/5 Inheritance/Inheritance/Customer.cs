using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance {
    public class Customer : Person {
        public string CustomerNumber { get; set; }
        public decimal Balance { get; set; }
        public decimal Voucher { get; set; }
        public DateTime RegisterationDate { get; set; }

        //Base keyword, digunakan pada consturctor untuk menginherit constructor parentnya
        public Customer():base() {
        }

        public Customer(string name, DateTime birthDate, string birthPlace, string gender, string identityCardNumber,
            string customerNumber, decimal balance, decimal voucher, DateTime registerationDate)
            : base(name, birthDate, birthPlace, gender, identityCardNumber) {
            this.CustomerNumber = customerNumber;
            this.Balance = balance;
            this.Voucher = voucher;
            this.RegisterationDate = registerationDate;
        }

        public Customer(string name, DateTime birthDate, string birthPlace, string gender, string identityCardNumber, string religion, char bloodType, int height, double weight, string citizenship,
            string customerNumber, decimal balance, decimal voucher, DateTime registerationDate)
            : base(name, birthDate, birthPlace, gender, identityCardNumber, religion, bloodType, height, weight, citizenship) {
            this.CustomerNumber = customerNumber;
            this.Balance = balance;
            this.Voucher = voucher;
            this.RegisterationDate = registerationDate;
        }

        public void PrintCustomerInfo() {
            string registerationDate = this.RegisterationDate.ToShortDateString();
            string balance = this.Balance.ToString();
            string voucher = this.Voucher.ToString();
            Console.WriteLine("Customer Number: {0}\nBalance: {1}\nVoucher: {2}\nRegisteration: {3}", this.CustomerNumber, balance, voucher, registerationDate);
        }
    }
}
