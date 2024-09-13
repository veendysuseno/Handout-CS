using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceAndAbstractClass {

    /*
     * Tax Resident adalah semua orang baik warga negara, ataupun penduduk yang wajib bayar pajak.
     * Tax Resident mendapat semua trait dari citizen, resident dan person
     */

    public class TaxResident : ICitizen, IResident {

        public string VisaStatus { get; set; }
        public string TaxFileNumber { get; set; }
        public DateTime VisaGrantTime { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public string IDCardNumber { get; set; }
        public string Citizenship { get; set; }
        public string MaritalStatus { get; set; }
        public bool CitizenMedicalInsuranceShipProgram { get; set; }
        public bool CitizenshipLifeInsuranceProgram { get; set; }
        public bool CitizenshipRetirementProgram { get; set; }

        //Ini hanya contoh, tetapi pada dasarnya kalau ini semua satu aplikasi, ini contoh yang tidak baik, karena double code dengan Customer
        public int CalculateAge() {
            int age = DateTime.Today.Year - this.BirthDate.Year;
            return age;
        }

        public void PrintBiodata() {
            string fullName = String.Format("{0} {1}", this.FirstName, this.LastName);
            Console.WriteLine("Nama dari orang ini {0}, Jenis Kelamin {1}, Status Pernikahan {2}", fullName, this.Gender, this.MaritalStatus);
        }

        public void PrintPersonIdentity() {
            Console.WriteLine("Nomor Kartu Identitas {0}, Kewarganegaraan {1}", this.IDCardNumber, this.Citizenship);
        }

        public void PayTax() {
            double taxPercentage = 5;
            if (CitizenMedicalInsuranceShipProgram == true) {
                taxPercentage += 5;
            }
            if (CitizenshipLifeInsuranceProgram == true) {
                taxPercentage += 5;
            }
            if (CitizenshipRetirementProgram == true) {
                taxPercentage += 5;
            }
            Console.WriteLine("Total percentage of tax is {0}%, paid by {1}", taxPercentage, this.VisaStatus);
        }

        public void ResidencyInformation() {
            Console.WriteLine("{0} grant a {1}, on {2}", this.FirstName, this.VisaStatus, this.VisaGrantTime);
        }
    }
}
