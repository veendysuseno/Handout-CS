using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringManipulation {
    class Program {
        static void Main(string[] args) {
            string morpheusOne = "There is a difference between knowing the path, ";
            string morpheusTwo = "and walking the path.";
            string oracleOne = "    You didn't       come here to make a choice.     ";
            string oracleTwo = "You already made it, you come here to understand why YOU made it.";
            string oracleThree = "Its says know yourself";

            #region Concat String

            //Concat string with + (performancenya kurang baik) karena terus menciptakan memory baru untuk string
            string morpheusQuote = morpheusOne + morpheusTwo;
            Console.WriteLine(morpheusQuote);

            //Concat dengan append dengan menggunakan StringBuilder. Performance cepat untuk dilakukan berkali-kali, tetapi repot untuk dibentuk.
            StringBuilder morpheusQuoteBuilder = new StringBuilder();
            morpheusQuoteBuilder.Append(morpheusOne);
            morpheusQuoteBuilder.Append(morpheusTwo);
            Console.WriteLine(morpheusQuoteBuilder);

            //Concat dengan concat function, lebih cepat dari + tapi tidak sebaik String builder performancennya.
            string morpheusConcatFunction = string.Concat(morpheusOne, morpheusTwo);
            Console.WriteLine(morpheusConcatFunction);

            //Concat string with interpolation
            string morpheusQuoteInterpolation = $"{morpheusOne}{morpheusTwo}";
            Console.WriteLine(morpheusQuoteInterpolation);

            //Concat using format function
            string morpheusConcatFormat = string.Format("{0}{1}", morpheusOne, morpheusTwo);
            Console.WriteLine(morpheusConcatFormat);

            //Directly in Console Write Line function
            Console.WriteLine("{0}{1}", morpheusOne, morpheusTwo);

            //String pada c# bisa ditulis dengan baris baru tanpa menggunakan tanda +, yaitu dengan menggunakan @, atau disebut juga dengan verbatim string.

            string verbatimExample = @"This is the example of verbatim
            The sentence continue in here without concate operator.
                Will the blank space is being print?";
            Console.WriteLine(verbatimExample);

            //Kita bisa mengkombinasikan verbatim dan interpolation menjadi verbatim interpolation seperti di bawah ini.
            string sampleName = "Andi";
            string verbatimInterpolation = $@"Seorang developer bernama {sampleName}, sendang membangun sebuah aplikasi.
            Aplikasi market place khusus untuk bahan pokok.";
            Console.WriteLine(verbatimInterpolation);

            #endregion

            //Trim spasi depan dan belakang
            Console.WriteLine(oracleOne);
            string oracleTrim = oracleOne.Trim();
            Console.WriteLine(oracleTrim);

            //Count Length, menghitung panjang string character
            int stringLength = morpheusOne.Length;
            Console.WriteLine(stringLength);

            //Inisialisasi Empty String
            string stringKosong = "";
            string stringKosongDariLibrary = string.Empty;
            Console.WriteLine(stringKosong);
            Console.WriteLine(stringKosongDariLibrary);

            //Substring, mengambil sepotong string
            string substringQuoteOne = oracleTwo.Substring(0, 11);
            string substringQuoteTwo = oracleTwo.Substring(12, 20);
            Console.WriteLine(substringQuoteOne);
            Console.WriteLine(substringQuoteTwo);

            //Lower Case and Upper Case
            string oracleLower = oracleTwo.ToLower();
            Console.WriteLine(oracleLower);
            string oracleUpper = oracleTwo.ToUpper();
            Console.WriteLine(oracleUpper);

            //Index of Character, index character pertama yang ditemukan
            int index = oracleTwo.IndexOf('m');
            Console.WriteLine(index);

            //Remove, Replace
            string removed = oracleThree.Remove(3);
            Console.WriteLine(removed);
            string replaced = oracleThree.Replace('y', 't');
            Console.WriteLine(replaced);

            //Dan fungsi-fungsi lainnya

            /*
             * String Interpolation atau suka disebut sebagai string literal, adalah teknik alternatif dari composite formating seperti biasa.
             * String interpolation ditandai dengan tanda $ dimana membuat code lebih terbaca.
             */
            string namaDepan = "Matthew";
            string namaBelakang = "Rodriguez";
            DateTime ulangTahun = new DateTime(1989, 12, 25);

            Console.WriteLine($"Orang ini bernama {namaDepan} {namaBelakang}, lahir pada tanggal {ulangTahun.ToShortDateString()}");


        }
    }
}