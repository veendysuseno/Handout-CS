using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayListCollection {
    class Program {
        static void Main(string[] args) {
            /*
             * ArrayList adalah List yang bersifat tidak generic atau bisa dibilang tipe datanya bisa campur aduk dan tidak perlu di definisikan di awal.
             * Function-function dan sifat-sifat yang dimiliki ArrayList library hampir sama dengan yang generic list.
             */

            //Inisialisasi tipe 1
            ArrayList mixList = new ArrayList();
            mixList.Add("Satu");
            mixList.Add(2);
            mixList.Add(3.5);

            //Iteration
            foreach (var item in mixList) {
                Console.WriteLine("Item nya adalah: " + item);
            }

            //Dengan array index
            Console.WriteLine("Item dengan index pertama " + mixList[0]);
            Console.WriteLine("Item dengan index kedua " + mixList[1]);
            Console.WriteLine("Item dengan index ketiga " + mixList[2]);

            //Inisialisasi tipe 2
            ArrayList secondMix = new ArrayList() { "Lorem", "ipsum", 33, 24, 23.5 };
            mixList.AddRange(secondMix);

            foreach (var item in mixList) {
                Console.WriteLine("Item nya setelah di add range adalah: " + item);
            }

            //Reverse
            mixList.Reverse();
            Console.WriteLine("Itemnya setelah di reverse");

            foreach (var item in mixList) {
                Console.WriteLine("Itemnya : {0}", item);
            }

            /*
             * Rasanya jauh lebih menyenangkan menggunakan Array List karena kemampuan boxing dan unboxing tipe data.
             * Tetapi apabila tidak ada keperluan, memakai Generic List jauh lebih disarankan, karena masalah performance dan bug-prone (tidak ada antisipasi terhadap tipe data yang dipakai).
             */

        }
    }
}
