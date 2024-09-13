using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackCollection {
    class Program {
        static void Main(string[] args) {

            /*
             * Stack adalah salah satu collection dengan tipe LIFO (Last In First Out). Semua data ditumpuk menjadi satu seperti tumpukan.
             * Yang masuk terakhir menjadi urutan pertama dalam collection tersebut.
             */
            Stack firstStack = new Stack();

            firstStack.Push("Hello");
            firstStack.Push(null);
            firstStack.Push(1);
            firstStack.Push(2);
            firstStack.Push(3);
            firstStack.Push(4);
            firstStack.Push(5);

            foreach (var item in firstStack) {
                Console.WriteLine(item);
            }

            //Peek: mengintip urutan terluar pada stack.
            Console.WriteLine("Mencoba peek {0}", firstStack.Peek());

            //Pop: mengambil dan membuang urutan terluar pada stack.
            Console.WriteLine("Jumlah sebelum pop: {0}", firstStack.Count);
            Console.WriteLine("Mencoba pop {0}", firstStack.Pop());
            Console.WriteLine("Jumlah setelah pop: {0}", firstStack.Count);
            foreach (var item in firstStack) {
                Console.WriteLine(item);
            }
        }
    }
}
