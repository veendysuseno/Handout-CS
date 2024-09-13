using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExternalProject; //Menggunakan using Namespace lain untuk menggunakan assembly yang lain.
using Seller = AssemblyAndNamespace.Internal.CompanySeller; //Kita bisa menggunakan using dengan alias seperti di sini.

//Menggunakan Static Import untuk langsung meng-import static class, sehingga bisa langsung menggunakan property dan methodnya.
using static System.Console;
using static System.Convert;
using static ExternalProject.Sample;

namespace AssemblyAndNamespace {
    class Program {
        static void Main(string[] args) {
            Customer customer = new Customer();
            RemoteSystem.Item item = new RemoteSystem.Item(); //Tanpa menggunakan using

            /* 
             * RemoteSystem dan ExternalProject merupakan assembly atau project di luar project AssemblyAndNameSpace, tetapi masih berada di dalam satu solution.
             * Pada akhirnya semua akan di deploy menjadi CLR dan terhubung satu sama lain dalam dll Dynamic-link Library.
             */

            //Menggunakan WriteLine dan ToDecimal tanpa static class Console dan Convert
            WriteLine("Menggunakan writeline tanpa menggunakan static console");
            decimal bilanganDecimal = ToDecimal(34.56);
            PrintSampleText();

            Seller alex = new Seller {
                Name = "Alexander",
                Level = "Manager"
            };
        }
    }
}
