using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueCollection {
    class Program {
        static void Main(string[] args) {

            /*
             * Queue: merupakan collection dengan FIFO style (First In First Out), bisa dibilang kebalikan daripada stack.
             * Diberi nama Queue karena sifatnya yang seperti sebuah antrian. Yang antri duluan yang mendapat hak lebih dulu.
             */

            Queue antrian = new Queue();

            //menambahkan ke dalam antrian dengan Enqueue
            antrian.Enqueue(3);
            antrian.Enqueue(2);
            antrian.Enqueue(1);
            antrian.Enqueue("Four");

            //Untuk melakukan iteration terhadapa Queue, kalian harus convert queue ke dalam array seperti contoh di bawah ini
            foreach (var item in antrian.ToArray()) {
                Console.WriteLine("Item di dalam antrian {0}", item);
            }

            //Dequeue: mengambil dan mereturn satu value, tapi melepaskannya dari queue/ antrian.
            Console.WriteLine("Jumlah sebelum di dequeue: {0}", antrian.Count);
            Console.WriteLine("Dequeue: {0}", antrian.Dequeue());
            Console.WriteLine("Jumlah setelah di dequeue: {0}", antrian.Count);
            foreach (var item in antrian.ToArray()) {
                Console.WriteLine("Item di dalam antrian {0}", item);
            }

            //Peek: sama seperti pada stack, peek digunakan untuk mengintip urutan terluar daripada queue
            Console.WriteLine("Jumlah sebelum di peek: {0}", antrian.Count);
            Console.WriteLine("Peek: {0}", antrian.Peek());
            Console.WriteLine("Jumlah setelah di peek: {0}", antrian.Count);


        }
    }
}
