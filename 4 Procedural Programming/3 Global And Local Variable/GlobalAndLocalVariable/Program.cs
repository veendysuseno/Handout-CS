using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAndLocalVariable {
    class Program {
        /* Pemakaian global variable sangat tidak disarankan di level Class. Karena akan meningkatkan potensi bugs nantinya.
         * Seluruh global variable akan berubah dan di simpan setiap kali ada code block atau function di dalamnya yang mengubahnya.
         */
        static int globalNumber;
        static string globalString = "global string";
        static int result = 0;

        static void Main(string[] args) {
            int mainNumber = 5;
            string mainString = "main string";
            Console.WriteLine("main number: {0}, main string: {1}", mainNumber, mainString);
            int functionOneResult = functionOne(mainNumber, mainString);
            Console.WriteLine("============ FUNCTION ONE END ===================");
            Console.WriteLine("main number: {0}, main string: {1}", mainNumber, mainString); //main number dan main string tidak akan berubah, perubahan hanya terjadi di dalam function one.
            Console.WriteLine("global string: {0}", globalString);
            functionTwo(functionOneResult);
            Console.WriteLine("============ FUNCTION TWO END ===================");
            Console.WriteLine("global string: {0}, global number: {1}", globalString, globalNumber); // global string akan berubah walaupun di luar funciton 2.

            {
                Console.WriteLine("============ CODE BLOCK START ===================");
                string codeBlockString = "code block string";
                Console.WriteLine(codeBlockString);
                mainNumber = 88;
                mainString = "main string inside code block";
                Console.WriteLine("main number: {0}, main string: {1}", mainNumber, mainString);
                Console.WriteLine("============ CODE BLOCK END ===================");
            }
            //in-accessible codeBlockString
            Console.WriteLine("main number: {0}, main string: {1}", mainNumber, mainString); //ikut berubah karena merupakan global variable dari code block

            bool conditional = true;
            if (conditional) {
                Console.WriteLine("============ CONDITIONAL BLOCK START ===================");
                string conditionalString = "conditional string";
                Console.WriteLine(conditionalString);
                mainNumber = 909;
                mainString = "main string inside conditional block";
                Console.WriteLine("main number: {0}, main string: {1}", mainNumber, mainString);
                Console.WriteLine("============ CONDITIONAL BLOCK END ===================");
            }
            //in-accessible conditional string
            Console.WriteLine("main number: {0}, main string: {1}", mainNumber, mainString); //persis seperti code block biasa, begitu juga semua iteration yang menggunakan code block

            /* Di sini function reference mengembalikan reference variable dengan nama hasil.
             * Hasil akan terkait dengan result, dimana perubahan di result akan mengakibatkan perubahan di hasil dan sebagainya.
             */
            ref int hasil = ref Calculate(7, 9);
            Console.WriteLine($"Variable hasil: {hasil}, variable result: {result}");
            result = 99;
            Console.WriteLine($"Variable hasil: {hasil}, variable result: {result}");
            hasil = 66;
            Console.WriteLine($"Variable hasil: {hasil}, variable result: {result}");
        }

        public static int functionOne(int mainNumber, string mainString) {
            Console.WriteLine("============ FUNCTION ONE START ===================");
            int functionOneNumber = 8;
            Console.WriteLine("main number: {0}, main string: {1}", mainNumber, mainString);
            mainNumber = 9;
            mainString = "changed main string";
            Console.WriteLine("main number: {0}, main string: {1}", mainNumber, mainString);
            functionOneNumber = 12;
            return functionOneNumber;
        }

        public static string functionTwo(int functionOneNumber) {
            Console.WriteLine("============ FUNCTION TWO START ===================");
            string functionTwoString = "function two string";
            Console.WriteLine("function one number: {0}", functionOneNumber);
            globalNumber = 13;
            globalString = "Changed global string";
            Console.WriteLine("global string: {0}, global number: {1}", globalString, globalNumber);
            return functionTwoString;
        }

        /* Return reference adalah function yang digunakan untuk mengembalikan nilai dalam bentuk reference type, 
         * atau mengembalikan nilai ke variable baru, tetapi terkait dengan global variablenya.
         */
        public static ref int Calculate(int numberOne, int numberTwo) {
            result = numberOne + numberTwo;
            return ref result;
        }
    }
}
