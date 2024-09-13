using BlockingThread.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading;

namespace BlockingThread
{
    class Program
    {
        static void Main(string[] args) {
            var threadZero = new Thread(PrintDigit);
            var threadOne = new Thread(PrintDigit);
            var threadTwo = new Thread(PrintDigit);

            var awaitingThread = new Thread(() => {
                Thread.Sleep(6000);
                Console.WriteLine("Incoming Thread.");
            });

            var silentThread = new Thread(() => {
                Console.WriteLine("Never be printed");
            });

            /* Perhatikan threads di bawah ini.
             * threadZero dan threadOne adalah 2 threads yang berjalan secara parallel dan saling menyusul.
             * 
             * PrintDigit mengalami sleep setiap 1 millisecond sebelum print hasil digitnya, sehingga kalian sangat bisa melihat
             * campuran yang rata antara 0 dan 1.
             */
            threadZero.Start(0);
            threadOne.Start(1);

            /* Di sini kalian melihat threadOne menggunakan satu method baru, yaitu Join().
             * Join disini merupakan perintah dari sebuah Thread yang sudah hidup (sudah di Start), agar thread-thread yang lain yang belum
             * hidup untuk menunggu thread yang mengeluarkan perintah selesai, tidak perduli processor core ada yang menganggur atau tidak.
             * 
             * Bisa kita lihat, PrintDigit tidak akan melakukan print digit 2 sebelum digit 1 selesai di print habis, atau semua aktifitas
             * thread yang lagi jalan selesai.
             */
            threadOne.Join();

            threadTwo.Start(2); //Print digit 2 akan berkumpul terisolasi sendirian karena perintah Join()
            threadTwo.Join(); //awaitingThread akan menunggu sampai PrintDigit angka 2 selesai dijalankan.

            /*
             * Sebelumnya dibahas bahwa thread setelah join method bisa mengetahui bahwa satu thread masih hidup atau tidak.
             * Kita sebagai developer juga bisa melakukan check status hidup dari sebuah Thread.
             * Thread yang masih jalan bisa dibilang adalah Thread yang Alive (hidup).
             * Oleh karena itu method yang digunakan untuk melakukan check itu adalah isAlive().
             * 
             * Thread yang Alive tidak berarti thread yang aktif. Thread yang aktif adalah yang sedang sibuk melakukan suatu proses eksekusi.
             * Tetapi thread yang aktif sudah pasti adalah thread yang alive;
             * 
             * Thread itu alive ketika dia sudah di start.Misalnya awaiting thread di bawah ini sleep selama 6 detik setelah dijalankan, 
             * walaupun tidak aktif sibuk, thread tersebut tetap alive.
             */
            awaitingThread.Start();
            Console.WriteLine($"Kondisi awaitingThread isAlive: {awaitingThread.IsAlive}");
            Console.WriteLine($"Thread state dari awaitingThread: {awaitingThread.ThreadState}");
            //Walapun alive ThreadStatenya bertuliskan WaitSleepJoin

            /*
             * Diberikan contoh lain untuk status alive dan statenya, misalnya untuk threadTwo.
             * Eksekusi threadTwo sudah selesai dijalankan habis, maka threadTwo sudah tidak lagi alive karena sudah dikesampingkan.
             */
            ThreadState stateThreadTwo = threadTwo.ThreadState;
            Console.WriteLine($"Kondisi threadTwo isAlive: {threadTwo.IsAlive}");
            Console.WriteLine($"Thread state dari threadTwo: {stateThreadTwo}"); //Statenya akan bertuliskan Stopped karena sudah selesai.
            /*ThreadState ditandai dengan enum, kalian bisa check enumnya pada library dan di sana kalian bisa melihat macam-macam state dari sebuah Thread.*/

            /*
             * Untuk thread yang tidak pernah dijalankan sama sekali hasilnya seperti di bawah ini.
             */
            Console.WriteLine($"Thread State dari silentThread: {silentThread.ThreadState}"); //Statenya masih Unstarted karena belum di start.
            Console.WriteLine($"Kondisi silentThread isAlive: {silentThread.IsAlive}"); //Dia belum Alive karena belum Start

            /*
             * Mengenal status dan state dari Thread, maka bisa dikatakan saat sebuah Thread menghabiskan durasi waktu untuk menyelesaikan
             * seluruh eksekusinya, Thread tersebut dalam keadaan bound atau terikat.
             * 
             * Thread bisa mengalami I/O Bound atau Compute Bound.
             * 
             * I/O Bound dialami pada saat Thread sleep, atau menunggu http menyelesaikan requestnya, atau pada saat Thread tersebut meminta input user serperti Console.Readline().
             *      (Bisa dikatakan thread tersebut hidup tapi menunggu durasi dan tidak sibuk).
             * 
             * Compute Bound dialami ketika Thread berada di durasi lama menyelesaikan eksekusi karena eksekusi yang dijalankannya adalah proses yang berat.
             *      Pada saat compound bound, aktifitas CPU akan intense dan bekerja dengan keras.
             */

            //contoh I/O Bound lain
            awaitingThread.Join();
            var threadPrintNama = new Thread(PrintNama);
            threadPrintNama.Start();
            Console.WriteLine($"threadPrintNama State: {threadPrintNama.ThreadState}"); //Statusnya Running
            threadPrintNama.Join();

            //contoh Compute Bound
            var threadSerialization = new Thread(CollectionSerializationProcess);
            threadSerialization.Start();
            threadSerialization.Join();
            Console.WriteLine("Serialization selesai");

            /*
             * Ketika kita meminta sebuah thread untuk menunggu dengan menggunakan Sleep atau atau Join, kita melakukan hal yang
             * disebut juga Thread Blocking.
             * 
             * Thread Blocking adalah hal yang tidak masalah digunakan, tetapi akan sangat bermasalah ketika developer melakukan
             * yang namanya Thread Spinning.
             * 
             * Thread Spinning adalah melakukan thread blocking berkali-kali ketika menunggu dalam durasi yang sangat lama. Ini akan
             * sangat menyita dan memberatkan processor, sehingga salah satu core dari processor anda akan selalu occupied.
             * 
             * Contoh Spinning seperti di bawah ini:
             */
            DateTime newYear = new DateTime(2022, 1, 1);
            var newYearReminder = new Thread(() => {
                while (DateTime.Today < newYear) {
                    Thread.Sleep(1000);
                }
                Console.WriteLine("Happy New Year.");
            });

            /*
             * Thread di atas tidak saya jalankan karena thread diatas sangat berbahaya.
             * Itu artinya thread akan terus bangun dan tidur setiap satu detik sebelum tahun baru.
             * 
             * (Note: Spinning Thread masih boleh dilakukan kalau kemungkinannya akan dipuaskan dalam durasi yang sangat cepat, dan tidak ada kemungkinan dalam waktu lama)
             */
        }

