using System;
using System.Threading;

namespace ThreadLock
{
    class Program
    {
        static void Main(string[] args) {
            /*
             * Fungsi-fungsi di Aplikasi ini digunakan untuk tujuan experiment dan belajar, karena itu bentuknya juga merupakan perumpamaan, 
             * sebagian dari fungsi memang dibuat salah untuk memperlihat cara bekerja Threads.
             * 
             * Tolong di uncomment khusus 1 function yang ingin di coba.
             */

            //CapturedVariable();
            //TemporaryVariable();
            //SynchronizingOutput();
            //ThreadLocalState();
            //FillWaterSimulation.PenuhkanWadahSendirian();
            //FillWaterSimulation.PenuhkanWadahBersama();
            //FillWaterSimulation.SimulasiPerbedaanKecepatan();
            //FillWaterSimulation.SimulasiOverflow();
            //FillWaterSimulation.FailedSimulasiLocked();
            //FillWaterSimulation.SimulasiLocked();
        }

        /// <summary>
        /// Fungsi ini bertujuan untuk menunjukan perbedaan kecepatan thread saat start dan eksekusi, dimana setiap thread menggunakan shared variable bersama.
        /// </summary>
        public static void CapturedVariable() {
            /*
             * Perhatikan code loop di bawah ini.
             * Apabila saya melakukan eksekusi print di bawah ini dengan synchronous biasa tanpa menggunakan Worker Thread, tentu hasil indexnya akan berurut seperti:
             * 0, 1, 2, 3, 4, 5, 6, 7, 8, 9
             * 
             * Tetapi kasusnya di sini kita menciptakan Worker Thread baru setiap kali loop dijalankan, maka kita akan melihat hasilnya seperti di bawah ini:
             */
            for (int index = 0; index < 10; index++) {
                new Thread(() => { 
                    Console.WriteLine($"Index:{index}, Thread Id:{Thread.CurrentThread.ManagedThreadId}"); 
                }).Start();
            }

            /*
                Setiap dari kita akan menghasilkan outcome yang berbeda-beda setiap kali kita mencoba mengeksekusi functionnya, kurang lebih seperti di bawah ini:
             
                (1) Index:7, Thread Id:10
                (2) Index:6, Thread Id:4
                (3) Index:8, Thread Id:11
                (4) Index:6, Thread Id:7
                (5) Index:10, Thread Id:13
                (6) Index:6, Thread Id:9
                (7) Index:6, Thread Id:5
                (8) Index:6, Thread Id:6
                (9) Index:9, Thread Id:12
                (10) Index:6, Thread Id:8

                Bisa kalian simpulkan kalau kita tetap akan menghasilkan 10 hasil print, sesuai dengan ekspektasi, karena akan ada 10 Worker Thread yang dibuat oleh loop di atas, tetapi
                ada beberapa hal yang janggal dengan hasilnya, kurang lebih
                    1) Index tidak berurut, karena jelas di sini Index 10 berada di tengah, sedangkan 7, 8 dan 9 keluar mendahulukan 6.
                    2) Banyaknya index yang sama keluar, dalam kasus ini index 6 keluar sebanyak 6 kali dari hasil ini.
                    3) Apa yang terjadi dengan value 0 - 5?
                    4) Index 10 tetap keluar, padahal kondisi loop kita adalah (index < 10).
                
                Mengapa terjadi hal seperti di atas?

                1) Jawaban dari: Index tidak berurut

                    Yang pasti dapat kita simpulkan adalah dalam Worker Thread, Thread Id terkecil adalah yang diciptakan terlebih dahulu. Diatas menunjukan urutan eksekusi dari print, bukan urutan
                    pembuatan dan Start dari Threadnya. Kalau kita bisa urutkan sesuai dengan urutan pembuatannya, maka hasilnya akan seperti di bawah ini:

                    (2) Index:6, Thread Id:4
                    (7) Index:6, Thread Id:5
                    (8) Index:6, Thread Id:6
                    (4) Index:6, Thread Id:7
                    (10) Index:6, Thread Id:8
                    (6) Index:6, Thread Id:9
                    (1) Index:7, Thread Id:10
                    (3) Index:8, Thread Id:11
                    (9) Index:9, Thread Id:12
                    (5) Index:10, Thread Id:13
                
                    Perhatikan index di atas, walaupun banyak yang valuenya sama, tetapi saat kita mengurutkan Thread Id nya, maka Indexnya otomatis akan berurutan juga.
                    Itu karena tidak mungkin index 7, 8, 9 dan 10 dibuat sebelum index 6, karena increment dari loopnya pasti ke arah lebih besar.
                    
                    Ibaratkan seperti balapan mobil, walaupun posisi start mereka sesuai dengan urutan Thread Id, tetapi ketika para thread ini balapan di dalam processor core,
                    performance bersifat relative naik turun, sehingga mereka susul-susulan.
                    Kesimpulan hasil balapan: walau Thread Id 4 start di posisi paling awal, namun dia di susul oleh Thread Id 10 di urutan ke 7. Walaupun Thread Id 13 di urutan terakhir,
                    namun dia bisa menyusul yang lain sampai akhirnya dia diurutan ke 5.

                2) Jawaban dari: Banyak index yang kembar

                    Karena seluruh index value diambil dari variable dengan reference number yang sama. Itu dikarenakan index adalah variable yang di simpan pada global heap dari
                    sudut pandang setiap thread. Ketika index mencapai value 6, ada 6 buah thread yang mengambil value tersebut secara bersamaan dari chunk of memory yang sama.

                3) Jawaban dari: Apa yang terjadi dengan 0 - 5

                    Kita bisa membagi proses di atas menjadi 3 tahap, yaitu:
                    1) ketika thread dibuat dan di start
                    2) ketika value dari index diambil
                    3) ketika Console.WriteLine bekerja dan print hasil value.

                    Ketika Thread Id: 4 dibuat dan di start, Index saat itu memang bernilai 0, tetapi ketika value dari index diambil oleh thread, 
                    putaran loop sudah sampai putaran ke 7, dimana nilai atau value index sudah mencapai 6. Bisa saya simpulkan bahwa di 6 putaran pertama, 
                    tahap value diambil dari index belum terjadi sama sekali.
                    
                    (Dibuat 1, Diambil 1, Diprint 2) Index:6, Thread Id:4
                    (Dibuat 2, Diambil 1, Diprint 7) Index:6, Thread Id:5
                    (Dibuat 3, Diambil 1, Diprint 8) Index:6, Thread Id:6
                    (Dibuat 4, Diambil 1, Diprint 4) Index:6, Thread Id:7
                    (Dibuat 5, Diambil 1, Diprint 10) Index:6, Thread Id:8
                    (Dibuat 6, Diambil 1, Diprint 6) Index:6, Thread Id:9
                    (Dibuat 7, Diambil 2, Diprint 1) Index:7, Thread Id:10
                    (Dibuat 8, Diambil 3, Diprint 3) Index:8, Thread Id:11
                    (Dibuat 9, Diambil 4, Diprint 9) Index:9, Thread Id:12
                    (Dibuat 10, Diambil 5, Diprint 5) Index:10, Thread Id:13

                4) Jawaban dari: Kenapa ada index dengan value 10

                    Karena value dari index memang berhasil ditambahkan sampai 10, namun index ke 10 tidak diijinkan masuk ke dalam for loop karena
                    condition dari for loop yang index < 10.

                    Karena ketika perintah di dalam thread di jalankan ketika index 9, namun di ambil valuenya ketika index sudah mencapai 10.
             */
        }

