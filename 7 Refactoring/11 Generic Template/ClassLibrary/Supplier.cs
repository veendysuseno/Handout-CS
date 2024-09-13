using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Supplier : Stakeholder
    {
        public string ContactJobTitle { get; set; }
        public Supplier() {
        }
        public Supplier(string fullName, DateTime birthDate, string gender, string company, string business, string jobTitle) : 
            base(fullName, birthDate, gender, company, business) {
            this.ContactJobTitle = jobTitle;
        }
        public void SupplierContact() {
            Console.WriteLine($"Hubungi {this.FullName} ({this.ContactJobTitle}) sebagai perwakilan dari {this.Company}");
        }
    }
}
