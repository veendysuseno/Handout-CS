using System;
using System.Threading.Tasks;

namespace ExceptionOnTask
{
    class Program
    {
        static void Main(string[] args) {
            ExampleOne();
            ExampleTwo();
            ExampleThree();
            Task.Delay(1000).Wait();
        }

        /*
         * Exception pada task juga bisa di check lewat property IsFaulted
         */

        public static void ExampleOne() {
            var task = Task.Run(ParsingLetters);
            try {
                task.Wait();
            } catch (Exception exception) {
                Console.WriteLine($"Is Task Faulted: {task.IsFaulted}");
                Console.WriteLine($"Exception: {exception.Message}");
            }
        }

        public static void ExampleTwo() {
            var task = new Task<int>(DividedByZero);
            try {
                task.Start();
                var test = task.Result;
            } catch (Exception exception) {
                Console.WriteLine($"Is Task Faulted: {task.IsFaulted}");
                Console.WriteLine($"Exception: {exception.Message}");
            }
        }

        public static async void ExampleThree() {
            var task = Task.Run(ParsingLetters);
            try {
                await task;
            } catch (Exception exception) {
                Console.WriteLine($"Is Task Faulted: {task.IsFaulted}");
                Console.WriteLine($"Exception: {exception.Message}");
            }
        }

        public static int DividedByZero() {
            int firstNumber = 5;
            int secondNumber = 0;
            return firstNumber / secondNumber;
        }

        public static void ParsingLetters() {
            string letters = "ABC";
            int resultNumber = Int32.Parse(letters);
            Console.WriteLine(resultNumber);
        }
    }
}
