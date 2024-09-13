using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceAndAbstractClass {

    /*Customer adalah regular class yang mewariskan sifat IPerson, karena semua customer adalah Person.*/
    public class Customer : IPerson {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public string IDCardNumber { get; set; }
        public string Citizenship { get; set; }
        public string MaritalStatus { get; set; }

        public string MemberCode { get; set; }
        public decimal Balance { get; set; }

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

        public void PrintMemberInformation() {
            Console.WriteLine("Member with code: {0}, still has {1}", this.MemberCode, this.Balance);
        }
    }
}
