using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace IntroductionToThread
{
    /*
     * Setiap aplikasi kalian membuat sebuah variable, object, atau delegates, semua isi valuenya akan di simpan 
     * di dalam satu potong memory yang disebut juga dengan HEAP.
     * 
     * Ketika aplikasi kalian menemukan suatu function invocation (pemanggilan fungsi), lalu fungsi itu memanggil fungsi lain, fungsi lainnya memanggil fungsi lainnya lagi dan
     * seterusnya, rantai urutan pemanggilan fungsi itu akan di ingat dan akan dipanggil sesuai urutannya.
     * Rantai urutan pemanggilan fungsi ini di simpan di dalam satu memory yang di sebut juga dengan STACK / CALL STACK.
     * 
     * Heap dan Stack hal yang berbeda. Heap akan ada terus sampai dispose atau GC membuangnya.
     * Seluruh function invocation yang terdaftar di stack akan dibuang ketika eksekusi function tersebut telah selesai dijalankan, dan
     * apabila fungsi tersebut dipanggil lagi di tempat lain, maka akan dimasukan lagi ke stack.
     * 
     * Kalau kalian dengar kata Stack, ini namanya sama seperti jenis collection yang kita belajar di chapter collection, karena sebetulnya memang
     * stack yang sama. Dimana fungsi yang terakhir di masukan ke dalam stack akan dipanggil dan dihapus terlebih dahulu (sama dengan konsep collection pada stack).
     * 
     * Lalu apa itu THREAD?
     * Thread adalah jalur eksekusi independent yang menjadi 1 unit yang bisa dikerjakan atau di utilize 1 CPU Core / Atau Processor Core, dimana setiap Thread
     * memiliki call stack pribadinya masing-masing. Apa maksudnya? Sebelum membahas lebih lanjut, mari kita kenal 2 macam programming language dahulu.
     * 
     * Ada 2 jenis programming language, yang sifatnya Single-Thread dan Multi-Thread, artinya sangat jelas, ada programming language yang hanya
     * memiliki 1 Thread dan ada programming language yang bisa membuat lebih dari 1 thread.
     * 
     * C++, Java, C# adalah contoh programming language yang bisa membuat lebih dari 1 thread karena mereka Multi-Thread Programming Language.
     * Lain dengan Javascript yang merupakan Single-Thread Programming language. (apabila kita belajar javascript, kita tidak akan menemukan chapter Thread ini)
     * 
     * Karena C# bisa memiliki lebih dari 1 thread dan setiap thread memiliki call-stacknya masing-masing, maka bisa saya simpulkan kalau C# bisa memiliki lebih dari
     * 1 call-stack collection. Dan setiap call-stack itu bisa dijalankan secara bersamaan masing-masing. 
     * Iya betul! kita bisa mengeksekusi 2 function sekaligus, inilah yang di sebut dengan Parallel Processing yang dijalankan secara Asynchronous.
     * (Asynchronous adalah teknik menjalankan 2 fungsi atau proses sekaligus, tanpa harus menunggu fungsi sebelumnya selesai, bisa dibilang susul-susulan)
     * 
     * Kalau begitu... Single-thread language seperti javascript tidak akan bisa melakukan process asychronous? Lalu kenapa ada yang namanya AJAX?
     * (Asyncrhonous Javascript XML) Nah itu adalah magic dari javascript yang diajarkan di dalam handout javascript, tidak di sini.
     * 
     * Global Heap, Data, Files dan lain-lain akan di share bersama antar thread.
     * Sedangkan call-stack dan register akan dimiliki thread masing-masing. 
     * (register adalah sepenggal data yang disimpan dan dibaca oleh masing-masing thread untuk keperluan processing)
     * 
     * Contoh:
     * 
     * PCB (Process Control Block)
     * 
     * GLOBAL HEAP, DATA, FILES
     * 
     * Thread 1:
     * Call-stack 1
     * Register 1
     * 
     * Thread 2:
     * Call-stack 2
     * Register 2
     * 
     */

    class Program
    {
        static void Main(string[] args) {

            /*
             * Ketika kita menulis code atau memanggil fungsi seperti biasa, kita sudah menulis di atas thread sebenarnya.
             * Thread yang secara otomatis sudah dibuatkan dari awal pertamakali untuk kita disebut juga MAIN THREAD (Thread Utama).
             * 
             * Setiap Thread memiliki unique ID (sama seperti auto increment pada sql) yang bisa di get dengan menggunakan: Thread.CurrentThread.ManagedThreadId
             * Dan kita bisa mendapatkan namanya dengan: Thread.CurrentThread.Name
             */
            Thread.CurrentThread.Name = "Thread Utama";
            Console.WriteLine($"Function Main, THREAD -> Id:{Thread.CurrentThread.ManagedThreadId}, Nama: {Thread.CurrentThread.Name}");
            FunctionOne();

            /*
             * Kita bisa membuat thread baru dengan cara membuat object Thread dengan library System.Threading.
             * Thread baru yang dibuat manual dengan object Thread ini disebut juga sebagai Worker Thread (Thread Pekerja)
             */
            Thread threadKedua = new Thread(() => {
                Console.WriteLine($"Function Main, THREAD -> Id:{Thread.CurrentThread.ManagedThreadId}, Nama: {Thread.CurrentThread.Name}");
                FunctionThree();
            });
            threadKedua.Name = "Thread Pekerja 1"; //Kita bisa set Name dari worker thread lewat property Name. (Note! Main Thread kalau diset Name, categorynya akan berubah jadi Worker Thread)
            threadKedua.Start(); //Worker Thread di jalankan dengan method Start()

            FunctionFive(); // Function five masih berada di dalam Main Thread

            //Kita bisa menginstantiate Thread dan langsung menjalankannya
            new Thread(() => {
                Thread.CurrentThread.Name = "Thread Pekerja 2"; //Nama di set dari dalam
                Console.WriteLine($"Function Main, THREAD -> Id:{Thread.CurrentThread.ManagedThreadId}, Nama: {Thread.CurrentThread.Name}");
            }).Start();
            //Perhatikan kalau Thread Pekerja 2 bisa menyusul proses Thread Pekerja 1. Inilah Asychronous Programming.

            /*
             * Chapter Parallel Processing ini saya berikan bagi developer yang sudah baik pemahamannya
             * terhadap basic OOP dan function pada C#, karena kesulitan dan kelemahan utama pada pemrograman multi-thread adalah kesulitan debuggingnya.
             * 
             * Untuk meng-aktifkan tools untuk debugging thread, gunakan menu:
             * Debug > Window > Threads (Ketika di debug mode)
             */
            new Thread(() => {
                Thread.CurrentThread.Name = "Thread Pekerja 3";
                Thread.Sleep(5000); //Kita bisa menghentikan Thread sementara (paused Thread), dengan method Sleep. Parameter dalam milliseconds, artinya 5000 = 5 detik delay.
                Console.WriteLine($"\nFunction Main, THREAD -> Id:{Thread.CurrentThread.ManagedThreadId}, Nama: {Thread.CurrentThread.Name}");
                FunctionSix();
            }).Start();

            //Pada umumnya saat kita ingin menjalankan sebuah function di dalam sebuah thread kita melakukan code seperti di bawah ini.
            new Thread(() => {
                HelloSomebody("Ben");
            }).Start();

            /*Karena parameter pada thread adalah delegates atau meminta function pointer. Kita bisa code seperti dibawah ini. (sama seperti pada call-back di javascript)*/
            new Thread(new ThreadStart(SayHelloWorld)).Start(); //penulisan lama
            new Thread(SayHelloWorld).Start();

            /*
             * Yang menjadi masalah adalah kalau kita mau menggunakan konsep delegates, tetapi function yang diinvoke memiliki parameter.
             * Kita bisa melakukan itu dengan cara memasukan parameter pada method Start.
             * Ini kita sebut juga dengan Parameterized Thread.
             */
            new Thread(new ParameterizedThreadStart(MultiplyByTwo)).Start(3);
            new Thread(MultiplyByTwo).Start(3);

            FunctionSeven();

            /*
             * Keuntungan untuk penggunaan Parallel Processing kurang lebih:
             * 
             * 1. Pada desktop application dengan UI: kita bisa menggunakan parallel process agar UI tidak lag untuk menunggu hasil proses yang sifatnya bisa jadi sedikit lama,
             *      misalnya membaca database atau file.
             * 2. Pada web application: bisa memproses 2 atau lebih request sekaligus, misalnya minta 2 atau lebih data sekaligus untuk ditampilkan di UI dengan menggunakan AJAX.
             * 3. Semakin banyak CPU core computer yang menjadi platform dari aplikasi, maka akan semakin baik performance untuk multithreading (apabila penggunaanya benar).
             *      Sehingga multi-thread akan menjadi peningkat performance aplikasi anda.
             * 4. Kita bisa menggunakan speculative execution dan thread priority untuk meningkatkan performance lebih baik lagi pada kondisi tertentu.
             *      Sehingga kita bisa melihat mana yang harus dikerjakan terlebih dahulu, mana yang bisa dikerjakan nanti dan apa yang efektif dikerjakan bersama.
             *      Nanti ini akan dibahas pada topic-topic setelah ini.
             */
        }

        public static void FunctionOne() {
            Console.WriteLine($"Function One, THREAD -> Id:{Thread.CurrentThread.ManagedThreadId}, Name: {Thread.CurrentThread.Name}");
            FunctionTwo();
        }

        public static void FunctionTwo() {
            Console.WriteLine($"Function Two, THREAD -> Id:{Thread.CurrentThread.ManagedThreadId}, Name: {Thread.CurrentThread.Name}");
        }

        public static void FunctionThree() {
            Console.WriteLine($"Function Three, THREAD -> Id:{Thread.CurrentThread.ManagedThreadId}, Name: {Thread.CurrentThread.Name}");
            FunctionFour();
        }

        public static void FunctionFour() {
            Console.WriteLine($"Function Four, THREAD -> Id:{Thread.CurrentThread.ManagedThreadId}, Name: {Thread.CurrentThread.Name}");
        }

        public static void FunctionFive() {
            Console.WriteLine($"Function Five, THREAD -> Id:{Thread.CurrentThread.ManagedThreadId}, Name: {Thread.CurrentThread.Name}");
        }

        public static void FunctionSix() {
            Thread.Sleep(2000);
            Console.WriteLine($"Function Six, THREAD -> Id:{Thread.CurrentThread.ManagedThreadId}, Name: {Thread.CurrentThread.Name}");
        }

        public static void FunctionSeven() {
            /*
             * Proses di bawah ini adalah satu satu proses paling menunjukan asychronous proses, dimana
             * loop yang menulis angka 0 bisa di selak oleh worker thread yang menulis angka 1.
             * Dan hasilnya bisa berbeda setiap kali di run.
             */
            new Thread(() => {
                for (int index = 0; index < 1000; index++) {
                    Console.Write(1);
                }
            }).Start();
            for (int index = 0; index < 1000; index++) {
                Console.Write(0);
            }
        }

        public static void SayHelloWorld() {
            Console.WriteLine("Hello World.");
        }

        public static void HelloSomebody(string name) {
            Console.WriteLine($"Hello {name}.");
        }

        public static void MultiplyByTwo(object number) {
            /*Parameterized Thread hanya bisa menampung satu object dengan data type object sebagai parameternya, oleh karena itu kita harus melakukan unboxing untuk mengembalikan tipe datanya.*/
            int hasil = ((int)number) * 2;
            Console.WriteLine($"Parameter: {number}, Hasil kali {hasil}");
        }
    }
}
