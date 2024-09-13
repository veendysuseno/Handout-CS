using System;
using System.Collections.Generic;
using System.Text;

namespace Program
{
    public class Supplier : Stakeholder
    {
        public string CompanyAddress { get; set; }
        public Supplier() {
        }
        public Supplier(string name, DateTime birthDate, string companyName, string companyAddress) : base(name, birthDate, companyName) {
            this.CompanyAddress = companyAddress;
        }
        public void SupplierCompanyInfo() {
            Console.WriteLine($"Company: {this.CompanyName}, Address: {this.CompanyAddress}");
        }
    }
}
