using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuplesAndDeconstruction {
    class Program {
        
        /*
         * Tuple adalah upgrade di dalam feature C#7 yang mengijinkan sebuah fungsi mengembalikan lebih dari satu value.
         */
        static void Main(string[] args) {

            List<City> cities = GetAllCities();
            var selectedCity = FindCity("Jakarta", cities);

            //Cara memisahkan tuple
            string name = selectedCity.Item1;
            string countryName = selectedCity.Item2;
            double longitude = selectedCity.Item3;
            double latitude = selectedCity.Item4;
            Console.WriteLine($"name: {name}, country name: {countryName}, longitude: {longitude}, latitude: {latitude}");

            /*
             * Deconstruction adalah cara memisah-misahkan element atau property di dalam sebuah object, bisa dimanfaatkan untuk memisahkan tuple dengan value-valuenya.
             */

            //Cara pertama
            var (namaKota, namaNegara, garisBujur, lintang) = FindCity("Jakarta", cities);
            Console.WriteLine($"nama kota: {namaKota}, nama negara: {namaNegara}, garis bujur: {garisBujur}, lintang: {lintang}");

            //Cara kedua, dengan langsung mendeklarasi tipe datanya
            (string namaKota2, string namaNegara2, double garisBujur2, double lintang2) = FindCity("New York", cities);
            Console.WriteLine($"nama kota: {namaKota2}, nama negara: {namaNegara2}, garis bujur: {garisBujur2}, lintang: {lintang2}");

            //Cara ketiga dengan mendeklarasi variablenya terlebih dahulu.
            string namaKota3;
            string namaNegara3;
            double garisBujur3;
            double lintang3;
            (namaKota3, namaNegara3, garisBujur3, lintang3) = FindCity("Sydney", cities);
            Console.WriteLine($"nama kota: {namaKota3}, nama negara: {namaNegara3}, garis bujur: {garisBujur3}, lintang: {lintang3}");

            //Cara keempat dengan mendeklarasi dengan menggunakan var
            (var namaKota4, var namaNegara4, var garisBujur4, var lintang4) = FindCity("New York", cities);
            Console.WriteLine($"nama kota: {namaKota4}, nama negara: {namaNegara4}, garis bujur: {garisBujur4}, lintang: {lintang4}");

            //Deconstruction tuple ke dalam tipe data class
            var people = GetAllPeople();
            (string namaOrang, Car mobil, City kota) = FindPerson("Susan", people);
            Console.WriteLine($"nama orang: {namaOrang}, model mobil: {mobil.Model}, nama kota: {kota.Name}");

            //Discard value dengan menggunakan _
            var (cityName, _, _, posisiLintang) = FindCity("Jakarta", cities);


            #region Non-Tuple Object Deconstruction

            Employee saiful = new Employee("Saiful", new DateTime(1988, 11, 27), "Jakarta", 12000000m, 35);
            var (namaSaiful, tanggalLahirSaiful, tempatLahirSaiful, gajiSaiful, beratSaiful) = saiful;
            Console.WriteLine($"nama: {namaSaiful}, tanggal lahir: {tanggalLahirSaiful.ToLongDateString()}");

            var solihin = new Employee("Solihin", new DateTime(1988, 9, 25), "Jakarta", 12000000m, 35);
            (string namaSolihin, DateTime tanggalLahirSolihin, string tempatLahirSolihin, decimal gajiSolihin, int beratSolihin) = solihin;
            Console.WriteLine($"nama: {namaSolihin}, tanggal lahir: {tanggalLahirSolihin.ToLongDateString()}");

            var desy = new Employee("Desy", new DateTime(1995, 8, 15), "Jakarta", 12000000m, 35);
            (var namaDesy, var tanggalLahirDesy, var tempatLahirDesy, var gajiDesy, var beratDesy) = desy;
            Console.WriteLine($"nama: {namaDesy}, tanggal lahir: {tanggalLahirDesy.ToLongDateString()}");

            var doni = new {
                Name = "Doni",
                DateOfBirth = new DateTime(1988, 7, 12),
                PlaceOfBirth = "Jakarta"
            };

            //Tidak bisa digunakan untuk anonymous object
            //(var namaDoni, var dateOfBirth, var place) = doni;


            #endregion
        }

        public static List<City> GetAllCities() {
            List<City> cities = new List<City>() {
                new City("New York", "USA", 40.7128, 74.0060),
                new City("Jakarta", "Indonesia", 6.1805, 106.8283),
                new City("Sydney", "Australia", 33.8688, 151.2093)
            };
            return cities;
        }

        public static List<Person> GetAllPeople() {
            List<Person> people = new List<Person>() {
                new Person("Marry", new Car("Jazz", "Honda", 150), new City("New York", "USA", 40.7128, 74.0060)),
                new Person("Susan", new Car("Avanza", "Toyota", 150), new City("Jakarta", "Indonesia", 6.1805, 106.8283)),
                new Person("Jack", new Car("Golf", "Volkswagen", 150), new City("Sydney", "Australia", 33.8688, 151.2093))
            };
            return people;
        }

        /*Contoh tuples*/

        public static (string, string, double, double) FindCity(string name, List<City> cities) {
            foreach (City kota in cities) {
                if (kota.Name == name) {
                    return (kota.Name, kota.CountryName, kota.Longitude, kota.Latitude);
                }
            }
            return ("", "", 0, 0);
        }

        public static (string, Car, City) FindPerson(string name, List<Person> people) {
            foreach (Person person in people) {
                if (person.Name == name) {
                    return (person.Name, person.PrivateCar, person.BirthCity);
                }
            }
            return ("", new Car(), new City());
        }

    }
}
