using System;
using System.Threading;

namespace Signaling
{
    class Program
    {
        static void Main(string[] args) {
            /* 
             * Thread Signaling adalah satu tindakan di mana kita bisa paused sebuah eksekusi Thread di tengah perjalanan, lalu thread ini akan kembali jalan
             * setelah mendapat sebuah signal yang berasal dari thread lain.
             * Oleh karena itu kita bisa menyisipkan giliran thread lain di tengah-tengah proses sebuah thread.
             * 
             * Uncomment satu persatu panggilan fungsi di bawah ini untuk mencoba.
             */

            //WaitSetExperiment();
            //WaitSetResetExperiment();
            //SetByAnotherWorkerThread();
            //SimulasiIrigasi.TugasIrigasi();
        }

        public static void WaitSetExperiment() {
            /*
             * Object ManualResetEvent adalah object yang kita gunakan untuk membuat signal object.
             * Perhatikan constructornya berisi sebuah boolean bernilai false.
             * 
             * false merupakan initial state atau status pertamakali dari signal ketika object ini mulai dibuat.
             * 
             * Initial state dari signal sendiri seperti lampu bohlam yang bisa mati (false) atau bisa menyala (true).
             * Apabila pada awalnya sudah bernilai true (lampu menyala), kita tidak bisa memberikan signal pada suatu thread karena lampunya sudah terlanjur menyala.
             * Tetapi apabila dimulai dari false (lampu dalam keadaan mati), kita bisa memberi signal "Silahkan thread ini kembali bekerja apabila melihat lampu dari yang tadinya off menjadi on".
             * atau dalam arti lain melihat nilai false menjadi true.
             */
            var signal = new ManualResetEvent(false);

            var workerThread = new Thread(() => {
                Console.WriteLine("Tahap 1");
                signal.WaitOne(); //Setelah Tahap 1, di sini thread diminta untuk menunggu signal dinyalakan baru lanjut ke tahap 2.
                Console.WriteLine("Tahap 3");
            });

            Console.WriteLine("Memulai main thread...");
            workerThread.Start();
            Thread.Sleep(1000); //Berlama-lama 1 detik.
            Console.WriteLine("Tahap 2"); //Walaupun main thread yang ingin print "Tahap 2" berlama-lama dengan thread sleep, "Tahap 3" pada worker thread akan sabar menunggu signal dinyalakan.
            signal.Set(); //Set adalah method yang digunakan untuk menyalakan lampu signal, sehingga seluruh aktifitas thread yang diminta menunggu dengan WaitOne akan jalan kembali.
        }

        public static void WaitSetResetExperiment() {
            /*
             * Di sini men-demo kan apabila kita ingin menghentikan proses thread, melanjutkannya, menghentikan lagi dan melanjutkannya lagi proses dari Thread.
             * 
             * Simplenya kita tinggal melakukan WaitOne(), Set(), WaitOne(), dan Set() lagi kan?
             * Salah, karena ketika kita Set() satu kali, signal sudah dalam kondisi true, dan kita tidak bisa meng-signal kan thread dengan lampu yang sudah menyala dari awal.
             * Kita harus kembali matikan lamput tersebut untuk bisa melakukan Set() kedua kali, yaitu dengan method Reset()
             */
            var signal = new ManualResetEvent(false); //1. Set off

            var workerThread = new Thread(() => {
                Console.WriteLine("Tahap 1");
                signal.WaitOne(); //2. Wait
                Console.WriteLine("Tahap 3");
                signal.Reset(); //4. Set kembali jadi off
                signal.WaitOne(); //5. Wait
                Console.WriteLine("Tahap 5");
            });

            Console.WriteLine("Memulai main thread...");
            workerThread.Start();
            Thread.Sleep(1000);
            Console.WriteLine("Tahap 2");
            signal.Set(); //3. Set on
            Thread.Sleep(1000);
            Console.WriteLine("Tahap 4");
            signal.Set(); //6, Set kembali jadi on
        }

        public static void SetByAnotherWorkerThread() {
            /*
             * Di sini adalah contoh dimana kita bisa melakukan Set, tetapi di Worker Thread yang lain.
             * Tetapi hati-hati, melakukan WaitOne, Set, Reset di thread lain, karena dapat membingungkan developer lain, dikarenakan
             * selesainya antar worker thread tidak bisa diketahui dengan jelas.
             */
            var signal = new ManualResetEvent(false);

            var threadPertama = new Thread(() => {
                Console.WriteLine("Tahap 1");
                signal.WaitOne();
                Console.WriteLine("Tahap 3");
            });

            var threadKedua = new Thread(() => {
                Thread.Sleep(1000);
                Console.WriteLine("Tahap 2");
                Thread.Sleep(1000);
                signal.Set();
            });

            Console.WriteLine("Memulai main thread...");
            threadPertama.Start();
            threadKedua.Start();
        }

    }
}
