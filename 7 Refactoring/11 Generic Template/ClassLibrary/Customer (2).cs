using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Customer : Stakeholder
    {
        public string DeliveryAddress { get; set; }
        public Customer() {
        }
        public Customer(string fullName, DateTime birthDate, string gender, string company, string business, string deliveryAddress) : 
            base(fullName, birthDate, gender, company, business) {
            this.DeliveryAddress = deliveryAddress;
        }
        public void SendTo() {
            Console.WriteLine($"Send to {this.FullName}, in {this.DeliveryAddress} ({this.Company})");
        }
    }
}
