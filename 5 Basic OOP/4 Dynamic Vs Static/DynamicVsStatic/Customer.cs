using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicVsStatic {
    public class Customer {

        //Static member in Dynamic (Non-Static) Class

        public string Number { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public static int MaximumVoucher { get; set; }
        public static int MinimumVoucher;

        public Customer() {}

        public Customer(string number, string name, DateTime birthDate) {
            this.Number = number;
            this.Name = name;
            this.BirthDate = birthDate;
        }

        public void PrintCustomerInfo() {
            Console.WriteLine("Customer Number: {0}, Customer Name: {1}, Customer Birth Date: {2}, Max Voucher: {3}, Min Voucher {4}", this.Number, this.Name, this.BirthDate, MaximumVoucher, MinimumVoucher);
        }

        public static void PrintVoucher() {
            Console.WriteLine("Maximum Voucher {0}, Minimum Voucher{1}", MaximumVoucher, MinimumVoucher); // Hanya bisa melakukan aksi ke static field/property
        }

    }
}