        /// <summary>
        /// Mengkoreksi fungsi CapturedVariable, dimana strategy pada fungsi ini adalah membuat multiple temporary variable
        /// </summary>
        public static void TemporaryVariable() {
            /*
             * Dari function CapturedVariable, kita akan sedikit melakukan modifikasi pada loop di bawah ini, kita akan menambahkan
             * temporary variable tepat di dalam for loop code-block
             */
            for (int index = 0; index < 10; index++) {
                int temporary = index;
                new Thread(() => { 
                    Console.WriteLine($"Index: {temporary}, Thread Id: {Thread.CurrentThread.ManagedThreadId}"); 
                }).Start();
            }

            /*
                Lihatlah contoh hasilnya:

                (1) Index: 6, Thread Id: 10
                (2) Index: 8, Thread Id: 12
                (3) Index: 3, Thread Id: 7
                (4) Index: 0, Thread Id: 4
                (5) Index: 1, Thread Id: 5
                (6) Index: 2, Thread Id: 6
                (7) Index: 7, Thread Id: 11
                (8) Index: 4, Thread Id: 8
                (9) Index: 5, Thread Id: 9
                (10) Index: 9, Thread Id: 13

                Lain dengan contoh function sebelumnya, sekarang value index sudah tidak lagi ada yang kembar, tetapi urutannya masih acak.
                Value dari index tidak lagi kembar dikarenakan sebenarnya ada 10 temporary variable di dalam global heap, tetapi memiliki nomor reference yang berbeda-beda.

                Seperti yang kalian pernah pelajari sebelumnya mengenai GC, walaupun temporary variable yang dibuat di loop awal sudah tidak mungkin di raih lagi oleh
                code dengan menggunakan nama pada loop selanjutnya, tetapi masih ada kemungkinan digapai oleh Thread yang masih memiliki utang untuk get value tersebut.
                Karena variable tersebut masih berpotensi untuk di raih sebelum seluruh thread selesai dan dibersihkan oleh GC.

                Apabila kita urutkan, nomor thread dan index value masih akan berurutan:

                (4) Index: 0, Thread Id: 4
                (5) Index: 1, Thread Id: 5
                (6) Index: 2, Thread Id: 6
                (3) Index: 3, Thread Id: 7
                (8) Index: 4, Thread Id: 8
                (9) Index: 5, Thread Id: 9
                (1) Index: 6, Thread Id: 10
                (7) Index: 7, Thread Id: 11
                (2) Index: 8, Thread Id: 12
                (10) Index: 9, Thread Id: 13
             */
        }

