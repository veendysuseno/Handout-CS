using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array {
    class Program {
        static void Main(string[] args) {

            /* Array adalah jenis collection yang ukurannya fixed dengan index yang berurutan dengan tipe data yang sama.
             * Array mudah dicari, performancenya juga baik dalam mencari satu index yang diketahui
             * Kelemahan array adalah ukurannya yang harus fixed
             */

            /*1.Single dimensional Array*/

            //Contoh: inisialisasi 1
            int[] arrayOfInteger = new int[5];
            arrayOfInteger[0] = 34;
            arrayOfInteger[1] = 56;
            arrayOfInteger[2] = 45;
            arrayOfInteger[3] = 79;
            arrayOfInteger[4] = 109;
            Console.WriteLine("Isi dari index 3: {0}", arrayOfInteger[3]);
            Console.WriteLine("Panjang dari array: {0}", arrayOfInteger.Length);
            Console.WriteLine("Dimensi dari array: {0}", arrayOfInteger.Rank);
            Console.WriteLine("Apakah panjang array fixed: {0}", arrayOfInteger.IsFixedSize);

            //Contoh: inisialisasi 2
            double[] arrayOfDouble = { 2340.0, 4523.69, 3421.9 };
            Console.WriteLine("Isi dari index 2: {0}", arrayOfDouble[2]);
            Console.WriteLine("Apakah panjang array fixed: {0}", arrayOfDouble.IsFixedSize);

            //Contoh: inisialisasi 3
            string[] arrayOfString = new string[] { "Hello", "Friend", "Maybe", "I Should", "Give", "You", "A Name" };
            Console.WriteLine("Isi dari index 3: {0}", arrayOfString[3]);
            Console.WriteLine("Apakah panjang array fixed: {0}", arrayOfString.IsFixedSize);

            //Size Array di C# selalu fixed
            int[] nonFixedArray;
            Console.WriteLine("Apakah panjang array fixed: {0}", arrayOfString.IsFixedSize);

            /*2. Multi dimensional Array*/

            //Contoh: inisialisasi 1
            int[,] multiDimensional1 = new int[3, 3];
            multiDimensional1[0, 0] = 23;
            multiDimensional1[0, 1] = 45;
            multiDimensional1[0, 2] = 22;
            multiDimensional1[1, 0] = 67;
            multiDimensional1[1, 1] = 55;
            multiDimensional1[1, 2] = 88;
            multiDimensional1[2, 0] = 134;
            multiDimensional1[2, 1] = 100;
            multiDimensional1[2, 2] = 220;
            Console.WriteLine("Isi dari index 1,2: {0}", multiDimensional1[1, 2]);
            Console.WriteLine("Dimensi dari array: {0}", multiDimensional1.Rank);

            //Contoh: inisialisasi 2
            int[,] multiDimensional2 = {
               {20, 13, 25},
               {42, 51, 66},
               {81, 94, 105}
            };

            //Contoh: inisialisasi 3
            int[,] multiDimensional3 = new int[,] {
               {0, 1, 2},
               {4, 5, 6},
               {8, 9, 10}
            };

            /*3. Jagged Array, yang di achieve sebenarnya hampir mirip dengan multi dimensional array*/

            //Contoh inisialisasi 1
            int[][] jaggedArray1 = new int[3][];
            jaggedArray1[0] = new int[2];
            jaggedArray1[0][0] = 23;
            jaggedArray1[0][1] = 45;
            jaggedArray1[1] = new int[3];
            jaggedArray1[1][0] = 67;
            jaggedArray1[1][1] = 55;
            jaggedArray1[1][2] = 88;
            jaggedArray1[2] = new int[4];
            jaggedArray1[2][0] = 134;
            jaggedArray1[2][1] = 100;
            jaggedArray1[2][2] = 220;
            jaggedArray1[2][3] = 770;
            Console.WriteLine("Isi dari index 1,2: {0}", jaggedArray1[1][2]);
            Console.WriteLine("Dimensi dari array: {0}", jaggedArray1[1].Rank);

            //Contoh inisialisasi 2
            int[][] jaggedArray2 = new int[2][] {
                new int[] { 92, 93, 94 },
                new int[] { 85, 66, 87, 88 }
            };

            /* Looping array*/

            string[] collectionStr = new string[6];
            collectionStr[0] = "Abdul";
            collectionStr[1] = "Rheza";
            collectionStr[2] = "Anita";
            collectionStr[3] = "Nia";
            collectionStr[4] = "Ben";
            collectionStr[5] = "Roland";

            for(int index = 0; index < collectionStr.Length; index++) {
                Console.WriteLine("Nama di Index {0} adalah {1}", index, collectionStr[index]);
            }

            //Iteration yang digunakan di dalam collection. Tidak perlu iterate berdasarkan index yang diketahui
            foreach (string nama in collectionStr) {
                Console.WriteLine("Nama yang tertera adalah: {0}", nama);
            }
        }
    }
}
