using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericList {
    class Program {
        static void Main(string[] args) {
            /*
             * Generic List: Adalah bentuk collection dengan tipe data yang generic(bisa diset).
             * Struktur datanya seperti rantai, terkait dari satu index ke index lainnya. (satu sebelumnya dan satu setelahnya)
             * List sangat bagus ketika programmer belum bisa mendefinisikan berapa besar ukuran collectionnya, tetapi tetap ingin menghemat memory semaximal mungkin.
             */

            //Initialization type 1
            List<string> stringList = new List<string>();
            stringList.Add("Hello");
            stringList.Add("Friend");
            stringList.Add("May be");
            stringList.Add("I should");
            stringList.Add("Give");
            stringList.Add("You");
            stringList.Add("A Name");

            //Initialization type 2 
            List<string> wordList = new List<string>() { "That is", "Lame", "It's", "A Slippery", "Slope" };
            
            //Memanggil berdasarkan index seperti array
            Console.WriteLine("Indexing seperti array: {0}", wordList[0]);

            //Liat panjang suatu collection
            Console.WriteLine("List ini memiliki panjang: {0}", stringList.Count);
            foreach (string item in stringList) {
                Console.WriteLine("Item {0}", item);
            }

            List<string> stringSecondList = new List<string>();
            stringSecondList.Add("But");
            stringSecondList.Add("That's");
            stringSecondList.Add("a Slippery");
            stringSecondList.Add("Slope");

            //Menggabungkan 2 list menjadi satu
            stringList.AddRange(stringSecondList);
            foreach (string item in stringList) {
                Console.WriteLine("Item after extend {0} containes {1}", item, item.Contains('h'));
            }

            Console.WriteLine("Jumlah item before clear {0}", stringSecondList.Count);
            stringSecondList.Clear();
            Console.WriteLine("Jumlah item after clear {0}", stringSecondList.Count);

            stringList.Insert(3, "X");
            Console.WriteLine("After X:");
            foreach (string item in stringList) {
                Console.WriteLine(item);
            }

            Console.WriteLine("After Remove At:");
            stringList.RemoveAt(3);
            foreach (string item in stringList) {
                Console.WriteLine(item);
            }

            //Intialization type 2
            List<int> intList = new List<int>() { 10, 20, 30, 40 };
            foreach (int item in intList) {
                Console.WriteLine(item);
            }

        }
    }
}
