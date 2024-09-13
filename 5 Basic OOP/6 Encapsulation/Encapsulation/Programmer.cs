
using External;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation {
    public class Programmer : Citizen {
        //tidak bisa meng inherit Employee karena employee adalah internal
        public string PublicProgrammerProperty { get; set; }
        private string PrivateProgrammerProperty { get; set; }
        protected string ProtectedProgrammerProperty { get; set; }
        internal string InternalProgrammerProperty { get; set; }
        protected internal string ProtectedInternalProgrammerProperty { get; set; }

        public void PublicProgrammerMethod() {
            Console.WriteLine("Public Programmer Method");
        }

        private void PrivateProgrammerMethod() {
            Console.WriteLine("Private Programmer Method");
        }

        protected void ProtectedProgrammerMethod() {
            Console.WriteLine("Protected Programmer Method");
        }

        internal void InternalProgrammerMethod() {
            Console.WriteLine("Internal Programmer Method");
        }

        protected internal void ProtectedInternalProgrammerMethod() {
            Console.WriteLine("Protected Internal Programmer Method");
        }

        //Menggunakan member dari citizen
        public void UsingPropertyOfCitizen() {
            var publicCitizenProperty = PublicCitizenProperty;
            var protectedCitizenProperty = ProtectedCitizenProperty;
            //Tidak bisa akses yang private
            //Tidak bisa akses yang internal
            var protectedInternalCitizenProperty = ProtectedInternalCitizenProperty;
        }

        public void UsingMethodOfCitizen() {
            PublicCitizenMethod();
            //Tidak bisa akses yang private
            ProtectedCitizenMethod();
            //Tidak bisa akses yang internal
            ProtectedInternalCitizenMethod();
        }
    }
}
