using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Stakeholder : Person, IStakeholder
    {
        public string Company { get; set; }
        public string Business { get; set; }
        public Stakeholder() {
        }
        public Stakeholder(string fullName, DateTime birthDate, string gender, string company, string business) : base(fullName, birthDate, gender) {
            this.Company = company;
            this.Business = business;
        }
        public void PrintCompanyInfo() {
            Console.WriteLine($"Company: {this.Company}, Business Field: {this.Business}");
        }
    }
}
