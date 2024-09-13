using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace External {
    public class Citizen {
        public string PublicCitizenProperty { get; set; }
        private string PrivateCitizenProperty { get; set; }
        protected string ProtectedCitizenProperty { get; set; }
        internal string InternalCitizenProperty { get; set; }
        protected internal string ProtectedInternalCitizenProperty { get; set; }

        public void PublicCitizenMethod() {
            Console.WriteLine("Public Citizen Method");
        }

        private void PrivateCitizenMethod() {
            Console.WriteLine("Private Citizen Method");
        }

        protected void ProtectedCitizenMethod() {
            Console.WriteLine("Protected Citizen Method");
        }

        internal void InternalCitizenMethod() {
            Console.WriteLine("Internal Citizen Method");
        }

        protected internal void ProtectedInternalCitizenMethod() {
            Console.WriteLine("Protected Internal Citizen Method");
        }
    }
}