        /// <summary>
        /// Contoh salah lainnya, dimana multi-threading kehilangan fungsinya sebagai parallel process dan malah menjadi synchronous programming.
        /// </summary>
        public static void SynchronizingOutput() {
            for (int index = 0; index < 10; index++) {
                var thread = new Thread(() => {
                    Console.WriteLine($"Index: {index}, Thread Id: {Thread.CurrentThread.ManagedThreadId}");
                });
                thread.Start();
                thread.Join();
            }
            /*
             * Dengan menggunakan Join, semuanya akan kembali berurutan, tetapi... thread pada code ini menjadi mubazir,
             * dikarenakan seluruh worker thread juga harus menunggu thread yang lain selesai baru dia melakukan proses mengambil value dan eksekusi print hasil.
             * Contoh code diatas membuat fungsi tidak berbeda dengan synchronous programming. Oleh karena itu asynchronous berguna untuk sesuatu yang hasilnya ekspektasikan bisa
             * berjalan parallel.
             */
        }

        /// <summary>
        /// Fungsi ini menunjukan bahwa setiap thread juga bisa menyimpan variable yang bisa bersifat local terhadap fungsi-fungsi yang dialokasi ke dalam thread tersebut.
        /// </summary>
        public static void ThreadLocalState() {
            /*
             * Sebelumnya dibuktikan bahwa setiap thread bisa menggapai global heap, dimana developer harus berhati-hati, karena
             * waktu yang dibutuhkan thread untuk mengeksekusi dan memproses global variable sangat random, dimana perubahan value pada variable bisa terjadi di setiap saat
             * proses thread.
             * 
             * Oleh karena itu pada experiment kali ini kita akan mencoba membagikan local variable untuk setiap thread, sehingga masing-masing thread
             * bisa menyimpan valuenya masing masing. Dalam kasus ini seluruh FunctionLoop adalah milik setiap thread, dan input parameter yang diterima tiap function berbeda-beda.
             * 
             * Maka nilai 0 atau 1 atau 2 bisa di record independent oleh setiap Thread.
             * Kemungkinan setiap nilai ini disimpan oleh registers pada thread.
             */
            new Thread(FunctionLoop).Start(0);
            new Thread(FunctionLoop).Start(1);
            FunctionLoop(2);
        }

        public static void FunctionLoop(object input) {
            for (int index = 0; index < 1000; index++) {
                Console.Write(input);
                Thread.Sleep(1);
            }
        }

    }
}
