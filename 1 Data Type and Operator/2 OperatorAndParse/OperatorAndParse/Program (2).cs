using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorAndParse {
    class Program {
        static void Main(string[] args) {

            /*
             * Kita bisa merubah data type setiap variable dengan beberapa metode:
             * Implicit Conversions
             * Explicit Conversions (Cast)
             * Conversion with helper class
             */

            /* 
             * Implicit Conversion adalah conversi yang sebenarnya tidak membutuhkan metode tertentu karena 2 variable memiliki format yang serupa
             * dan tidak memungkinkannya ada data yang hilang.
             */
            short bilangan16Bit = 34;
            int bilangan32Bit = bilangan16Bit;
            int bilanganInteger = 450;
            int bilangan64Bit = bilanganInteger;

            /*
             * Explicit Conversion adalah conversi yang menggunakan (cast). Explicit Conversion bisa melakukan perubahan format dimana ada kemungkinan lost data.
             */
            double bilanganDesimal = 56.78;
            int bilanganBulat = (int)bilanganDesimal;
            Console.WriteLine(bilanganBulat);

            /*
             * Conversion with helper class: dengan menggunakan helper class seperti Convert
             */
            #region Integer Parse

            int integer = 56;
            int integerZero = 0;
            string integerToString = integer.ToString();
            short integerToShort = Convert.ToInt16(integer);
            long integerToLong = Convert.ToInt64(integer);
            double integerToDouble = Convert.ToDouble(integer);
            decimal integerToDecimal = Convert.ToDecimal(integer);
            bool integerToBool = Convert.ToBoolean(integer);
            bool integerZeroToBool = Convert.ToBoolean(integerZero);
            Console.WriteLine(integerToBool);
            Console.WriteLine(integerZeroToBool);

            #endregion

            //Perbedaan Casting dan Convert terkadang...
            double real = 1.6;
            int castedInteger = (int)real;
            int convertedInteger = Convert.ToInt32(real);
            Console.WriteLine("Yang pakai cast " + castedInteger);
            Console.WriteLine("Yang pakai convert " + convertedInteger);

            #region String Parse

            //string letterInString = "Hello World";
            //int letterToInteger = Convert.ToInt32(letterInString);
            //Console.WriteLine(letterToInteger);
            string numberInString = "670";
            int numberToString = Convert.ToInt32(numberInString);
            Console.WriteLine(numberToString);
            string characterInString = "x";
            char stringToCharacter = Convert.ToChar(characterInString);
            Console.WriteLine(stringToCharacter);
            string decimalInString = "45,6750";
            double stringToDouble = Convert.ToDouble(decimalInString);
            Console.WriteLine(stringToDouble);

            //Dengan method Parse, lebih baik dan lebih cepat dari convert.
            int parseToInteger = Int32.Parse(numberInString);
            Console.WriteLine(parseToInteger);

            //Try parse memiliki mechanisme apabila parsing gagal.
            int tryParseToInteger;
            bool ifSuccess = Int32.TryParse(numberInString, out tryParseToInteger);
            Console.WriteLine(tryParseToInteger);
            Console.WriteLine(ifSuccess);
            ifSuccess = Int32.TryParse("a mistake", out tryParseToInteger);
            Console.WriteLine(tryParseToInteger);
            Console.WriteLine(ifSuccess);

            string somethingNull = null;
            int convertNull = Convert.ToInt32(somethingNull);
            Console.WriteLine(convertNull); // Gak seharusnya terjadi
            //int parseNull = Int32.Parse(somethingNull);

            #endregion

            #region DateTime Parse

            DateTime sampleDateTime = new DateTime(2017, 11, 25);
            Console.WriteLine(sampleDateTime);
            string dateInShortString = sampleDateTime.ToShortDateString();
            string dateInLongString = sampleDateTime.ToLongDateString();

            /*
             * yyyy = full year 2016
             * yy = short year 16
             * MM = short month 7
             * MMM = alias month JUL
             * MMMM = long month July
             * dd = 2 digit date: 09
             * d = 1 digit date: 9
             * 
             * dan masih banyak lainnya untuk waktu seperti jam, menit dan detik.
             */
            string datetimeInString = sampleDateTime.ToString("dd MMM yyyy");
            Console.WriteLine(datetimeInString);


            //Untuk convert DateTime bisa menggunakan Parse.
            DateTime anotherDateTime = DateTime.Parse("2008-08-27");
            Console.WriteLine(anotherDateTime);

            DateTime anotherDateTimeTwo = DateTime.Parse("08-27-2008");
            Console.WriteLine(anotherDateTimeTwo);

            /*
             * DateTime.Parse bisa saja membuat sebuah datetime dengan menggunakan string atau merubah string menjadi date time,
             * tetapi formatnya di interpret atau ditebak.
             * 
             * Untuk merubahnya dengan format yang pasti, bisa menggunakan ParseExact.
             * ParseExact bisa mengatur formatnya juga.
             */

            DateTime nonExactDateTime = DateTime.Parse("08-09-2008"); //Kita tidak tau yang mana yang ini akan jadi 8 September atau jadi 9 Agustus
            Console.WriteLine(nonExactDateTime.ToLongDateString());

            DateTime exactDate = DateTime.ParseExact("2005-05-04 22:12", "yyyy-MM-dd HH:mm", null);
            Console.WriteLine(exactDate.ToLongDateString());

            #endregion

            #region Basic Math Operators

            int penjumlahan = 3 + 6;
            Console.WriteLine(penjumlahan);

            int pengurangan = 8 - 4;
            Console.WriteLine(pengurangan);

            int perkalian = 5 * 6;
            Console.WriteLine(perkalian);

            int pembagian = 30 / 5;
            Console.WriteLine(pembagian);

            int modulus = 26 % 5;
            Console.WriteLine(modulus);

            double firstDouble = 56.43;
            double secondDouble = 12.35;
            double resultDouble = firstDouble + secondDouble;
            Console.WriteLine(resultDouble);

            int mix = (3 + 7) / 2;
            Console.WriteLine(mix);

            string kataPertama = "Hello friend, ";
            string kataKedua = "I just talk to my self";
            string kombinasiKata = kataPertama + kataKedua;
            Console.WriteLine(kombinasiKata);

            #endregion
        }
    }
}
