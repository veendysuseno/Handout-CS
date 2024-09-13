using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnsafeFunction {
    class Program {
        /* Unsafe function membuat C# memiliki kemampuan feature-feature seperti C++, dimana kebanyakan dapat memanipulasi memory stack.
         * Untuk dapat mengcompile unsafe, pergi ke Project > Properties > Build > Allow Unsafe Code
         * Unsafe code bukan berarti code yang berbahaya, unsafe code berarti CLR (Common Language Runtime) tidak akan memverfikasi
         */
        
        //unsafe function ditandai dengan penulisan unsafe setelah access
        public unsafe static void PointerExperiment() {
            //Berikut ini adalah kasus perubahan variable pada umumnya.
            //Pada saat memberikan value memory stack two dengan memory stack one, akan terjadi duplikat memory stack.
            int memoryStackOne = 44;
            int memoryStackTwo = memoryStackOne;
            Console.WriteLine("memory stack one: {0}, memory stack two: {1}", memoryStackOne, memoryStackTwo);
            memoryStackTwo = 670;
            Console.WriteLine("memory stack one: {0}, memory stack two: {1}", memoryStackOne, memoryStackTwo);

            //Dengan menggunakan pointer kita dapat membuat pointer type value, dimana digunakan untuk menyimpan alamat suatu variable, bukan valuenya.
            int memoryStackThree = 25;
            int* pointerToMemoryStackThree = &memoryStackThree; //* artinya adalah pointer dan & adalah dereferences.
            Console.WriteLine("memory stack three: {0}, pointer to stack three: {1}", memoryStackThree, *pointerToMemoryStackThree);
            memoryStackThree = 78;
            Console.WriteLine("memory stack three: {0}, pointer to stack three: {1}", memoryStackThree, *pointerToMemoryStackThree);
            *pointerToMemoryStackThree += 2;
            Console.WriteLine("memory stack three: {0}, pointer to stack three: {1}", memoryStackThree, *pointerToMemoryStackThree);

            //(!Catatan, pointer tidak bisa digunakan di semua macam data type)

            //Pointer to pointer, sebuah pointer yang menunjuk ke alamat pointer lain.
            int** pointerToPointerToMemoryStackThree = &pointerToMemoryStackThree;
            Console.WriteLine("pointer to pointer memory stack three: {0}", **pointerToPointerToMemoryStackThree);
        }

        //Research on progress
        public unsafe static void FixedStatement() {
            int[] arrayOfNumber = new int[] { 12, 24, 35 };
            fixed (int* pointer = arrayOfNumber) {
                int* example = pointer;
                Console.WriteLine(*example);
                foreach (int number in arrayOfNumber) {
                    Console.WriteLine(number);
                }
            }
        }

        static void Main(string[] args) {
            PointerExperiment();
            FixedStatement();

            //selain sebauh function, unsafe juga bisa digunakan di dalam sebuah code block
            unsafe {
                int memoryStackFour = 67;
                int* pointerToMemoryStackFour = &memoryStackFour;
            }
        }
    }
}
