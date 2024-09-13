using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionAndFeatures {
    class Program {
        /* Function adalah dasar dari procedural programming, dimana semua eksekusi program dipisah-pisahkan dan dikelompokan ke dalam modul-modul kecil.
         * Dengan adanya function semua exekusi lebih mudah dibaca dan dimengerti oleh sesama programmer, tetapi lebih pentingnya lagi function juga digunakan untuk mencegah terjadinya duplicate code.
         * Sehingga baik satu atau lebih programmer yang bekerja dalam satu kelompok tidak membuat program yang sama.
         */

        /* berikut ini adalah sebuah function;
         * public: merupakan VISIBILITY atau ACCESS LEVEL, ini membatasi apa yang boleh menggunakan dan tidak boleh menggunakan functionini. Akan dijelaskan lebih dalam di chapter Ecapsulation dan Object Oriented Programming
         * int: merupakan RETURN VALUE. Ini menjelaskan tipe data output dari function ini.
         * static: akan dijelaskan lebih lanjut di chapter Object Oriented Programming.
         * int angkaPertama dan int angkaKedua: ini disebut PARAMETER. parameter merupakan pen-definisian input dari function ini.
         * return hasil: merupakan hasil yang akan menjadi output dari function ini. return hasil akan di pass ke RETURN VALUE pada saat di invoke.
         */

        //Gunakan triple / untuk menggunkan function comment atau lebih disebut xml comment.

        /// <summary>
        /// Function ini digunakan untuk menjumlahkan dua buah angka.
        /// </summary>
        /// <param name="angkaPertama">Angka pertama yang ini dijumlahkan</param>
        /// <param name="angkaKedua">Angka kedua yang ini dijumlahkan</param>
        /// <returns>Mengembalikan hasil penjumlahan</returns>
        public static int Penjumlahan(int angkaPertama, int angkaKedua) {
            int hasil = angkaPertama + angkaKedua;
            return hasil;
        }

        static void Main(string[] args) {
            //Invoking function: adalah proses menggunakan function
            int result = Penjumlahan(5, 6);
            Console.WriteLine("Hasil: {0}", result);

            //Invoking function dimana function tersebut invoke function yang lain
            int hasilPerkalian = Perkalian(5, 4, 6);
            Console.WriteLine("Hasil: {0}", hasilPerkalian);

            PrintHelloWorld();
            string name = "Boby";
            PrintHelloFriend(name);

            string[] wordCollection = new string[5];
            wordCollection[0] = "Hello";
            wordCollection[1] = "Friend";
            wordCollection[2] = "May be";
            wordCollection[3] = "I Should";
            wordCollection[4] = "Give";
            IterateArray(wordCollection);

            ImprovedIterateArray("Hello", "Friend", "May be", "I Should", "Give");

            DefaultParameter();
            DefaultParameter("Linda");
            DefaultParameters(8);
            DefaultParameters(1, 2);

            int variableOne = 0;
            int variableTwo = 0;
            int variableThree;
            NormalParameter(variableOne);
            ReferenceParameter(ref variableTwo);
            OutParameter(out variableThree);
            Console.WriteLine("Variable one: {0}", variableOne);

            /* reference parameter akan merubah variable awal, karena pada saat masuk ke dalam parameter 
             * sebagai argument, dikirimkan referensi lokasi memory variable aslinya.
             * 
             * Sedangkan di dalam normal parameter, terjadinya duplikasi variable. 
             * Parameter mendeklarasi variable baru yang inclusive di dalam functionnya.
             */
            Console.WriteLine("Variable two: {0}", variableTwo);

            /*out parameter memiliki kemampuan special untuk menerima unassigned variable, tetapi memiliki kewajiban untuk assign variable
             * di dalam function nya. Kemampuan lainnya sama seperti reference parameter, dimana parameter yang dipakai memiliki reference pointer ke variable yang sama.
             */
            Console.WriteLine("Variable three: {0}", variableThree);

            /* Named Argument: invoking function lengkap dengan argumentnya dengan cara memanggil nama-nama variable dari parameternya.
             * Named function digunakan apabila programmer ingin invoke function tanpa memperdulikan urutan dari parameternya.
             */
            //Invoke biasa
            PrintCartDetails("0054", "Lenovo E450", "Toko Komputer", 4, 8500000m);

            //Named Argument style
            PrintCartDetails(itemName: "Lenovo E450", price: 8500000m, sellerName: "Toko Komputer", itemCode: "0054", quantity: 4);

            //Normal invoke dan named argument bisa di mixed, tapi harus memiliki urutan yang benar dan juga harus berada pada urutan terakhir
            PrintCartDetails("0054", "Lenovo E450", sellerName: "Toko Komputer", price: 8500000m, quantity: 4);
        }

        #region Functions

        /* Function yang meng-invoke function lain.
         * Function tidak sama seperti deklarasi variable, function bisa ditulis setelah line dimana function tersebut di invoke.
         */
        public static int Perkalian(int bilanganPertama, int bilanganKedua, int bilanganKetiga) {
            int hasilJumlah = Penjumlahan(bilanganPertama, bilanganKedua);
            int hasil = hasilJumlah * bilanganKetiga;
            return hasil;
        }

        /* Function void tidak mengembalikan nilai apa pun. Tapi tetap memproses seluruh statement di dalamnya.*/
        public static void PrintHelloWorld() {
            Console.WriteLine("Hello World!");
        }

        public static void PrintHelloFriend(string name) {
            Console.WriteLine("Hello {0}, Welcome back!", name);
        }

        //contoh parameter dalam collection
        public static void IterateArray(string[] stringArray) {
            for (int index = 0; stringArray.Length > index; index++) {
                Console.WriteLine(stringArray[index]);
            }
        }

        //params keyword, sehingga bisa menerima multiple parameter yang nantinya akan dijadikan array
        public static void ImprovedIterateArray(params string[] stringArray) {
            for (int index = 0; stringArray.Length > index; index++) {
                Console.WriteLine(stringArray[index]);
            }
        }

        //default parameter, apabila sebuah parameter tidak diisi di dalam argument, maka akan mengambil defaultnya.
        public static void DefaultParameter(string sesuatu = "Jack") {
            Console.WriteLine("Hello {0}", sesuatu);
        }

        //Untuk multiple parameter yang mix antara yang regular dan default setting
        public static void DefaultParameters(int angka, int angkaKedua = 7) {
            int result = angka + angkaKedua;
            Console.WriteLine("Hasilnya {0}", result);
        }

        //Ini tidak akan bisa, karena default parameter harus lebih belakang dari yang regular parameter
        //public static void DefaultParameters(int angka = 7, int angkaKedua)
        //Normal Parameter
        public static void NormalParameter(int args) {
            args = 45;
            Console.WriteLine("Inside normal parameter function {0}", args);
        }

        /*Reference Parameter: mengubah tipe data menjadi reference type, sehingga tidak dibuatkan memory stack baru pada saat masuk ke parameter.*/
        public static void ReferenceParameter(ref int args) {
            args = 67;
            Console.WriteLine("Inside reference parameter function {0}", args);
        }

        /* Out Parameter: seperti reference parameter, bedanya parameter out diisi oleh argument yang baru di deklarasi dan belum di assign valuenya.
         * Value bisa di assign di dalam paraeternya.
         */
        public static void OutParameter(out int args) {
            args = 94;
        }

        //In Parameter: avaliable di C# 7.2. Parameter ini tidak bisa diubah valuenya di dalam function ini.
        /*  public static void InParameter(in int args) {
                Console.WriteLine(args);
            }
        */
        public static void PrintCartDetails(string itemCode, string itemName, string sellerName, int quantity, decimal price) {
            Console.WriteLine("item code: {0}\nitem name: {1}\nseller name: {2}\nquantity: {2}\nprice: {3}", itemCode, itemName, sellerName, quantity, price);
        }

        #endregion
    }
}
