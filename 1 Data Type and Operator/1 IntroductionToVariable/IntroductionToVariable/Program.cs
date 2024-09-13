using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionToVariable {
    class Program {
        static void Main(string[] args) {


            /*
             * Variable adalah nama yang dipakai bahasa pemrograman untuk MENUNJUK satu block memory yang menyimpan suatu data dengan Data Type/ Tipe Data tertentu.
             */

            /*C# memiliki signed dan unsigned type ada numeric data type*/

            //Berikut ini adalah contoh-contoh Data Type Primitive Numeric
            #region Numerical

            //byte: (unsigned) bilangan bulat positif 0 to 255
            byte contohByte = 2;
            Console.WriteLine(contohByte);
            Console.WriteLine(contohByte.GetType());

            //sbyte: (signed) bilangan bulat negatif dan positif -128 to 127
            sbyte contohSByte = -120;
            Console.WriteLine(contohSByte);
            Console.WriteLine(contohSByte.GetType());

            //short: (signed) bilangan bulat 16 bit (Int16) -32.768 to 32.767
            short contohShort = -30000;
            Console.WriteLine(contohShort);
            Console.WriteLine(contohShort.GetType());

            //ushort: (unsigned) bilangan bulat 16 bit (Int16) 0 to 65,535
            ushort contohUShort = 60000;
            Console.WriteLine(contohUShort);
            Console.WriteLine(contohUShort.GetType());

            //int: (signed) bilangan bulat 32 bit (Int32) -2,147,483,648 to 2,147,483,647
            int contohInteger = 5;
            Console.WriteLine(contohInteger);
            Console.WriteLine(contohInteger.GetType());

            //uint: (unsigned) bilangan bulat 32 bit (Int32) 0 to 4,294,967,295
            uint contohUInteger = 67;
            Console.WriteLine(contohUInteger);
            Console.WriteLine(contohUInteger.GetType());

            //long: (signed) bilangan bulat 64 bit (Int64) -9,223,372,036,854,775,808 to 9,223,372,036,854,775,807
            long contohLong = 6500000000;
            Console.WriteLine(contohLong);
            Console.WriteLine(contohLong.GetType());

            //ulong: (unsigned) bilangan bulat 64 bit (Int64) 0 to 18,446,744,073,709,551,615
            ulong contohULong = 300000;
            Console.WriteLine(contohULong);
            Console.WriteLine(contohULong.GetType());

            //decimal: 128 bit decimal dengan 28-29 significant digits (-7.9 x 10^28 to 7.9 x 10^28) / 10^0 to 10^28
            /*Biasa digunakan untuk kepentingan financial technology karena presisi (menghindari kesalahan pembulatan)*/
            decimal contohDecimal = 300.5m;
            Console.WriteLine(contohDecimal);
            Console.WriteLine(contohDecimal.GetType());

            //double: 64 bit decimal (+/-)5.0 x 10-^324 to (+/-)1.7 x 10^308
            /*Decimal yang paling sering dipakai, terkecuali untuk menghandle keuangan*/
            double contohDouble = 3.45;
            Console.WriteLine(contohDouble);
            Console.WriteLine(contohDouble.GetType());

            //float: 32 bit decimal -3.4 x 10^38 to + 3.4 x 10^38
            /*Keseringan di pakai di dalam pgraphic libraries karena better perfromance untuk processing powers.*/
            float contohFloat = 3.5f;
            Console.WriteLine(contohFloat);
            Console.WriteLine(contohFloat.GetType());

            #endregion

            //Berikut ini adalah contoh-contoh Data Type Primitive yang menyimpan text
            #region Characters

            //char: satu 16-bit Unicode character
            char contohChar = 'x';
            Console.WriteLine(contohChar);

            //string: sederetan characters 
            string contohString = "Sebuah kata-kata";
            Console.WriteLine(contohString);

            #endregion

            #region Others

            //bool true/false, default: false. Menyimpan hanya 1 bit, 0 untuk false, 1 untuk true.
            //bool sangat hemat memory karena hanya menyimpan 1 bit data.
            bool contohBool = true;
            Console.WriteLine(contohBool);

            //DateTime, menyimpan tanggal dan jam, default 01/01/0001
            //Note: Banyak yang berpendapat kalau DateTime adalah tipe data yang primitive, tapi secara mechanismenya DateTime tidak termasuk ke dalam primitive.
            //Microsoft juga tidak list DateTime sebagai primitive.
            DateTime contohDateTime = new DateTime(2016, 10, 23);
            Console.WriteLine(contohDateTime);

            #endregion

            #region Replacing Variable Value

            int specificVariable = 56;
            int otherVariable = 99;
            Console.WriteLine("Sebelum di replace: " + specificVariable);
            specificVariable = 87;
            Console.WriteLine("Setelah di replace: " + specificVariable);
            Console.WriteLine("Setelah di replace: " + specificVariable);
            Console.WriteLine("Other variable: " + otherVariable);
            otherVariable = specificVariable;
            Console.WriteLine("Other variable setelah replace: " + otherVariable);
            specificVariable = 122;
            Console.WriteLine("Specific variable: " + specificVariable);
            Console.WriteLine("Other variable: " + otherVariable);

            string kalimat = "Hello friend, Hello friend";
            Console.WriteLine(kalimat);
            Console.Write("Masukan input:");
            kalimat = Console.ReadLine(); //Cara menerima input dari console (Selalu dalam string)
            Console.WriteLine(kalimat);

            #endregion

            #region Initialization Variable

            int sebuahInteger; //Ini hanya inisialisasi variable, sebuah variable yang hanya di inisialisasi. Inisialisasi variable tidak berarti di assign valuenya.
            //Console.WriteLine(sebuahInteger);
            sebuahInteger = 5; //Value assignment, proses assign value/ data ke dalamnya.
            Console.WriteLine(sebuahInteger);

            #endregion

            //Anonymous adalah tipe data yang beradaptasi dengan valuenya pada saat peristiwa assignment.
            #region Anonymous Type

            var anonymousOne = 23;
            var anonymousTwo = "Words";
            Console.WriteLine(anonymousOne.GetType());
            Console.WriteLine(anonymousTwo.GetType());
            //anonymousOne = "Sesuatu"; ini tidak akan bisa, karena anonymousOne sudah di reserve sebagai int data type.

            #endregion

        }
    }
}
