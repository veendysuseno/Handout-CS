using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance {

    /*
     * Sealed Class adalah class yang tidak bisa di inherit.
     * Sealed Class berguna untuk menceritakan developer lain kalau class ini tidak boleh di inherit.
     * Keuntungan lain dari sealed class adalah, class ini memiliki performance yang sedikit lebih cepat dari regular class, karena CLR tidak akan melakukan check proses apakan class ini akan diinherit atau tidak.
     */

    public sealed class SealedPerson {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public string Gender { get; set; }
        public string IdentityCardNumber { get; set; }
        public string Religion { get; set; }
        public char BloodType { get; set; }
        public int Height { get; set; }
        public double Weight { get; set; }
        public string Citizenship { get; set; }

        public SealedPerson() {

        }

        public SealedPerson(string name, DateTime birthDate, string birthPlace, string gender, string identityCardNumber) {
            this.Name = name;
            this.BirthDate = birthDate;
            this.BirthPlace = birthPlace;
            this.Gender = gender;
            this.IdentityCardNumber = identityCardNumber;
        }

        public SealedPerson(string name, DateTime birthDate, string birthPlace, string gender, string identityCardNumber, string religion, char bloodType, int height, double weight, string citizenship) {
            this.Name = name;
            this.BirthDate = birthDate;
            this.BirthPlace = birthPlace;
            this.Gender = gender;
            this.IdentityCardNumber = identityCardNumber;
            this.Religion = religion;
            this.BloodType = bloodType;
            this.Height = height;
            this.Weight = weight;
            this.Citizenship = citizenship;
        }

        public void PrintPersonalInformation() {
            string birthDate = this.BirthDate.ToShortDateString();
            string bloodType = this.BloodType.ToString();
            string height = this.Height.ToString();
            string weight = this.Weight.ToString();
            string completeInformation = String.Format(
                "Nama: {0}\nBirth Date: {1}\nBirth Place: {2}\nGender: {3}\nIdentity Card: {4}\nReligion: {5}\nBlood Type: {6}\nHeight: {7}\nWeight: {8}\nCitizenship: {9}",
                this.Name, birthDate, this.BirthPlace, this.Gender, this.IdentityCardNumber, this.Religion, bloodType, height, weight, this.Citizenship);
            Console.WriteLine(completeInformation); ;
        }

        public int CalculateAge() {
            DateTime today = DateTime.Today;
            DateTime birthDate = this.BirthDate;
            int age = today.Year - birthDate.Year;
            if (birthDate > today.AddYears(-age)) {
                age -= 1;
            }
            return age;
        }

    }
}
