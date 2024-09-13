using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation {
    public class Resident {
        public string PublicResidentProperty { get; set; }
        private string PrivateResidentProperty { get; set; }
        protected string ProtectedResidentProperty { get; set; }
        internal string InternalResidentProperty { get; set; }
        protected internal string ProtectedInternalResidentProperty { get; set; }

        public void PublicResidentMethod() {
            Console.WriteLine("Public Resident Method");
        }

        private void PrivateResidentMethod() {
            Console.WriteLine("Private Resident Method");
        }

        protected void ProtectedResidentMethod() {
            Console.WriteLine("Protected Resident Method");
        }

        internal void InternalResidentMethod() {
            Console.WriteLine("Internal Resident Method");
        }

        protected internal void ProtectedInternalResidentMethod() {
            Console.WriteLine("Protected Internal Resident Method");
        }
    }
}
