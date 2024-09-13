using System;
using System.Threading;
using System.Threading.Tasks;

namespace IntroductionToTask
{
    class Program
    {
        /*
         * Kita sudah mempelajari konsep thread sebagai tools untuk melakukan asynchronous programming. Tapi kita semua mengetahui kalau System.Thread
         * memiliki beberapa kelemahan, yaitu di antaranya:
         * 
         * 1. Tidak bisa melakukan return value, sehingga function pertama yang di panggil atau yang terakhir di eksekusi call-stack harus bersifat void.
         *      Kalau dibuat return value tidak akan ada manfaatnya.
         * 2. Untuk berbagi object / variable value dengan thread lainnya, harus menggunakan shared state (menggunakan global variable / field). Dan
         *      ini cukup merepotkan, karena penggunaan global variable yang berlebihan akan membingungkan untuk kebutuhan debugging.
         * 3. Continuity yang buruk, satu-satunya cara memanfaatkan continuity adalah dengan menggunakan Join method atau dengan menggunakan Signal.
         *      Pengunaan Join akan secara otomatis melakukan blocking pada seluruh worker thread lain, dan penggunaan signal akan melakukan blocking pada
         *      salah satu thread yang di tunjuk.
         * 4. Penggunaan Join dan Signal cukup membingungkan apa bila ingin melakukan continuity yang rumit. Readability code pun menurun sehingga sulit dibaca oleh developer lain.
         * 5. Walaupun kita bisa menggunakan Thread Pool untuk menghemat context switch dan oversubscription, membuat object Thread cenderung memakan lebih banyak memory dan
         *      dalam jumlah yang banyak akan sedikit berpengaruh pada performance.
         *      
         * Untuk mengatasi kelima masalah di atas, maka diciptakannyalah Task.
         * Setelah kalian memahami Thread, mungkin banyak dari kalian yang bertanya, "Bagaimana membuat parallel processing tanpa menggunakan thread sama sekali?".
         * Pertanyaan itu tidak tepat, karena sebenarnya, technology dibalik Task adalah Thread Pool, tetapi kita tidak perlu khawatir untuk membuat code atau menginstantiate Thread sama sekali di sini,
         * sehingga kalian tidak perlu lagi membuat object Thread, melainkan kita akan membuat object Task yang cenderung lebih kecil.
         * 
         * Task merupakan content atau procedure di dalam sebuah Thread Pool, yang bisa lanjutkan ataupun dibatalkan.
         * Satu persatu kelebihan Task akan dibahas langkah demi langkah di setiap contoh.
         */
        static void Main(string[] args) {
            /* Uncomment satu per satu untuk melihat hasil experimentnya.*/

            //CreateAndExecutingTasks();
            //TestParallelProcess();
            //TaskReturningValue();
        }

        public static void CreateAndExecutingTasks() {
            /*
             * Kita bisa langsung menjalankan Task dengan cara menggunakan Task.Run(delegates).
             * Untuk membuktikan kalau task menggunakan ThreadPool, kita bisa menggunakan Thread.CurrentThread.IsThreadPoolThread untuk check, dan kita juga bisa
             * melihat perbedaan ThreadId, dan check kalau Task merupakan Background Process seperti.
             */
            Task.Run(() => {
                Console.WriteLine("This come from task one");
                Console.WriteLine($"Thread Id: {Thread.CurrentThread.ManagedThreadId}, Is Thread Pool: {Thread.CurrentThread.IsThreadPoolThread}, Is Background: {Thread.CurrentThread.IsBackground}");
            });

            /*
             * Kita bisa juga menjalankan task dengan cara membuat object Task terlebih dahulu, lalu gunakan Start method untuk menjalankannya.
             * Kita bisa simpulkan Task itu mirip seperti object Promise pada javascript (ecmascript), dimana merupakan deretan pekerjaan yang belum selesai (masih berbentuk janji atau hutang).
             * Pekerjaan pada task bisa di start kapan pun sesuai dengan keinginan developer, dan nantinya kita akan bisa antisipasi kapan task selesai (di chapter continuity).
             */
            Task taskTwo = new Task(() => {
                Console.WriteLine("This come from task two");
                Console.WriteLine($"Thread Id: {Thread.CurrentThread.ManagedThreadId}, Is Thread Pool: {Thread.CurrentThread.IsThreadPoolThread}, Is Background: {Thread.CurrentThread.IsBackground}");
            });
            taskTwo.Start();

            /*
             * Experiment dibawah ini kita menggunakan for loop untuk menjalankan Task. 
             * Cobalah check, apakah Task benar-benar berjalan parallel?
             * Apakah task hanya menjalankan Thread sejumlah Logical Processor pada PC anda?
             * Jawaban di atas seharusnya iya dan iya, dikarenakan Task berlandaskan di atas ThreadPool.
             */
            for (int index = 0; index < 20; index++) {
                Task.Run(() => {
                    Console.WriteLine($"Index {index}, Thread Id: {Thread.CurrentThread.ManagedThreadId}");
                });
            }
            Thread.Sleep(2000); 
            /*
             * Selalu ingat, kalau background process akan stop dimana main thread atau foreground thread terlama selesai.
             * Tetapi karena di dalam code kita saat ini tidak ada pembuatan thread secara manual, maka tidak ada foreground thread sama sekali.
             * Oleh karena itu bisa disimpulkan seluruh task kita akan hidup selama Main Thread masih aktif atau diproses.
             */

            /*
             * Task.Run dan New Task juga bisa diinput delegate atau nama function yang sudah exist.
             */
            Task.Run(new Action(FunctionThree));//Penulisan lama, masing menggunakan action.
            Task.Run(FunctionThree);
            var taskThree = new Task(FunctionThree);
            taskThree.Start();
            //Kita masih bisa menerima object task yang sudah di Run langsung seperti di bawah ini.
            var runningTaskThree = Task.Run(FunctionThree);

            /*
             * Lain dengan thread, penulisan dengan menggunakan parameter harus dituliskan dalam complete lambda, jadi parameter yang akan diberikan pada
             * function tidak bisa menjadi parameter kedua atau ketiga dari Run method. 
             */
            Task.Run(() => PrintName("Joko"));
            Thread.Sleep(2000);
            Console.WriteLine("Main Thread berakhir");
        }

