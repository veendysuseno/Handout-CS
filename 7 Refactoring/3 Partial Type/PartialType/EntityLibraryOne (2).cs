using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartialType {

    public partial class Employee {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        public string GetCompleteName() {
            return String.Format("{0} {1}", this.FirstName, this.LastName);
        }

        public void PrintBirthPlace() {
            Console.WriteLine("Tempat lahir karyawan adalah: {0}, {1}", this.BirthCity, this.BirthCountry);
        }

        public void PrintBirthDate() {
            Console.WriteLine("Tanggal lahir: {0}", this.BirthDate.ToShortDateString());
        }

        /*
         * Partial Method: adalah deklarasi method signature (kombinasi nama dan parameter, check lagi pelajaran function overload) di satu partial class dan implementasinya di partial yang lain.
         * 
         * Persyaratan dari partial method:
         * 1. Signature di kedua method harus sama.
         * 2. Method harus dengan tipe void
         * 3. Tidak ada penulisan access modifiers, itu karena semua partial method HARUS PRIVATE.
         * 
         * Partial method tidak memaksa seperti abstract method pada interface atau abstract class, method template dari partial method bisa dipakai bisa juga tidak.
         * Apabila tidak dipakai oleh programmer, partial method akan dihapus pada saat convert ke CLR.
         * 
         * Kegunaan dari partial method sendiri hampir mirip dengan kegunaan pada event dan delegate, yaitu sebagai method hook.
         */

        partial void CalculateBonus(decimal bonusPercentage);//deklarasi

        public void PrintBonus(decimal bonusPercentage) {
            Console.WriteLine("Total bonus sebesar: {0}", bonusPercentage.ToString("P2"));
            CalculateBonus(bonusPercentage);
        }
    }

    /*
     * Partial Struct hampir mirip seperti partial class, hanya saja property member dari partial struct akan mengakibatkan warning message apabila dipisah-pisahkan dari 
     * satu partial ke partial lainnya.
     */
    public partial struct Assignment {
        public string Department { get; set; }
        public string JobTitle { get; set; }
        public List<string> JobDescription { get; set; }
        public string Superior { get; set; }
    }

    //Kombinasi dari partial Interface dan partial class.

    public partial interface IPerson {
        string FirstName { get; set; }
        string LastName { get; set; }
        string Gender { get; set; }
    }

    public partial interface IResident {
        string VisaStatus { get; set; }
        string TaxFileNumber { get; set; }
        DateTime VisaGrantTime { get; set; }
    }

    public partial class Customer : IPerson {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public string IDCardNumber { get; set; }
    }

}
