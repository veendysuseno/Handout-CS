using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Continuation
{
    public static class UtilizingContinueWith
    {
        /* ContinueWith adalah method yang digunakan untuk melanjutkan task dengan proses delegasi lainnya, atau bisa dikatakan mengerjakan apa sestelah satu task selesai.
         * Perhatikan contoh dibawah, kalau hasil print 0 dengan 1 tidak akan bercampur karena mereka berurutan.
         * 
         * ContinueWith memiliki satu parameter, yaitu previousTask atau objectTask yang complete tepat sebelum eksekusi Continuenya.
         */
        public static void UsingContinue() {
            var printZeroTask = Task.Run(() => {
                for (int index = 0; index < 10; index++) {
                    Task.Delay(500).Wait();
                    Console.Write(0);
                }
            });
            printZeroTask.ContinueWith(previousTask => {
                for (int index = 0; index < 10; index++) {
                    Task.Delay(500).Wait();
                    Console.Write(1);
                }
            });
            Task.Delay(11000).Wait();
        }

        /// <summary>
        /// Fungsi di bawah ini melakukan demo 2 task yang di lanjutkan dengan continue with masing-masing.
        /// Hal seperti ini mudah dicode dan dibaca dengan ContinueWith dibanding dengan Wait().
        /// 
        /// Lain dengan Wait() yang bersifat blocking pada main thread, ContinueWith akan langsung melanjutkan task dengan task lain,
        /// saat task tersebut sudah selesai.
        /// </summary>
        public static void MultipleContinue() {
            var printZeroTask = Task.Run(() => {
                for (int index = 0; index < 10; index++) {
                    Task.Delay(500).Wait();
                    Console.Write(0);
                }
            });
            var printXTask = Task.Run(() => {
                for (int index = 0; index < 15; index++) {
                    Task.Delay(200).Wait();
                    Console.Write("X");
                }
            });
            printZeroTask.ContinueWith(previousTask => {
                for (int index = 0; index < 10; index++) {
                    Task.Delay(500).Wait();
                    Console.Write(1);
                }
            });
            printXTask.ContinueWith(previousTask => {
                for (int index = 0; index < 15; index++) {
                    Task.Delay(200).Wait();
                    Console.Write("Y");
                }
            });
            Task.Delay(11000).Wait();
        }

        /// <summary>
        /// Kita bisa mengambil value dari task sebelumnya pada ContinueWith, dengan cara melalui parameter yang ada
        /// pada delegasi ContinueWith. 
        /// 
        /// Parameter tersebut adalah task yang sudah complete dari task yang sebelumnya.
        /// Oleh karena itu untuk lebih mudah dimengerti, saya beri nama previousTask.
        /// </summary>
        public static void ReturnFrom() {
            Task<int> valueOneTask = Task.Run(() => {
                return 77;
            });
            valueOneTask.ContinueWith(previousTask => {
                int valueOne = previousTask.Result;
                int result = valueOne * 2;
                Console.WriteLine($"Hasilnya {result}");
            });
            Thread.Sleep(2000);
        }

    }
}