        public static void FunctionThree() {
            Console.WriteLine("This come from function three");
            Console.WriteLine($"Thread Id: {Thread.CurrentThread.ManagedThreadId}, Is Thread Pool: {Thread.CurrentThread.IsThreadPoolThread}, Is Background: {Thread.CurrentThread.IsBackground}");
        }

        public static void PrintName(string name) {
            Console.WriteLine($"Halo {name}, apa kabar?");
        }

        /// <summary>
        /// Function di bawah ini mendemokan proses asynchronous yang masih terlihat jelas dari 2 task saat masing-masing
        /// sleep selama 1 detik setiap jedah.
        /// </summary>
        public static void TestParallelProcess() {
            Task.Run(() => {
                for (int index = 0; index < 10; index++) {
                    Thread.Sleep(1000);
                    Console.WriteLine($"Index {index}, Thread Id: {Thread.CurrentThread.ManagedThreadId}");
                }
            });
            Task.Run(() => {
                for (int index = 0; index < 10; index++) {
                    Thread.Sleep(1000);
                    Console.WriteLine($"Index {index}, Thread Id: {Thread.CurrentThread.ManagedThreadId}");
                }
            });
            Thread.Sleep(10000);
        }

        /// <summary>
        /// Untuk function dibawah ini, kita akan melakukan experiment untuk menerima sebuah return value yang 
        /// dikerjakan oleh Task.
        /// 
        /// Di sinilah salah satu kelebihan Task yang tidak dimiliki Thread, yaitu bisa mengembalikan value
        /// setelah selesai mengerjakan seluruh procedurenya.
        /// </summary>
        public static void TaskReturningValue() {
            /* Apabila task melakukan eksekusi sebuah procedure atau function yang mengembalikan value,
             * object task akan diterima dengan data type dengen generic <tipe data yang di return>.
             */
            Task<bool> getAnswerTask = Task.Run(GetAnswer);
            /* Result bisa diterima dengan menggunakan property Result. Result merupakan proses synchronous, yang artinya pada saat kita mendapatkan valuenya
             * dengan property Result, code akan melakukan block terhadap kelangsungan main thread dan segala yang dieksekusinya.
             */
            bool hasilGetAnswer = getAnswerTask.Result; 
            Console.WriteLine($"Hasil dari GetAnswer: {hasilGetAnswer}");

            /* Kita juga bisa menerima task yang mengembalikan value dengan meng-instantiate Task object.
             * Coba perhatikan, selayaknya generic data type, constructor juga harus menggunakan generic Task.
             */
            Task<string> getCityTask = new Task<string>(GetCity);
            getCityTask.Start();
            Console.WriteLine($"Hasil dari GetCity: {getCityTask.Result}");

            //Mencoba dengan menggunakan function berparameter.
            var multiplyByTwoTask = Task.Run(() => MultiplyByTwo(7));
            Console.WriteLine($"Hasil dari MultiplyByTwo: {multiplyByTwoTask.Result}");

            var multiplyTwoNumbersTask = Task.Run(() => {
                return MultiplyTwoNumbers(5.4, 3.2);
            });
            Console.WriteLine($"Hasil dari MultiplyTwoNumbers: {multiplyTwoNumbersTask.Result}");

            //Mencoba mengembalikan data type reference type.
            Task<Person> createPersonTask = new Task<Person>(() => {
                return CreatePerson("Yusuf", "Laki-laki", "Indonesia");
            });
            createPersonTask.Start();
            var yusuf = createPersonTask.Result;
            Console.WriteLine($"Hasil dari CreatePerson: {yusuf.Name}, {yusuf.Gender}, {yusuf.BirthCountry}");
        }

        public static bool GetAnswer() {
            return true;
        }

        public static string GetCity() {
            return "Jakarta";
        }

        public static int MultiplyByTwo(int number) {
            return number * 2;
        }

        public static double MultiplyTwoNumbers(double numberOne, double numberTwo) {
            return numberOne * numberTwo;
        }

        public static Person CreatePerson(string name, string gender, string country) {
            var ronny = new Person {
                Name = name,
                Gender = gender,
                BirthCountry = country
            };
            return ronny;
        }

    }

}
