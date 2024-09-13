using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalFunctions {
    class Program {

        static void Main(string[] args) {
            GetTotalVolume(3, 12.5, 8.6);

            BukuPolis policy = new BukuPolis() {
                BiayaPremi = 17000000,
                PemegangPolis = "Ben Sanjaya"
            };
            Console.WriteLine(policy.PrintInformasiPelunasanPremi(8));
        }

        /*
         * Local Function adalah deklarasi function di dalam function.
         * Local function tidak dapat di invoke diluar function tersebut, karena hanya exclusive local saja.
         * 
         * Sifat-sifat local function yang lain:
         * 1. tidak ada access modifier, karena semua local function private terhadap function masternya.
         * 2. tidak ada deklarasi static di dalam local function.
         * 3. local function bisa di deklarasi sebagai async atau unsafe.
         */

        // VolumeTabung(); //Ini akan mengakibatkan error apabila di uncomment.
        
        public static void GetTotalVolume(int quantity, double tinggi, double diameter) {

            Console.WriteLine("Total Volumenya adalah {0}", TotalVolume());

            double LuasAlas() {
                double jariJari = diameter / 2;
                double luasAlas = Math.PI * Math.Pow(jariJari, 2);
                return luasAlas;
            }

            double VolumeTabung() {
                double volume = LuasAlas() * tinggi;
                return volume;
            }

            double TotalVolume() {
                double totalVolume = VolumeTabung() * quantity;
                return totalVolume;
            }

        }
    }
}
