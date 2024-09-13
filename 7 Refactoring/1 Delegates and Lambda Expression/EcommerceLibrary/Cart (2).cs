using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceLibrary
{
    public class Cart
    {
        public List<Item> ItemList { get; set; } //Barang-barang yang dibeli di chart

        //constant diskon
        public const decimal DiskonSuper = 0.5m;
        public const decimal DiskonBesar = 0.2m;
        public const decimal DiskonRegular = 0.05m;

        /*
         * Delegates (delegasi/ perwakilan/ pengalihan): adalah sebuah function pointer, atau suatu deklarasi static yang digunakan untuk penunjuk function.
         * Dengan adanya delegate, kita bisa mem-variable kan sebuah fungsi seperti layaknya fungsi call-back pada javascript.
         * Oleh karena function yang bisa diperlakukan sebagai variable, kita juga bisa menggunakan function sebagai parameter. 
         */
        public delegate void PrintTotalBarang(decimal total);
        public delegate void PrintTotalDiskon(decimal total);
        public delegate void PrintTotalWajibBayar(decimal total);
        public delegate decimal PrintTotalCashBack(decimal total);
        public delegate void PrintThankYou();

        //hitung total jumlah barang
        public decimal JumlahHargaBarang() {
            decimal total = 0m;
            foreach (Item item in this.ItemList) {
                total += item.Price;
            }
            return total;
        }

        //ketiga parameter ini sebenarnya adalah 3 buat functions. Jadi C# bisa melakukan callback function seperti javascript
        public decimal HitungTotalWajibBayar(PrintTotalBarang printTotalBarang, PrintTotalDiskon printTotalDiskon, PrintTotalWajibBayar printTotalWajibBayar) {
            decimal totalWajibBayar = 0m;
            decimal totalDiskon = 0m;
            decimal totalHargaBarang = JumlahHargaBarang();
            if (totalHargaBarang >= 1000000m) {
                totalDiskon = totalHargaBarang * DiskonSuper;
            } else if (totalHargaBarang >= 500000m) {
                totalDiskon = totalHargaBarang * DiskonBesar;
            } else if (totalHargaBarang >= 200000) {
                totalDiskon = totalHargaBarang * DiskonRegular;
            }
            totalWajibBayar = totalHargaBarang - totalDiskon;

            //function delegates di invoke di sini seperti function biasa.
            printTotalBarang(totalHargaBarang);
            printTotalDiskon(totalDiskon);
            printTotalWajibBayar(totalWajibBayar);
            return totalWajibBayar;
        }

        /*
         * Func merupakan cara menggunakan delegate tanpa deklarasi delegate.
         * Func merupakan sebuah generic, dimana sanggup menerima sampai 17 parameters, dan parameter terakhirnya akan selalu definisi return value.
         * 
         * Dalam contoh di bawah ini Func menerima parameters 1 List<Item> dan 1 decimal.
         * decimal terakhir menandakan kalau delegate ini harus me-return decimal
         */
        public decimal HitungOngkosKirim(decimal ongkosKirimAwal, Func<List<Item>, decimal, decimal> hitungTotalOngkosKirim) {
            return hitungTotalOngkosKirim(this.ItemList, ongkosKirimAwal);
        }

        /*
         * Action sama seperti Func, bedanya adalah action diperuntukan untuk function yang void, sedangkan Func adalah untuk function yang return value.
         * Action merupakan sebuah generic, dimana sanggup menerima sampai 16 parameters (sebetulnya sama seperti Func, karena parameter terakhir func adalah return value).
         * 
         * Dalam contoh di bawah ini Action menerima satu parameter string dengan return type void.
         */
        public void AlertCashBack(Action<string> cashBackAlert, PrintTotalCashBack printTotalCashBack, PrintThankYou printThankYou) {
            cashBackAlert("Kita punya program cash back!");
            decimal totalCashBack = printTotalCashBack(JumlahHargaBarang());
            string totalString = totalCashBack.ToString("C2", CultureInfo.CreateSpecificCulture("id-ID"));
            Console.WriteLine("Inilah 10% cashback anda: {0}", totalString);
            printThankYou();
        }
    }
}
