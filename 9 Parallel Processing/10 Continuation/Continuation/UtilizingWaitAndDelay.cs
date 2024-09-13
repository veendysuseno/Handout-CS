using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Continuation
{
    public static class UtilizingWaitAndDelay
    {
        public static void WaitingForTask() {
            /* Pada function kali ini, kita akan mencoba method Wait().
             * Wait() yang artinya sangat literal adalah method yang digunakan untuk menunggu sebuah taks menyelesaikan prosesnya sampai complete.
             * Jadi sebelum task IsCompleted, dia tidak boleh melewati Wait.
             */
            Task<int> firstNumberTask = Task.Run(() => {
                Thread.Sleep(3000);
                return 7;
            });
            firstNumberTask.Wait();
            /* Tanpa menggunakan Wait(), statement dibawah ini akan bernilai false, sedangkan yang berada di dalam on completed akan bernilai true.
             * Tetapi kali ini print status complete dari first number juga akan bernilai true, bahkan akan tertunda selama 3 detik, karena
             * first number task sudah harus completed untuk melewati Wait() method.
             */
            Console.WriteLine($"First Number Task is Complete: {firstNumberTask.IsCompleted}");
            TaskAwaiter<int> awaiterFirstNumber = firstNumberTask.GetAwaiter();
            awaiterFirstNumber.OnCompleted(() => {
                Console.WriteLine($"First Number Task is Complete: {firstNumberTask.IsCompleted}");
                Console.WriteLine($"First Number: {awaiterFirstNumber.GetResult()}");
            });
            Thread.Sleep(5000);
        }

        public static void SynchronousWait() {
            /* Perhatikan experiment Wait dibawah ini, di sini ada 2 task, dimana yang pertama memiliki waktu 2 kali lebih lambat dari yang kedua untuk diselesaikan.
             * Tetapi method Wait saya hanya berikan pada secondNumberTask saja.
             * Itu artinya fungsi ini tidak akan perduli dan menunggu dari firstNumberTask.
             */
            var firstNumberTask = Task.Run(() => {
                Thread.Sleep(4000);
                return 7;
            });
            var secondNumberTask = Task.Run(() => {
                Thread.Sleep(2000);
                return 8;
            });
            secondNumberTask.Wait(); 
            /* Tanpa menggunakan Wait, kedua printing di bawah akan keluar langsung tanpa ada jedah detik yang lama, dan berakhir keduanya false.
             * Tetapi karena kita hanya menunggu secondNumberTask, sudah pasti yang dijamin IsCompleted-nya true adalah yang secondNumberTask.
             * Tetapi dari hasil percobaan ini, walaupun firstNumberTask belum completed, print dari hasil first number juga ikut menunggu selama 2 detik 
             *      (walaupun belum completed karena firstNumberTask butuh 4 detik).
             * 
             * Tidak hanya itu, bahkan printing "Main Thread" yang seharusnya bisa segera pun juga ikut tertunda kurang lebih 2 detik.
             * Ini semua bisa kita simpulkan kalau Wait() method bersifat blocking atau synchronous, tidak seperti pada OnCompleted.
             * 
             * Dalam kasus multiple task, penggunaan Wait() yang kurang tepat bisa memakan performance atau bahkan memboroskan performance tanpa hasil.
             * Contohnya printing status firstNumberTask dan "Main Thread" menunggu selama 2 detik dengan percuma.
             */
            Console.WriteLine($"First Number Task is Complete: {firstNumberTask.IsCompleted}");
            Console.WriteLine($"Second Number Task is Complete: {secondNumberTask.IsCompleted}");
            Console.WriteLine("Main Thread");
        }

        public static void DelayingTask() {
            /* Kita akan mencoba menggunakan method lainnya, yaitu Delay.
             * Delay adalah waktu tunda sebuah task untuk melakukan sesuatu.
             * Pada contoh kali ini kita meng-kombinasikan Delay dengan Wait, sehingga hasilnya seperti Thread Sleep.
             * 
             * Tapi jangan salah, Thread.Sleep() dengan Task.Delay().Wait() bekerja dengan cara yang berbeda.
             * Thread.Sleep() bekerja dengan cara melakukan blocking pada Thread yang saat ini sedang berjalan di dalam Logical Processor.
             * Task.Delay().Wait() bekerja dengan cara menunda jalannya Task, tetapi seluruh Thread berjalan seperti biasa tanpa ada blocking.
             * 
             * Dalam kondisi Logical Processor yang tidak sibuk dengan Thread, penggunaan keduanya terasa sama saja.
             * Tetapi dalam kondisi banyak thread yang menumpuk atau mengantri, Thread.Sleep() akan menyebabkan lebih banyak context switch yang berdampak pada performance.
             * Hal itu tidak terjadi pada Task.Delay().Wait();
             */
            var firstNumberTask = Task.Run(() => {
                Task.Delay(2000).Wait();
                return 7;
            });
            var awaiterFirstNumber = firstNumberTask.GetAwaiter();
            awaiterFirstNumber.OnCompleted(() => {
                Console.WriteLine($"First Number Task is Complete: {firstNumberTask.IsCompleted}");
                Console.WriteLine($"First Number: {awaiterFirstNumber.GetResult()}");
            });
            Task.Delay(3000).Wait();
        }

        public static void DelayingAwaiter() {
            /* Delay bisa dikombinasikan dengan hal lainnya, misalnya dengan Awaiter.
             * Dalam hal ini Task selesai dalam waktu yang sangat cepat, dan OnCompleted sudah mendapat informasi kalau firstNumberTask sudah selesai.
             * Dalam hal ini awaiter yang menunggu 2 detik untuk siap mengeksekusi OnCompleted.
             * 
             * Delay bisa dipakai untuk hal lain juga, nanti kita akan coba pada topik lainnya.
             */
            var firstNumberTask = Task.Run(() => 7);
            Task.Delay(2000).GetAwaiter().OnCompleted(() => {
                Console.WriteLine($"First Number Task is Complete: {firstNumberTask.IsCompleted}");
                Console.WriteLine($"First Number: {firstNumberTask.Result}");
            });
            Task.Delay(3000).Wait();
        }

        public static void WaitingAllTask() {
            int firstNumber = 0, secondNumber = 0, thirdNumber = 0;
            var firstNumberTask = Task.Run(() => {
                Task.Delay(500).Wait();
                firstNumber = 4;
            });
            var secondNumberTask = Task.Run(() => {
                Task.Delay(1000).Wait();
                secondNumber = 5;
            });
            var thirdNumberTask = Task.Run(() => {
                Task.Delay(1500).Wait();
                thirdNumber = 6;
            });
            /* Bagaimana kalau kita ingin menunggu lebih dari 1 task untuk selesai?
             * Apabila kita menginvoke fungsi Wait() untuk ketiga task, maka terjadi sedikit penurunan performance, dikarenakan setiap fungsi Wait() adalah synchronous, walaupun task berjalan secara parallel.
             * Fungsi Wait kedua akan menunggu selesainya fungsi Wait yang pertama, dan fungsi Wait yang ketiga akan menunggu yang kedua.
             * Selain itu membuat 3 fungsi wait juga membuat penulisan code menjadi lebih panjang.
             * 
             * Cara yang lebih baik adalah menggunakan Task.WaitAll. Fungsi ini akan menunggu seluruh Task selesai, atau bisa dikatakan fungsi ini akan menunggu task yang paling lambat selesai dimana
             * task tersebut berada di dalam parameter WaitAll().
             * 
             * Perhatikan contoh di bawah ini, apabila salah satu task saja tidak complete, maka hasil kali sudah pasti 0.
             * Tetapi WaitAll tidak akan membuat itu terjadi.
             */
            Task.WaitAll(firstNumberTask, secondNumberTask, thirdNumberTask);
            Console.WriteLine($"Hasil kali: {firstNumber * secondNumber * thirdNumber}");
        }

        public static void WaitingAnyTask() {
            int firstNumber = 0, secondNumber = 0, thirdNumber = 0;
            var firstNumberTask = Task.Run(() => {
                Task.Delay(500).Wait();
                firstNumber = 4;
            });
            var secondNumberTask = Task.Run(() => {
                Task.Delay(1000).Wait();
                secondNumber = 5;
            });
            var thirdNumberTask = Task.Run(() => {
                Task.Delay(1500).Wait();
                thirdNumber = 6;
            });
            /* WaitAny sifatnya bertentangan dengan WaitAll, WaitAny akan menunggu 1 saja Task tercepat menyelesaikan prosesnya.
             * WaitAny sifatnya sama seperti fungsi race pada javascript (balapan asynchronous).
             * Dalam hal ini sudah pasti hanyak firstNumberTask yang selesai, oleh karena itu di luar dari firstNumber, semua akan bernilai 0.
             */
            Task.WaitAny(firstNumberTask, secondNumberTask, thirdNumberTask);
            Console.WriteLine($"Angka tercepat diantara 3: {firstNumber}, {secondNumber}, {thirdNumber}");
        }

    }
}
