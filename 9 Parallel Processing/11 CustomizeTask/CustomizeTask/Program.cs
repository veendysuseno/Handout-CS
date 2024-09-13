using CustomizeTask.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace CustomizeTask
{
    class Program
    {
        static void Main(string[] args) {

            //IntroductionToTaskFactory();
            //ExecutingLongRunningTask();

        }

        public static void IntroductionToTaskFactory() {
            /* Task.Factory.StartNew() adalah method yang digunakan untuk scheduling dan menjalankan Task di .Net versi 4.
             * Setelah .Net framework mencapai versi 4.5, Task.Run() lebih populer digunakan Task.Factory.StartNew().
             * 
             * Tetapi Task.Run() tidak sepenuhnya menggantikan Task.Factory.StartNew().
             * Task.Factory.StartNew() memiliki banyak parameter yang bisa kita konfigurasi secara manual, ini yang membuat Task.Factory.StartNew() lebih lengkap,
             * tetapi lebih rumit untuk digunakan.
             * 
             * Task.Run() sendiri sama dengan Task.Factory.StartNew(() => {}, CancellationToken.None, TaskCreationOptions.DenyChildAttach, TaskScheduler.Default).
             * Dimana parameter-parameter itu dianggap sebagai default oleh Task.Run().
             */
            Task.Factory.StartNew(() => {
                Console.WriteLine("Task From Factory");
            }, CancellationToken.None, TaskCreationOptions.DenyChildAttach, TaskScheduler.Default);
            Task.Run(() => {
                Console.WriteLine("Task From Run Method.");
            });
            Task.Delay(1000).Wait();
        }


        public static void ExecutingLongRunningTask() {
            /* Long running task adalah task yang memiliki banyak aktifitas blocking, delaying, atau sifatnya berlangsung lama.
             * Walaupun Task sudah menggunakan ThreadPool, memiliki banyak long-running task jauh melebih jumlah logical processor kita bisa menghambat performance.
             * Untuk membantuk automatic Task Manager memilih-milih que pada task di thread pool, kita bisa membantunya dengan memberi tahu kalau task ini adalah long-running task.
             * Long running task bisa di set pada enum TaskCreateOptions.
             */
            for (int index = 0; index < 20; index++) {
                Task.Factory.StartNew(() => {
                    Console.WriteLine($"Task Id: {Task.CurrentId}");
                    Task.Delay(2000).Wait();
                }, TaskCreationOptions.LongRunning);
            }
        }

        /* Task dibedakan menjadi 2 berdasarkan kondisi yang dibutuhkan proses untuk menyelesaikan tasknya
         * 
         * 1 I/O Bound: I/O bound adalah kondisi dimana task harus menyelesaikan proses-proses seperti read atau write pada file/ database / local system/ socket pada network network.
         *      Dimana biasanya melibatkan kegiatan mengakses data storage device seperti hard disc / solid state atau data yang diterima dari network seperti API.
         *      I/O Bound melibatkan banyak kegiatan menunggu dikarenakan data yang tidak langsung available detik itu juga untuk di proses.
         *      Kegiatan menunggu ini disebut juga dengan I/O Wait. Banyaknya I/O Wait pada proses akan menghambat performance karena banyak blocking code nya, terutama bila banyaknya I/O Bound lebih dari jumlah logical processor yang ada.
         * 
         * 2 Compute Bound/ CPU Bound: adalah kondisi dimana task menyelesaikan segala macam proses yang tidak termasuk ke dalam I/O Bound, contohnya seperti proses perhitungan
         *      dan eksekusi apapun yang murni terjadi pada temporary memory oleh C#. Misalnya seperti menjalakan logika algorithma-algorithma C# yang biasa kalian code.
         *      Memory yang diakses oleh compute bound biasnya berupa object / collection yang disimpan di RAM.
         *      Proses compute bound biasanya berlangsung sangat-sangat cepat dan bisa dikatakan instant, pada umumnya proses-proses ini bahkan tidak memerlukan background thread atau bahkan
         *      tidak membutuhkan multi-thread sama sekali. Tetapi pada kondisi tertentu, algorithma-algorithma kompleks pada compute bound bisa menghasilkan long-running task yang cukup lama, contohnya
         *      apabila melakukan compressing/decompressing data, code AI untuk video game, analisa data, sorting dalam jumlah yang sangat banyak, blurring image, dan lain sebagainya.
         */

        #region Task Completion Source

        /*
         TaskCompletionSource lets you create a task out of any operation that starts and
            finishes some time later. It works by giving you a “slave” task that you manually
            drive—by indicating when the operation finishes or faults.
         */

        //var taskCompletionSource = new TaskCompletionSource<int>();
        //Task<int> task = taskCompletionSource.Task;

        //Task.Factory.StartNew(() =>
        //{
        //    Thread.Sleep(5000);
        //    taskCompletionSource.SetResult(15);
        //});

        //Stopwatch stopWatch = Stopwatch.StartNew();
        //int result = task.Result;
        //stopWatch.Stop();

        //Console.WriteLine($"{stopWatch.ElapsedMilliseconds} - {result}");

        //var taskCompletionSource = new TaskCompletionSource<bool>();
        //new Thread(() => {
        //    Thread.Sleep(2000);
        //    taskCompletionSource.TrySetResult(true);
        //}).Start();
        //var hasil = taskCompletionSource.Task.Result;
        //Console.WriteLine(hasil);

        public static void IntroductionToTaskCompletionSource() {

            var taskCompletionSource = new TaskCompletionSource<int>();

            var threadOne = new Thread(() => {
                Thread.Sleep(5000);
                taskCompletionSource.SetResult(42);
            });
            threadOne.IsBackground = true;
            threadOne.Start();

            Task<int> slaveTask = taskCompletionSource.Task;
            var hasil = slaveTask.Result;
        }


        public static void CreateCustomRunMethod() {
            Task<TResult> Run<TResult>(Func<TResult> function) {
                var taskCompletionSource = new TaskCompletionSource<TResult>();
                new Thread(() => {
                    try {
                        taskCompletionSource.SetResult(function());
                    } catch (Exception exception) {
                        taskCompletionSource.SetException(exception);
                    }
                }).Start();
                return taskCompletionSource.Task;
            }

            Task<int> task = Run(() => {
                Thread.Sleep(5000);
                return 42;
            });
            //effeknya sama dengan manggil Task.Factory.StartNew dengan LongRunning
        }

        /*
         * Kemampuan utama TaskCompletionSource adalah membuat task yang tidak terikat pada Threads.
         * Contoh di bawah kita bisa menulis tanpa menggunakan thread, jadi menggunakan Timer class.
         */
        public Task<int> GetNumberWithTimerClass() {
            var taskCompletionSource = new TaskCompletionSource<int>();
            var timer = new System.Timers.Timer(5000) { 
                AutoReset = false
            };
            timer.Elapsed += delegate {
                timer.Dispose();
                taskCompletionSource.SetResult(42);
            };
            timer.Start();
            return taskCompletionSource.Task;
        }

        #endregion

        #region Serialization

        public static void SerializationProcess() {
            var indomaret = MakeStore();
            var options = new JsonSerializerOptions {
                WriteIndented = true
            };
            string jsonString = JsonSerializer.Serialize(indomaret, options);
            string writePath = ReturnPath("store.json");
            using (StreamWriter writer = new StreamWriter(writePath)) {
                writer.WriteLine(jsonString);
            }
        }

        public static void DeserializationProcess() {
            string pathRead = ReturnPath("store.json");
            var jsonString = new StringBuilder();
            using (StreamReader reader = new StreamReader(pathRead)) {
                string line;
                while ((line = reader.ReadLine()) != null) {
                    jsonString.Append(line);
                }
            }
            Store indomaret = JsonSerializer.Deserialize<Store>(jsonString.ToString());
            PrintStore(indomaret);
        }

        public static Store MakeStore() {
            var store = new Store {
                Id = 3,
                Name = "Indomaret",
                Address = "Taman Ratu",
                City = "Jakarta",
                RegisterDate = new DateTime(2018, 7, 22),
                ProducsOnSale = new List<Product>() {
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
                }
            };
            return store;
        }

        public static void PrintStore(Store toko) {
            Console.WriteLine("====================================");
            Console.WriteLine($"Id: {toko.Id}\nName: {toko.Name}\nAddress: {toko.Address}, Register Date: {toko.RegisterDate.ToString("dd MMMM yyyy")}");
            Console.WriteLine("=============Products==============");
            foreach (var product in toko.ProducsOnSale) {
                Console.WriteLine($"Id:{product.Id}, Name:{product.Name}, Description:{product.Description}, Price:{product.Price}");
            }
            Console.WriteLine("====================================");
        }

        public static string ReturnPath(string fileName) {
            var path = Path.GetFullPath($"../../../Files/{fileName}");
            return path;
        }

        #endregion

    }
}
