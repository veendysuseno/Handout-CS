using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesToEventHandler {
    public class Customer {
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public Customer(string fullName, string emailAddress, string phoneNumber) {
            this.FullName = fullName;
            this.EmailAddress = emailAddress;
            this.PhoneNumber = phoneNumber;
        }
    }
}