        public static void PrintDigit(object digit) {
            for (int index = 0; index < 1000; index++) {
                Thread.Sleep(1);
                Console.Write(digit);
            }
        }

        public static void PrintNama() {
            Console.WriteLine("Tolong input nama anda:");
            string nama = Console.ReadLine();
            Console.WriteLine($"Input anda diterima, nama anda: {nama}");
        }

        public static void CollectionSerializationProcess() {
            var products = MakeProducts();
            var options = new JsonSerializerOptions {
                WriteIndented = true
            };
            string jsonString = JsonSerializer.Serialize(products, options);
            string writePath = ReturnPath("products.json");
            using (StreamWriter writer = new StreamWriter(writePath)) {
                writer.WriteLine(jsonString);
            }
        }

        private static string ReturnPath(string fileName) {
            var path = Path.GetFullPath($"../../../Files/{fileName}");
            return path;
        }

        public static List<Product> MakeProducts() {
            var products = new List<Product>() {
                new Product{
                    Id = 2,
                    Name = "Biscuit Regal",
                    Description = "Makanan ringan sehat yang baik untuk pencernaan.",
                    Stock = 250,
                    Price = 25000
                },
                new Product{
                    Id = 4,
                    Name = "Yakult",
                    Description = "Susu Fermentasi",
                    Stock = 50,
                    Price = 15000
                },
                new Product{
                    Id = 6,
                    Name = "Silverqueen",
                    Description = "Coklat susu dengan kacang cashew.",
                    Stock = 80,
                    Price = 12000
                }
            };
            return products;
        }
    }
}
