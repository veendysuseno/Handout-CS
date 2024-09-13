using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectDestructor {

    //Untuk menggunakan method Dispose(), class harus menginherit IDisposable interface
    public class Shopping : IDisposable { 
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public Shopping(string itemName, int quantity, decimal price) {
            Console.WriteLine("Menggunakan constructor untuk Shopping.");
            this.ItemName = itemName;
            this.Quantity = quantity;
            this.Price = price;
        }

        ~Shopping() {
            Console.WriteLine($"Shopping use destructor on object {this.ItemName}.");
        }

        /*
         * _disposedValue adalah private field yang memberi flag atau tanda apakah object ini sudah pernah di dispose atau belum.
         * Karena proses Dispose() bersifat Idempotent nantinya.
         * Idempotent sendiri artinya tidak boleh terjadi 2 kali pada hal yang sama.
         */
        private bool _disposedValue = false;

        /*
         * Dispose hanyalah sebuah method kosong biasa.
         * 
         * Satu-satunya hal yang di luar biasa dari Dispose adalah dia bisa di invoke dengan cara yang tidak biasa, yaitu menggunakan using code-block 
         * (nanti kita akan liat sama-sama contohnya di Class Program).
         * 
         * Lain dengan Destructor dan Finalizer, method Dispose sendiri tidak memiliki kemampuan apa-apa seperti mengembalikan memory dan lain sebagainya.
         * Method dispose pada umumnya digunakan library pembaca file dan database untuk menutup semua koneksi ketika selesai membaca atau menulis data. Kenapa?
         * 
         * Karena GC tidak bisa menggunakan destructor untuk menghapus Unmanage Resource seperti koneksi input output ke file dan ke database.
         */
        public void Dispose() {
            if (_disposedValue == true) { //langsung exit dari function kalau sudah di dispose.
                return;
            }
            Console.WriteLine($"Shopping disposing object {this.ItemName}");
            _disposedValue = true;
        }
    }
}
