using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicVsStatic {
    public static class Item {

        //Seluruh property atau field harus bersifat static di dalam static class.
        public static string Name { get; set; }
        public static string Brand { get; set; }
        public static int Stock { get; set; }

        /* tidak boleh ada constructor di dalam static class, karena class ini juga tidak bisa digunakan untuk membuat object
        public static Item() {

        }
        */

        public static void PrintInfo() {
            Console.WriteLine("Name: {0}, Brand: {1}, Stock {2}", Name, Brand, Stock);
            //Console.WriteLine("Name: {0}, Brand: {1}, Stock {2}", this.Name, this.Brand, this.Stock);
            //Tidak bisa menggunakan kata this, karena tidak ada object yang dinamis atau lebih dari satu.
        }

        /* Tidak akan jalan, karena seluruh method yang dimiliki static class juga harus bersifat static.
        public void PrintSomething() {

        }
        */
    }
}
