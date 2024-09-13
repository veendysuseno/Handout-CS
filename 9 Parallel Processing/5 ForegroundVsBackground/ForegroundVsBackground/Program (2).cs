using System;
using System.Threading;

namespace ForegroundVsBackground
{
    class Program
    {
        static void Main(string[] args) {

            /*
             * Thread dibagi menjadi 2 berdasarkan durasi hidupnya:
             * 
             * Foreground Thread: Pada dasarnya seluruh worker thread yang selama ini kita buat adalah Foreground Thread, karena itu sudah setting by default.
             *      Thread ini akan dipastikan terus berjalan sampai seluruh eksekusinya habis atau selesai. Walaupun Main Thread sudah selesai mengerjakan seluruh code
             *      dan eksekusinya, aplikasi tidak akan exit atau berhenti. Aplikasi akan terus menunggu sampai seluruh Foreground Thread menyelesaikan pekerjaannya.
             * 
             * Background Thread: Untuk membuat sebuah Thread menjadi Background Thread, kalian harus merubah property IsBackground dari thread tersebut menjadi true.
             *      Background Thread bisa di stop secara paksa oleh CLR, apabila Main Thread dan seluruh Foreground Thread yang ada sudah selesai.
             *      Jadi bisa diambil kesimpulan, aplikasi tidak mau menunggu Background Thread untuk menyelesaikan pekerjaanya.
             *      
             * (Background Thread berguna pada kondisi tertentu, aplikasi kalian tidak ingin diperlambat oleh worker thread. Karena thread sangat mudah di start, tetapi
             *  Sangat sulit dihentikan. Note: banyak yang share kalau bisa menghentikan thread dengan method Abort, tetapi itu tidak best practice dan sangat berbahaya.
             *  Khususnya bila dikombinasikan dengan Thread Lock, maka apabila di abort ketika di dalam lock code block, thread yang lain tidak bisa masuk)
             */
            var foregroundThread = new Thread(LoopCepat);
            var backgroundThread = new Thread(LoopLambat);
            backgroundThread.IsBackground = true;
            foregroundThread.Start();
            backgroundThread.Start();
            LoopSangatCepat();
        }

        public static void LoopSangatCepat() {
            for (int index = 0; index <= 20; index++) {
                Thread.Sleep(500);
                Console.WriteLine($"Sangat Cepat, Index: {index}");
            }
        }

        public static void LoopCepat() {
            for (int index = 0; index <= 20; index++) {
                Thread.Sleep(1000);
                Console.WriteLine($"Cepat, Index: {index}");
            }
        }

        public static void LoopLambat() {
            for (int index = 0; index <= 20; index++) {
                Thread.Sleep(3000);
                Console.WriteLine($"Lambat, Index: {index}");
            }
        }

    }
}
