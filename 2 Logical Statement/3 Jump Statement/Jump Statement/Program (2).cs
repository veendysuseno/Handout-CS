using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jump_Statement {
    class Program {
        static void Main(string[] args) {

            //Break: Hentikan proses iteration
            for (int index = 1; index < 10; index++) {
                Console.WriteLine("Index is {0}", index);
                if (index == 3) {
                    break;
                } 
            }

            for (int xIndex= 0; xIndex < 10; xIndex++) {
                Console.WriteLine("Index X is {0}", xIndex);
                for (int yIndex = 0; yIndex < 10; yIndex++) {
                    Console.WriteLine("Index Y is {0}", yIndex);
                    if (yIndex == 5) {
                        break;
                    }
                }
            }

            //Continue: skip ke iteration berikutnya
            for (int index = 1; index <= 10; index++) {
                if (index < 9) {
                    continue;
                }
                Console.WriteLine("Get index {0}", index);
            }

            //Go To: sebenarnya ini tidak best practice dalam penggunaanya bila terlalu banyak.
            //Kita bisa pakai function untuk solve masalah ini nanti di chapter 4.
            Console.WriteLine("Masukan case number dari 1 - 3");
            string caseNumber = Console.ReadLine();

            switch (caseNumber) {
                case "1":
                    Console.WriteLine("case number 1");
                    break;
                case "2":
                    Console.WriteLine("case number 2");
                    break;
                case "3":
                    Console.WriteLine("case number 3");
                    goto case "1";
                default:
                    Console.WriteLine("Invalid selection");
                    break;
            }

            NextProcess:
            Console.WriteLine("Eksekusi berikutnya");

            Console.WriteLine("Masukan input lain, antara satu atau dua");
            string inputWord = Console.ReadLine();
            if (inputWord == "satu") {
                Console.WriteLine("Step One");
            } else if (inputWord == "dua") {
                Console.WriteLine("Step Two");
                goto NextProcess;
            }

        }
    }
}
