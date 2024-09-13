using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exception_Handling {
    class Program {
        static void Main(string[] args) {
            
            string words = "Hello World";

            /*Apabila langsung di coba, error exception akan langsung terlihat*/
            //int angka = Convert.ToInt32(words);

            //Try & Catch: menangkap error dan melakukan action alternative apabila gagal.
            try {
                int number = Convert.ToInt32(words);
            } catch {
                Console.WriteLine("Error, gagal convert");
            }

            //Catch Exception: Adalah menangkap error informasi yang di detect oleh system.
            try {
                int number = Convert.ToInt32(words);
            } catch(Exception exception) {
                Console.WriteLine("Exception Messagenya: {0}", exception.Message);
            }

            //Finaly: akhir dari statement try dan catch, yaitu finally. Dimana finally akan selalu di eksekusi apapun hasilnya, error ataupun tidak.
            string numeric = "50";
            try {
                int numberResult = Convert.ToInt32(numeric);
                Console.WriteLine(numberResult);
            } catch (Exception exception) {
                Console.WriteLine("Exception Messagenya: {0}", exception.Message);
            } finally {
                Console.WriteLine("Finally");
            }

            string phrase = "All shall be passed";
            try {
                int result = Convert.ToInt32(phrase);
                Console.WriteLine(result);
            } catch (Exception exception) {
                Console.WriteLine("Exception Messagenya: {0}", exception.Message);
            } finally {
                Console.WriteLine("Finally");
            }

            //Macam-macam Exception

            //1.Exception: General exception
            string testWords = "hello friend";
            try {
                int testNumber = Convert.ToInt32(testWords);
            } catch (Exception generalException) {
                Console.WriteLine("General Exception Messagenya: {0}", generalException.Message);
            }

            //2.SystemException: menghandle seluruh exception yang berhubungan langsung dengan system seperti Input/Output file.
            //3.IndexOutOfRangeException: error saat pembuatan index array di luar jaraknya.
            //4.NullReferenceException: error saat mereferensi null object
            //5.AccessViolationException: error saat ada upaya untuk mengakses protected memory.
            //6.InvalidOperationException: error saat ada upaya memanggil method
            //7.ArgumentException: error saat method memanggil sebuah function dengan menggunakan parameter yang tidak benar.
            //8.ArgumentNullException: error saat salah satu parameternya null atau tidak diisi.
            //9.ArgumentOutOfRangeException: gabungan dari IndexOutOfRangeException dan ArgumentException, maksudnya adalah error saat nilai argument melebihi boundary parameter.
            //10. NotImplementedException: error yang diakibatkan member class yang lupa di implementasi ketika inherit dari abstract class atau interface.
            //Dan masih ada macam-macam exception lainnya. 

            /*
             * Exception Filter.
             * Pada c# versi 6, nilai exception bisa di-filter dengan menggunakan keyword "when"
             */

            try {
                int number = Convert.ToInt32(words);
            } catch (Exception exception) when (exception.Message == "Input string was not in a correct format.") {
                Console.WriteLine("Tembus filter");
            }
        }
    }
}
