using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Continuation
{
    public static class UtilizingAwaiter
    {
        /*TaskAwaiter adalah bentuk representasi sebuah tool yang digunakan sebagai alat menunggu proses asynchronous task dalam wujud object.*/

        public static void GettingResult() {
            /* Kita akan membuat 3 task dengan return value integer dengan Run dan menginstantiate object Tasknya terlebih dahulu. */
            Task<int> firstNumberTask = Task.Run(() => {
                return 7;
            });
            Task<int> secondNumberTask = new Task<int>(() => {
                return 8;
            });
            Task<int> thirdNumberTask = Task.Run(GetThirdNumber);

            /* Object TaskAwaiter dibuat dengan menggunakan library System.Runtime.CompilerServices.
             * Object awaiter juga bisa didapat dengan menggunakan GetAwaiter ketika task yang kita ingin buatkan alat tunggunya sudah dibuat.
             */
            TaskAwaiter<int> awaiterFirstNumber = firstNumberTask.GetAwaiter();
            //Perhatikan contoh awaiterSecondNumber di bawah. Second number di Start setelah awaiter sudah dibuat, dan tidak akan menjadi masalah.
            var awaiterSecondNumber = secondNumberTask.GetAwaiter();
            secondNumberTask.Start();
            var awaiterThirdNumber = thirdNumberTask.GetAwaiter();

            /* Perhatikan result dari ketiga print console dibawah ini.
             * Ketiganya bisa mendapatkan hasilnya lewat GetResult() method dari awaiter objectnya, tetapi bila anda perhatikan hasilnya,
             * urutan selalu berada dalam posisi benar, First Number, Second Number, lalu Third Number.
             * 
             * Itu dikarenakan mengeluarkan GetResult() bersifat synchronous, dan pada akhirnya sama saja dengan mendapatkan hasil dengan 
             * property Result biasa. Ini dikarenakan penggunaan awaiter di bawah ini belum tepat.
             */
            Console.WriteLine($"First Number: {awaiterFirstNumber.GetResult()}");
            Console.WriteLine($"Second Number: {awaiterSecondNumber.GetResult()}");
            Console.WriteLine($"Third Number: {awaiterThirdNumber.GetResult()}");
        }

        public static int GetThirdNumber() {
            return 9;
        }

        public static void EventOnComplete() {
            Task<int> firstNumberTask = Task.Run(() => 7);
            Task<int> secondNumberTask = Task.Run(() => 8);
            Task<int> thirdNumberTask = Task.Run(() => 9);

            var awaiterFirstNumber = firstNumberTask.GetAwaiter();
            var awaiterSecondNumber = secondNumberTask.GetAwaiter();
            var awaiterThirdNumber = thirdNumberTask.GetAwaiter();

            /* Di sini kita menggunakan menthod OnComplete sebagai event handler pada saat sebuah task complete,
             * maka delegates dari parameter on complete akan langsung di eksekusi, sehingga tidak terjadi blocking process
             * seperti pada contoh GettingResult sebelumnya.
             * 
             * Oleh karena OnComplete tidak terjadi synchronous, maka hasil dari First Number, Second Number dan Third Number bisa acak dan
             * susul menyusul. Dengan begini performance akan meningkat karena number akan di print segera setelah task selesai.
             */
            awaiterFirstNumber.OnCompleted(() => {
                Console.WriteLine($"First Number: {awaiterFirstNumber.GetResult()}");
            });
            awaiterSecondNumber.OnCompleted(() => {
                Console.WriteLine($"Second Number: {awaiterSecondNumber.GetResult()}");
            });
            awaiterThirdNumber.OnCompleted(() => {
                Console.WriteLine($"Third Number: {awaiterThirdNumber.GetResult()}");
            });

            /* Karena task adalah asyhcronous proses yang bersifat background, maka tanpa main thread menunggu ketiga eksekusi task selesai,
             * ketiga hasil OnComplete tidak akan terlihat (Karena kemungkinan besar main thread akan berlangsung lebih cepat dari ketiga task tanpa menggunakan sleep).
             */
            Thread.Sleep(1000);
        }

        public static void MomentOfOnComplete() {
            /* Tetapi moment saat OnComplete dijalankan mungkin sedikit dipertanyakan.
             * Apakah terjadi ketika task baru diproses? ataukan terjadi setelah di return dan last stack selesai dipanggil?
             * 
             * Oleh karena itu disetiap task, saya buatkan line pertama untuk melakukan printing, lalu line terakhir adalah untuk
             * return valuenya. Lalu kita lihat kapan proses OnComplete dijalankan.
             * Dari hasilnya kita bisa membuat kesimpulan.
             */
            Task<int> firstNumberTask = Task.Run(() => {
                Console.WriteLine("Beginning First Number Task...");
                return 7;
            });
            Task<int> secondNumberTask = Task.Run(() => {
                Console.WriteLine("Beginning Second Number Task...");
                return 8;
            });
            Task<int> thirdNumberTask = Task.Run(() => {
                Console.WriteLine("Beginning Third Number Task...");
                return 9;
            });

            /* Saya juga akan mencoba task yang bersifat void untuk dibuatkan awaiter objectnya.
             * Lalu kita akan lihat bagaimana OnComplete akan berpengaruh terhadapnya.
             */
            Task printMessageTask = Task.Run(() => { 
                Console.WriteLine("Printing message...");
            });

            var awaiterFirstNumber = firstNumberTask.GetAwaiter();
            var awaiterSecondNumber = secondNumberTask.GetAwaiter();
            var awaiterThirdNumber = thirdNumberTask.GetAwaiter();
            //Awaiter pada task yang bersifat void tidak bersifat generic type
            TaskAwaiter awaiterPrintMessage = printMessageTask.GetAwaiter();

            awaiterFirstNumber.OnCompleted(() => {
                Console.WriteLine($"First Number: {awaiterFirstNumber.GetResult()}");
            });
            awaiterSecondNumber.OnCompleted(() => {
                Console.WriteLine($"Second Number: {awaiterSecondNumber.GetResult()}");
            });
            awaiterThirdNumber.OnCompleted(() => {
                Console.WriteLine($"Third Number: {awaiterThirdNumber.GetResult()}");
            });
            awaiterPrintMessage.OnCompleted(() => {
                //Mecoba GetResult() di sini akan berakhir compile error karena tidak memungkin kan menerima return dari void.
                Console.WriteLine($"Secret Message");
            });

            /* Di sini kita bisa simpulkan, bahwa OnCompleted terjadi tepat setelah return terjadi atau setelah task benar-benar selesai.
             * Oleh karena itu seluruh "Beginning..." text yang di print di console hasilnya akan lebih dulu bersama-sama sebelum print hasilnya di OnCompleted.
             * 
             * Secret Message juga tidak bisa diprint tepat setelah "Printing message..." terjadi, karena Printing Message merupakan awal proses dari task.
             */

            Thread.Sleep(1000);
        }

        /// <summary>
        /// Seperti yang kita lihat dari function MomentOfOnComplete, kalau OnComplete handler akan di eksekusi ketika
        /// task sudah selesai, tapi adakah cara untuk check status task apakah sudah selesai atau belum, terutama apabila task
        /// membutuhkan waktu yang lama untuk diselesaikan.
        /// </summary>
        public static void CheckIfAwaiterIsDone() {
            /* Di sini kita membuat 2 task.
             * Task ini membutuhkan waktu yang sedikit lama untuk selesai atau melakukan return value,
             * mari kita jalankan untuk melihat apakah OnComplete akan tertunda eksekusinya ketika proses task juga ikut lambat.
             * Lalu adakah cara untuk check check status task ketika ditengah proses atau ketika di dalam OnComplete.
             */
            var firstNumberTask = Task.Run(() => {
                Console.WriteLine("Menunggu selama 3 detik.");
                Thread.Sleep(3000);
                return 6;
            });
            var printMessageTask = Task.Run(() => {
                Console.WriteLine("Menunggu selama 5 detik.");
                Thread.Sleep(5000);
            });

            var awaiterFirstNumber = firstNumberTask.GetAwaiter();
            var awaiterPrintMessage = printMessageTask.GetAwaiter();
            /*2 Task di atas sudah pasti belum selesai ketika eksekusi main thread sampai di baris ini.
             * Selesai atau tidaknya status task bisa check dengan menggunakan property IsCompleted dalam tipe data boolean.
             */
            Console.WriteLine($"First Number Task is Complete: {firstNumberTask.IsCompleted}");
            Console.WriteLine($"Print Message Task is Complete: {printMessageTask.IsCompleted}");

            /* OnCompleted akan tertunda karena lamanya proses dari setiap task.
             * Di sini membuktikan bahwa method OnCompleted akan benar-benar menunggu secara asynchronous
             * selesainya setiap task.
             */
            awaiterFirstNumber.OnCompleted(() => {
                Console.WriteLine($"First Number Task is Complete: {firstNumberTask.IsCompleted}");
                Console.WriteLine($"First Number: {awaiterFirstNumber.GetResult()}");
            });
            awaiterPrintMessage.OnCompleted(() => {
                Console.WriteLine($"Print Message Task is Complete: {printMessageTask.IsCompleted}");
            });

            Thread.Sleep(5000);
        }
    }
}
