using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation {
    class Program {
        static void Main(string[] args) {

            //Public : Dapat di akses oleh semuanya, baik lain assembly, lain class, dan lain-lain.
            //Private : Hanya bisa diakses oleh class yang sama.
            //Protected : Hanya bisa diakses oleh class yang sama atau yang merupakan keturunannya.
            //Internal : Merupakan default apabila tidak ditulis, bisa diakses dimana saja selama berada di dalam satu assembly.
            //Protected Internal : atau bisa dibilan (Protected || Internal) Protected dengan alternatif internal.

            //Hanya Public dan Internal yang bisa digunakan pada Class atau Struct atau component yang berada tepat dibawah assembly

            /*
             * Mecoba memakai semua fungsi Resident dan Salesman
             */
            var salesman = new Salesman();
            var publicSalesmanProperty = salesman.PublicSalesmanProperty;
            salesman.PublicSalesmanMethod();
            //Tidak bisa akses private property dan method dari Salesman
            //Tidak bisa akses protected property dan method dari Salesman
            var internalSalesmanProperty = salesman.InternalSalesmanProperty;
            salesman.InternalSalesmanMethod();
            var protectedInternalSalesmanProperty = salesman.ProtectedInternalSalesmanProperty;
            salesman.ProtectedInternalSalesmanMethod();
            salesman.UsingMethodOfResident();

        }
    }
}
