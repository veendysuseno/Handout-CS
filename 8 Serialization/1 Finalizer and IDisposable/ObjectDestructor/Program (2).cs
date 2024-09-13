using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectDestructor {
    class Program {
        static void Main(string[] args) {

            /*
             * Isi dari fungsi GenerateAgenda sangat sederhana, yaitu membuat 2 object Agenda dan menggunakannya.
             * Tetapi Destructor tidak akan dijalankan di akhir code block dari variable atau bahkan setelah fungsinya selesai dijalankan.
             */
            GenerateAgenda();
            //Destructor Agenda masih belum jalan di sini.

            /*
             * Sebelum lanjut mempelajari melepaskan memory, kita harus telebih dahulu mengetahui kalau seluruh memory yang kita pakai pada saat menjalankan C#, dibagi
             * menjadi 2 kategori:
             * 
             * 1. Managed Resources: adalah semua memory yang dipakai oleh C# dan di tangani oleh CLR seperti layaknya object dan variable biasa, dimana seluruh memorynya akan
             * dikembalikan oleh GC pada saat destructor/finalizer dipanggil. Managed Resource sudah di tangani oleh system dan kita tidak perlu dan tidak bisa melakukan apa-apa
             * terhadapnya.
             * 
             * 2. Unmanaged Resources: adalah memory yang tidak bisa di handle oleh CLR, sehingga pengembalian memorynya harus secara manual dikembalikan dengan teknik
             * Dispose. Karena seluruh unmanaged resources tidak bisa ditangani oleh GC. Contoh dari unmanaged resources adalah koneksi stream file dan database.
             * Membaca file akan dipelajari di chapter selanjutnya.
             */
            DisposingShopping();
            DisposingTask();
        }

        public static void GenerateAgenda() {
            {
                Agenda meeting = new Agenda("Meeting with Client", new DateTime(2017, 9, 8, 9, 30, 0), new DateTime(2017, 9, 8, 13, 40, 0));
                Agenda birthday = new Agenda("Pesta ulang tahun teman", new DateTime(2017, 9, 12, 9, 30, 0), new DateTime(2017, 9, 12, 12, 30, 0));
                Console.WriteLine($"Mengakses Agenda {meeting.Name}, Dari: {meeting.From.ToString("dd/MM/yyyy")}, Sampai: {meeting.To.ToString("dd/MM/yyyy")}");
                Console.WriteLine($"Mengakses Agenda {birthday.Name}, Dari: {birthday.From.ToString("dd/MM/yyyy")}, Sampai: {birthday.To.ToString("dd/MM/yyyy")}");
            } 
            //Destructor Agenda masih belum jalan di sini.
            Console.WriteLine("Selesai melakukan experiment terhadap class Agenda.");
        }

        public static void DisposingShopping() {
            Shopping mentega = new Shopping("Mentega", 1, 10000m);
            Console.WriteLine($"{mentega.ItemName}, {mentega.Quantity}, {mentega.Price}");

            //Ini adalah cara manual kita men-dispose
            mentega.Dispose();
            mentega.Dispose();//Fungsi akan stop sebelum di mulai

            /*
             * Dibawah ini adalah contoh kita meng-invoke Dispose tanpa memanggil methodnya langsung, tetapi menggunakan using dan code-block.
             * 
             * Cara dibawah ini jauh lebih best practice dibandingkan menggunakan method Dispose(), dikarenakan:
             * 1 Developer tidak akan secara tidak sengaja menggunakan object yang sudah di dispose.
             * 2 Dispose akan dipanggil ketika code-block pada using di tutup, jadi semua tau kalau kita harus menggunakan object dalam area code-block.
             */
            using (Shopping telur = new Shopping("Telur", 12, 2000m)) {
                Console.WriteLine($"{telur.ItemName}, {telur.Quantity}, {telur.Price}");
            }

            //Console.WriteLine(telur.ItemName); kita tidak akan bisa menggunakan telur lagi, karena dianggap local terhadap code block.

            /*
             * Kita masih bisa mengunakan isi property dari mentega, padahal sudah di dispose, kenapa?
             * Seperti penjelasan saya yang sebelumnya kalau Dispose hanyalah method kosong. Apabila kalian tidak set null atau apapun ke dalam object mentega,
             * maka tidak akan terjadi apa pun dengan mentega.
             * 
             * Jadi mengapa saya beri contoh penggunaan Dispose? Dispose akan menjadi culture dan tradisi bagi setiap library yang ingin menghapus unmanaged resources.
             * Nantinya kita akan menggunakan using code-block untuk setiap unmanaged resources, jadi kalian akan paham kenapa adanya using code-block.
             */
            Console.WriteLine($"{mentega.ItemName}");

            /*Shopping adalah contoh yang buruk, dikarenakan object yang sudah di dispose masih akan di handle oleh Destructor oleh GC.
              Object yang nantinya sudah di dispose tidak akan perlu dibuang GC lagi lewat destructor.
             */
        }

        public static void DisposingTask() {
            using (Task beliBeras = new Task("Beli Beras", "Shopping")) {
                Console.WriteLine($"{beliBeras.ActivityName}, {beliBeras.Category}");
            }
        }
    }
}
