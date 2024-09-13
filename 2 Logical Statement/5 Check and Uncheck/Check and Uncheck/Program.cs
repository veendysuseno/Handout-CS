using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Check_and_Uncheck {
    class Program {
        static void Main(string[] args) {

            //Checked statement: akan membuat checked environment, sehingga hasil akan di check apakah mengakibatkan error atau tidak.
            int ten = 10;
            int resultOne = 2147483647 + ten;
            Console.WriteLine(resultOne);

            int twenty = 20;
            int resultTwo = checked(2147483647 + twenty);
            Console.WriteLine(resultTwo);

            //Alternative: Bisa menggunakan block syntax untuk memeriksa.
            checked {
                int resultThree = 2147483647 + twenty;
                Console.WriteLine(resultThree);
            }

            //Uchecked: Apabila by default sudah berada di dalam environment uncheck, maka statement uncheck tidak ada efeknya.
            //Untuk merubah setting: Project > Properties > Build > Advanced > Check for arithmetic overflow/underflow
            int resultFour = unchecked(2147483647 + ten);
            Console.WriteLine(resultFour);

            const int constantMax = int.MaxValue;
            int resultFive;
            int resultSix;

            resultFive = unchecked(constantMax + 10);
            resultSix = unchecked(2147483647 + 10);
            Console.WriteLine("Result five is: {0}", resultFive);
            Console.WriteLine("Result six is: {0}", resultSix);

        }
    }
}
