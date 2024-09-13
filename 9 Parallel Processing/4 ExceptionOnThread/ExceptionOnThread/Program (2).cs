using System;
using System.Threading;

namespace ExceptionOnThread
{
    class Program
    {
        
        static void Main(string[] args) {

            /*
             * Ini adalah sedikit tambahan topik pada Thread, yaitu bagaimana mengantisipasi run time error dengan try catching exception
             * saat di dalam Worker Thread.
             * 
             * Kedua fungsi dibawah sama-sama memiliki tujuan yang sama, yaitu meng-convert string menjadi integer.
             * Tetapi kita semua tau kalau hal tersebut bisa mengakibatkan run time error apabila string memang tidak bisa dibuat jadi integer, misalnya "abc" tidak akan bisa jadi integer.
             * Oleh karena itu seperti biasa pasti developer akan membuatkan try catch block.
             * 
             * Tapi dari 2 fungsi di bawah ada yang gagal menangkap exception ada yang berhasil.
             * Mari kita liat perbedaanya.
             */
            Console.WriteLine("Mencoba simulasi exception:\n1 Yang Gagal\n2 Yang Berhasil");
            string input = Console.ReadLine();
            switch (input) {
                case "1":
                    FailException("abc");
                    break;
                case "2":
                    SuccessException("abc");
                    break;
                default:
                    Console.WriteLine("Harus pilih opsi 1 atau 2");
                    break;
            }
        }

        /// <summary>
        /// Fungsi ini gagal menangkap exception karena exception dipasang di luar Worker Thread.
        /// Kalian harus mengerti bahwa worker thread yang baru dibuat dan dijalankan akan berjalan secara independent.
        /// 
        /// Pada saat ini try catch block tidak akan sanggup check isi dari Thread, dikarenakan waktu eksekusi Thread tidak menentu,
        /// pada saat code mencoba parse input, eksekusi try catch sudah lewat.
        /// 
        /// Saat ini saya bisa katakan kalau try catch bersifat global dari thread.
        /// </summary>
        /// <param name="input"></param>
        public static void FailException(string input) {
            try {
                new Thread(() => {
                    int hasil = Int32.Parse(input);
                }).Start();
            } catch {
                Console.WriteLine("Input tidak bisa di convert jadi integer");
            }
        }

        /// <summary>
        /// Function di bawah ini berhasil menangkap exception karena try catch berada di dalam thread, sehingga try catch juga dibawa oleh
        /// Worker Thread yang baru saja dibuat dan di start kemana pun dan kapan pun Thread berjalan.
        /// </summary>
        /// <param name="input"></param>
        public static void SuccessException(string input) {
            new Thread(() => {
                try {
                    int hasil = Int32.Parse(input);
                } catch {
                    Console.WriteLine("Input tidak bisa di convert jadi integer");
                }
            }).Start();
        }

    }
}
