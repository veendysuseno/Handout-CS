using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadAndWriteFile {
    class Program {
        static void Main(string[] args) {
            ReadWithoutStream();
            WriteWithoutStream();
            ReadWithStream();
            WriteWithStream();
        }

        /// <summary>
        /// Function dibawah digunakan untuk membuat string dari file path.
        /// Seperti layaknya lokasi folder dalam satu directory, lokasi file kita juga memiliki path.
        /// 
        /// </summary>
        /// <param name="fileName">Hal yang dibutuhkan di sini hanyalah nama file yang ingin ditulis atau dibaca.</param>
        /// <returns></returns>
        public static string ReturnPath(string fileName) {
            /*
             * Di sini kita akan membuat relative path ketimbang absolute path.
             * relative path adalah cara menunjukan lokasi suatu file berdasarkan posisi code kita saat ini.
             * absolute path adalah cara menunjukan lokasi suatu file berdasarkan root dari drive kalian, misalnya C: atau D:
             * 
             * Dengan menggunakan relative path, kita bisa memindahkan lokasi solution ini ke computer atau ke folder mana saja dan semua tetap akan berfungsi normal.
             * .. <- artinya naik satu tingkat dari posisi file kalian sekarang.
             */
            string absolute = Directory.GetCurrentDirectory();
            string relativeDirectory = $"../../../Files/{fileName}";
            string path = $"{absolute}{relativeDirectory}";
            return path;
        }

        /// <summary>
        /// Di bawah ini adalah method cara kita membaca seluruh isi file text sekaligus dan assign isi textnya ke dalam
        /// variable string.
        /// </summary>
        public static void ReadWithoutStream() {
            string pathRead = ReturnPath("text-one.txt");
            string text = File.ReadAllText(pathRead);
            Console.WriteLine(text);
        }
        
        /// <summary>
        /// Dibawah ini adalah cara kita menulis string ke dalam suatu txt file.
        /// </summary>
        public static void WriteWithoutStream() {
            string input = "A bug is never just a mistake.\nIt represents something bigger.\nAn error of thinking that makes you who you are.";
            string pathWrite = ReturnPath("text-two.txt");
            File.WriteAllText(pathWrite, input);
        }

        /// <summary>
        /// Di bawah ini adalah method yang digunakan untuk membaca suatu file dengan menggunakan Stream.
        /// Binary stream bisa dibilang seperti buffer, dimana kita membaca suatu file baris per baris (tidak sekaligus).
        /// Sehingga performance membacanya lebih baik daripada yang tanpa menggunakan stream. 
        /// </summary>
        public static void ReadWithStream() {
            string pathRead = ReturnPath("text-three.txt");
            using (StreamReader reader = new StreamReader(pathRead)) {
                string line;
                while ((line = reader.ReadLine()) != null) {
                    Console.WriteLine(line);
                }
            }
        }

        /// <summary>
        /// Write stream sama seperti read stream, tetapi kali ini kita gunakan untuk menulis ke file baris per baris.
        /// </summary>
        public static void WriteWithStream() {
            string pathWrite = ReturnPath("text-four.txt");
            List<string> lines = new List<string>() {
                "Hello, friend. Hello friend.",
                "I talk to myself...",
                "May be I should give you a name",
                "But that's a slippery slope"
            };
            using (StreamWriter writer = new StreamWriter(pathWrite)) {
                foreach (string line in lines) {
                    writer.WriteLine(line);
                }
            }
        }
    }
}
