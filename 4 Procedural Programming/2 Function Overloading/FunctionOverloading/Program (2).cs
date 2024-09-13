using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionOverloading {
    class Program {
        /* Function Overloading adalah seni menggunakan function dengan nama yang sama.
         * 
         * Setiap fungsi harus memiliki "FUNCTION SIGNATURE" yang berbeda atau unik.
         * Function Signature/ Tanda unik function ditentukan dari kombinasi nama dan kombinasi tipe data parameter.
         */

        //function number 1
        //Function Signature: calculateSomething()
        public static int CalculateSomething() {
            Console.WriteLine("Function number 1 invoked!");
            return 99;
        }

        //function number 2
        //Function Signature: calculateSomething(int)
        public static int CalculateSomething(int argOne) {
            Console.WriteLine("Function number 2 invoked!");
            return argOne + 1;
        }

        //function number 3
        //Function Signature: calculateSomething(int, int)
        public static int CalculateSomething(int argOne, int argTwo) {
            Console.WriteLine("Function number 3 invoked!");
            return argOne + argTwo;
        }

        //function number 4
        //Function Signature: calculateSometing(int, int, int)
        public static int CalculateSomething(int argOne, int argTwo, int argThree) {
            Console.WriteLine("Function number 4 invoked!");
            int result = (argOne + argTwo) * argThree;
            return result;
        }

        //function number 5
        //Function Signature: calculateSomething(string)
        public static int CalculateSomething(string argOne) {
            Console.WriteLine("Function number 5 invoked!");
            int converted = Int32.Parse(argOne);
            int result = converted * 10;
            return result;
        }

        //function number 6
        //Function Signature: calculateSomething(int, string)
        public static int CalculateSomething(int argOne, string argTwo) {
            Console.WriteLine("Function number 6 invoked!");
            int twoConverted = Int32.Parse(argTwo);
            int result = argOne * twoConverted;
            return result;
        }

        //function number 7
        //Function Signature: calculateSomething(string, int)
        public static int CalculateSomething(string argOne, int argTwo) {
            Console.WriteLine("Function number 7 invoked!");
            int oneConverted = Int32.Parse(argOne);
            int result = oneConverted + argTwo;
            return result;
        }

        /* Tidak akan bisa, function overload membedakan function dari keunikan parameternya dilihat dari tipe data, banyak dan urutannya, bukan dari return typenya.
        public static string CalculateSomething() {
            Console.WriteLine("Function number 8 invoked!");
            return "Hello World";
        }

        public static string CalculateSomething(int argOne) {
            Console.WriteLine("Function number 9 invoked!");
            string converted = argOne.ToString();
            return converted;
        }

        merubah nama argument pun tidak akan bisa
        public static int CalculateSomething(int argumentSatu) {
            Console.WriteLine("Function number 10 invoked!");
            return argumentSatu;
        }        
        */

        static void Main(string[] args) {

            //Gunakan Intellisense saat invoking function untuk melihat setiap potensial pilihan function dari parameternya.
            int result = 0;
            result = CalculateSomething();
            Console.WriteLine(result);
            result = CalculateSomething(5);
            Console.WriteLine(result);
            result = CalculateSomething(3,2);
            Console.WriteLine(result);
            result = CalculateSomething(3, 2, 4);
            Console.WriteLine(result);
            result = CalculateSomething("67");
            Console.WriteLine(result);
            result = CalculateSomething(4, "5");
            Console.WriteLine(result);
            result = CalculateSomething("5", 4);
            Console.WriteLine(result);
        }
    }
}
