using System;
using System.Collections.Generic;
using System.Text;

namespace Program
{
    public class Stakeholder : Person
    {
        public string CompanyName { get; set; }
        protected string GroupCompany { get; set; }
        public Stakeholder() : base() {
        }
        public Stakeholder(string name, DateTime birthDate, string companyName) : base(name, birthDate) {
            this.CompanyName = companyName;
        }
        public void PrintStakeholderInfo() {
            Console.WriteLine($"Company Name: {this.CompanyName}, Contact Name: {this.Name}");
        }

    }
}
