using Continuation.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Continuation
{
    public static class UtilizingAsynchAndAwait {
        /*  Untuk mempermudah penulisan code pada Task, C# versi 5 membuat syntax penulisan async dan await.
         *  
         *  async merupakan keyword yang ditulis pada deklarasi fungsi. asynch keyword sendiri hanyak syntax yang digunakan untuk
         *  menghindari ambigu dari compiler untuk memahami C# code di dalam body fungsi yang kita tulis.
         *  
         *  Hal-hal yang bisa dilakukan ketika menulis async pada function adalah:
         *  1. Untuk bisa menulis perintah await. Tanpa async, menulis keyword await akan mengakibatkan compile error.
         *  2. Dengan adanya await, memungkin kan kita untuk membuat fungsi yang bisa melakukan return dan run task pada saat function invocation.
         *  
         *  await merupakan operator yang digunakan untuk menunda atau men-suspend evaluasi dari running Task atau invocation asynchronous method
         *  yang mengembalikan running Task. Untuk lebih jelasnya mari kita lihat contoh-contohnya sama-sama.
         */

        /* Untuk mengembalikan running task, kita harus menggunakan keyword async, lalu return typenya Task.
         * 
         * Perhatikan await operator di depan perintah Task.Run().
         * Ini artinya Task akan jadi dan di jalankan ketika function ini dipanggil/diinvoke.
         * Fungsi RunQuotations bisa dipakai untuk menjalankan Task saja atau menerima object task yang sedang jalan.
         */
        public static async Task RunQuotes() {
            await Task.Run(() => {
                Console.WriteLine("Great ambition is the passion of great character.");
            });
        }

        public static void InvokingRunningTasks() {
            /* Ketika kita mencoba memanggil fungsi RunQuotes, IDE akan langsung memberinya warning.
             * Warning notesnya: CS4014 Because this call is not awaited, execution of the current method continues before the call is completed. 
             *      Consider applying the 'await' operator to the result of the call.
             *      
             * Warning ini tidak akan menyebabkan error dan semua berjalan sebagai mestinya, tetapi peringatan diberikan karena Compiler dari IDE
             * tidak mendeteksi adanya salah satu dari await operation atau object yang menerima task tersebut.
             */
            RunQuotes();

            //Perhatikan pemanggilan fungsi dibawah ini tidak terkena warning karena ada object Task yang menerima
            Task runQuotesTask = RunQuotes();

            /* Apabila anda code C# di versi 7 ke atas, kita bisa menggunakan features discards, yang ditulis dengan _ (underscore).
             * discards (dibuang) adalah pengganti variables yang memang dimaksudkan untuk tidak digunakan, atau bisa dibilang unassigned variables (tidak ada valuenya).
             * discards bisa dipakai dalam kasus seperti ini untuk melakukan suppression terhadap warning atau bisa digunakan untuk membuang property pada object deconstructor.
             */
            _ = RunQuotes();

            //Tetapi pada fungsi ini, penulisan operator await tidak memungkinkan karena InvokingRunningTasks() merupakan function tanpa async keyword.
            //await RunQuotes();
            AsyncInvokingRunningTask(); //Check fungsi ini.

            /* Warning diatas terjadi karena memanggil asynchronous task dari function tanpa mengantisipasinya sedikit kurang best practice dikarenakan:
             * 1. Task akan langsung berjalan tanpa developer menyadari kalau function tersebut sepenuhnya menjalankan fungsi asynchronous, developer tidak bisa mengantisipasinya dengan mudah,
             *      sehingga buruknya readability dari code.
             * 2. Tanpa await ataupun task object, selesainya proses asychronous tidak bisa diantisipasi, sehingga ke depannya tidak memungkinkan untuk melakukan continuity.
             *      Concurrency dari jalannya aplikasi pun sulit dicapai.
             */

            Task.Delay(1000).Wait();
        }

        public static async void AsyncInvokingRunningTask() {
            /* Dengan menuliskan async keyword, kita bisa menggunakan operator await.
               Dengan begini sudah sangat jelas kalau RunQuotes() merupakan asynchronous proses.
             */
            await RunQuotes();
        }

        /* Note!: Hati-hati jangan sampai tertukar antara function async Task dengan function Task.
         * 
         * Function async Task adalah function yang menjalankan sekaligus mengembalikan task yang sudah di run atau dijalankan. Keyword await penting di sana karena
         *      Task sudah jalan dan diantisipasi dengan await. (Nanti pada topik ini akan dibahas lebih jauh).
         *      
         * Function Task atau function dengan return data type Task, adalah function biasa yang mengembalikan object dengan tipe data Task. Task yang dikembalikan
         * pada function ini tentunya belum di run dan harus di start nantinya ketika diterima dalam bentuk object. Karena Task belum dijalankan, function ini belum melakukan
         * proses asynchronous apa pun, oleh karena itu tidak perlu di label async karena tidak ada proses awaitnya.
         */
        public static Task PromiseToPrintQuotes(string message) {
            Task printMessageTask = new Task(() => {
                Console.WriteLine(message);
            });
            return printMessageTask;
        }

        public static void ExecuteReturnedTask() {
            //Baru di start di sini functionnya.
            PromiseToPrintQuotes("Impossible is a word to be found only in the dictionary of fools").Start();
            Task.Delay(1000).Wait();
        }

        /* Seperti function pada umumnya, tentunya asychronous function juga bisa menerima parameter.*/
        public static async Task HelloSomeone(string name) {
            await Task.Run(() => {
                for (int index = 0; index < 3; index++) {
                    Console.WriteLine($"Hello {name}");
                    Task.Delay(1000).Wait();
                }
            });
        }

        /// <summary>
        /// Function ini mengeksekusi 2 synchronous code dan memanggil 3 asynchronous code, oleh karena fungsi ini memiliki async keyword, operator await sudah pasti bisa digunakan pada
        /// asynchronous proses pada fungsi ini.
        /// 
        /// Perintah synchronous diperlihatkan dalam bentuk print string ke console seperti biasa, pada awal dan akhir fungsi.
        /// Dengan experiment dibawah ini, kita bisa melihat bagaimana hasil dari fungsi AwaitingProcess ini ketika diproses.
        /// 
        /// Note!: Kalian bisa membuat async void function, tetapi tidak bisa membuat function async <Type>.
        /// async tidak boleh langsung me-return tipe data tanpa menggunakan Task, karena tidak ada capability dari C# untuk menangkap asynchronous return result tanpa menggunakan task.
        /// </summary>
        public static async void AwaitingProcess() {
            Console.WriteLine("Hello People execution, Begin.");
            await HelloSomeone("Rudy");
            await HelloSomeone("Jack");
            await HelloSomeone("Ben");
            Console.WriteLine("Hello People execution, End.");
        }

        /// <summary>
        /// Fungsi di bawah ini hanya melakukan eksekusi biasa pada AwaitingProcess, tetapi hasil pada fungsi ini tidak lengkap.
        /// Kalau kalian perhatian, hanya Console.WriteLine("Hello People execution, Begin.") dan sebagian dari HelloSomeone("Rudy") yang keluar hasilnya di console.
        /// 
        /// Itu karena seluruh await pada AwaitingProcess() tidak melakukan blocking, sehingga seluruh AwaitingProcess() masih bersifat parallel, tetapi pada umumnya
        /// pada asynchronous process, Console.WriteLine("Hello People execution, End.") di akhir statement akan menyusul seluruh HelloSomeone() yang prosesnya lebih lambat.
        /// </summary>
        public static void ExecuteAwaitingProcess() {
            AwaitingProcess();
        }

        /// <summary>
        /// Untuk memperlihatkan cara kerjanya lebih jelas, kita akan memanggil AwaitingProcess() sekali lagi, tetapi kali ini kita akan delay task pada main thread untuk melihat hasil complete
        /// pada AwaitingProcess(). Dan hasilnya:
        /// 
        /// Hello People execution, Begin.
        /// Hello Rudy
        /// Hello Rudy
        /// Hello Rudy
        /// Hello Jack
        /// Hello Jack
        /// Hello Jack
        /// Hello Ben
        /// Hello Ben
        /// Hello Ben
        /// Hello People execution, End.
        /// 
        /// Semuanya terurut seperti pada sychronous function. Tidak ada Hello Jack dan Hello Ben yang menyusul Hello Rudy walaupun jedah antar print sudah di delay.
        /// "Hello People execution, End." juga tetap menunggu seluruh Hello People melakukan print.
        /// </summary>
        public static void DelayingAwaitingProcess() {
            AwaitingProcess();
            Task.Delay(10000).Wait();
        }

        /* =====================================================================================================================================
         * Kesimpulannya:
         * 
         * await adalah operator yang membuat eksekusi satu parallel task menunggu untuk diselesaikan, baru task lainnya bisa mulai diproses.
         * Lalu pertanyaannya, apa yang membedakan operator await dengan method Wait()?
         * 
         * Lain dengan Wait() method, sebuah task yang dioperasikan oleh await masih merupakan non-blocking proses di dalam fungsinya.
         * Wait() method sendiri merubah parallel proses (non-blocking proses) menjadi synchronous proses.
         * =====================================================================================================================================
         * 
         * Contoh await VS Wait() sendiri bisa dilihat pada contoh di bawah:
         */

        /// <summary>
        /// Lihatlah contoh dibawah ini, fungsi dibawah ini memiliki 3 Task, dimana fungsi diawali oleh Intial Task yang jalannya lambat,
        /// lalu ditengahnya terdapat sebuah task yang dioperasikan dengan Wait() method,
        /// lalu terakhir adalah Last Task yang beroperasi lebih cepat tapi ada setelah Task dengan Wait() method.
        /// </summary>
        public static async void WaitingLoop() {
            _ = Task.Run(() => {
                for (int index = 0; index <= 10; index++) {
                    Console.WriteLine($"Intial Task. Index: {index}");
                    Task.Delay(1000).Wait();
                }
            });

            var waitingTask = Task.Run(() => {
                for (int index = 0; index <= 10; index++) {
                    Console.WriteLine($"Waiting Task. Index: {index}");
                    Task.Delay(500).Wait();
                }
            });
            waitingTask.Wait();
            /* Method Wait() akan merubah total isi dari waitingTask menjadi Synchronous.
             * Setelah di proses dengan Wait(), kita bisa imajinasikan kalau waiting task di pindah ke dalam Main Thread dan sifatnya pun menjadi seperti Foreground Thread.
             */

            _ = Task.Run(() => {
                for (int index = 0; index <= 10; index++) {
                    Console.WriteLine($"Last Task. Index: {index}");
                    Task.Delay(500).Wait();
                }
            });
        }

        public static void ExecuteWaitingLoop() {
            /* Tanpa menggunakan Delay() atau Sleep(), Initial Task akan diproses separuhnya, lalu Waiting Task akan diproses seluruhnya,
             * Last Task hampir tidak diproses.
             * Itu dikarenakan semuanya diproses selama Waiting Task masih berjalan saja.
             * 
             * Apabila kalian uncomment Task.Delay(), semuanya akan ditunggu sampai selesai selama 15 detik.
             */
            WaitingLoop();
            //Task.Delay(15000).Wait();
        }

        /// <summary>
        /// Lihatlah contoh dibawah ini, fungsi dibawah ini memiliki 3 Task, dimana fungsi diawali oleh Intial Task yang jalannya lambat,
        /// lalu ditengahnya terdapat sebuah task yang dioperasikan dengan await operation,
        /// lalu terakhir adalah Last Task yang beroperasi lebih cepat tapi ada setelah Task dengan await task.
        /// </summary>
        public static async void AwaitLoop() {
            _ = Task.Run(() => {
                for (int index = 0; index <= 10; index++) {
                    Console.WriteLine($"Intial Task. Index: {index}");
                    Task.Delay(1000).Wait();
                }
            });
            await Task.Run(() => {
                for (int index = 0; index <= 10; index++) {
                    Console.WriteLine($"Await Task. Index: {index}");
                    Task.Delay(500).Wait();
                }
            });
            _ = Task.Run(() => {
                for (int index = 0; index <= 10; index++) {
                    Console.WriteLine($"Last Task. Index: {index}");
                    Task.Delay(500).Wait();
                }
            });
        }

        public static void ExecuteAwaitLoop() {
            /* Tanpa meng-uncomment Task.Delay, tidak ada hasil yang keluar sama sekali, dikarenakan seluruh task diatas tetap berada di dalam Thread Pool,
             * dan sifatnya seperti selayaknya Background Thread.
             * 
             * Itulah perbedaanya await dengan Wait(). Walaupun await menunggu eksekusi satu task selesai, tetapi eksistensinya tetap berada di dalam non-blocking proses.
             * Apabila kita uncomment Task.Delay, hasilnya akan sama persis dengan ExecutingWaitingLoop().
             */
            AwaitLoop();
            //Task.Delay(15000).Wait();
        }

        /* Asynchronous function juga bisa mengembalikan sebuah value pastinya.
         * Variable atau object yang akan dikembalikan harus berada secara global dari Task.Run code-block.
         * 
         * Note!: Kalian bisa membuat async void function, tetapi tidak bisa membuat function async <Type>.
         * async tidak boleh langsung me-return tipe data tanpa menggunakan Task, karena tidak ada capability dari C# untuk menangkap asynchronous return result tanpa menggunakan task.
         */
        public static async Task<int> MultiplyTwoNumbers(int numberOne, int numberTwo) {
            int result = 0;
            await Task.Run(() => {
                result = numberOne * numberTwo;
            });
            return result;
        }

        /*Berikut ini adalah contoh kalau kita mengembalikan nilai pada tipe data reference type.*/
        public static async Task<Bus> CreateBus(string name, decimal cost) {
            Bus bus = new Bus();
            await Task.Run(() => {
                bus.Name = name;
                bus.Cost = cost;
            });
            return bus;
        }

        /// <summary>
        /// Kegunaan await bukan hanya seperti yang dijelaskan di atas, tetapi juga mengambil hasil return result value dari Task<Type>, tanpa
        /// menggunakan Result atau GetResult() yang sifatnya Sychronous.
        /// 
        /// Dengan begini performance await akan tetap dipertahankan sebagai non-blocking proses.
        /// </summary>
        public static async void AsynchronousReturnResult() {    
            Task<int> multiplicationTask = MultiplyTwoNumbers(6, 7);
            Task<Bus> createBusTask = CreateBus("Trans Jakarta", 3500);      
            int multiplicationResult = await multiplicationTask;
            Bus createBusResult = await createBusTask;
            Console.WriteLine($"Hasil multiplication: {multiplicationResult}");
            Console.WriteLine($"Hasil create bus: {createBusResult.Name}");
        }

        public static void ExecuteAsynchronousReturnResult() {
            AsynchronousReturnResult();
            Task.Delay(1000).Wait();
        }

    }
}
