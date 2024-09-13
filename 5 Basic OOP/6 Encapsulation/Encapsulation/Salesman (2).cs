using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation {
    public class Salesman : Resident {
        public string PublicSalesmanProperty { get; set; }
        private string PrivateSalesmanProperty { get; set; }
        protected string ProtectedSalesmanProperty { get; set; }
        internal string InternalSalesmanProperty { get; set; }
        protected internal string ProtectedInternalSalesmanProperty { get; set; }

        public void PublicSalesmanMethod() {
            Console.WriteLine("Public Resident Method");
        }

        private void PrivateSalesmanMethod() {
            Console.WriteLine("Private Resident Method");
        }

        protected void ProtectedSalesmanMethod() {
            Console.WriteLine("Protected Resident Method");
        }

        internal void InternalSalesmanMethod() {
            Console.WriteLine("Internal Resident Method");
        }

        protected internal void ProtectedInternalSalesmanMethod() {
            Console.WriteLine("Protected Internal Resident Method");
        }

        //Menggunakan member dari Resident

        public void UsingPropertyOfResident() {
            var publicResidentProperty = PublicResidentProperty;
            var protectedResidentProperty = ProtectedResidentProperty;
            //Tidak bisa akses yang private
            var internalResidentProperty = InternalResidentProperty;
            var protectedInternalResidentProperty = ProtectedInternalResidentProperty;
        }

        public void UsingMethodOfResident() {
            PublicResidentMethod();
            //Tidak bisa akses yang private
            ProtectedResidentMethod();
            InternalResidentMethod();
            ProtectedInternalResidentMethod();
        }
    }
}
