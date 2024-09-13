using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iteration_Statement {
    class Program {
        static void Main(string[] args) {

            //Increment operator
            int initializationOne = 5;
            Console.WriteLine(initializationOne++);
            Console.WriteLine(initializationOne);

            int initializationTwo = 9;
            Console.WriteLine(++initializationTwo);
            Console.WriteLine(initializationTwo);

            int initializationThree = 7;
            Console.WriteLine(initializationThree--);
            Console.WriteLine(initializationThree);

            //Assignment operator
            int initializationFour = 34;
            initializationFour += 3;
            Console.WriteLine(initializationFour);
            initializationFour += 3;
            Console.WriteLine(initializationFour);

            int initializationFive = 44;
            initializationFive *= 5;
            Console.WriteLine(initializationFive);

            //For Loop
            for (int index = 0; index < 10; index++) {
                Console.WriteLine("This is for loop for index {0}", index);
            }

            for (int index = 0; index < 10; index += 1) {
                Console.WriteLine("This is for loop for index {0}", index);
            }

            for (int index = 10; index > 0; index--) {
                Console.WriteLine("This is for loop for index {0}", index);
            }

            //While
            int sequence = 0;
            while (sequence < 10) {
                Console.WriteLine("This is for loop for sequence {0}", sequence);
                sequence++;
            }

            //Do While
            int identification = 0;
            do {
                Console.WriteLine("This is for loop for identification {0}", identification);
                identification++;
            } while (identification < 10);

            //Nested Loop
            for (int xIndex = 0; xIndex < 10; xIndex++) {
                for (int yIndex = 1; yIndex < 20; yIndex *= 2) {
                    Console.WriteLine("X index is {0}, Y index is {1}", xIndex, yIndex);
                }
            }

            //Foreach: akan diajarkan pada chapter Collection.
        }
    }
}
