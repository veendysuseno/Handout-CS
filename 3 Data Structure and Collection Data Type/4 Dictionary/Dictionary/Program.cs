using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary {
    class Program {
        static void Main(string[] args) {

            /*
             * Dictionary seperti kamus yang menerjemakan satu value sebagai kata kunci [Key] atau sebagai index dengan [Value] atau nilainya.
             * Sehingga tidak perlu seperti array yang menggunakan numerical integer sebagai index, Dicitionary bisa menggunakan key sebagai index.
             */

            //inisialisasi 1
            Dictionary<int, string> dictionaryOne = new Dictionary<int, string>();
            dictionaryOne.Add(3, "Tiga");
            dictionaryOne.Add(66, "Enam puluh enam");
            dictionaryOne.Add(12, "Twelve");

            //inisialisasi 2
            Dictionary<string, int> dictionaryTwo = new Dictionary<string, int>(){
                {"Chicken", 3},
                {"Beef", 5},
                {"Lamb", 8 }
            };

            Dictionary<string, string> dictionaryThree = new Dictionary<string, string>();
            dictionaryThree.Add("Silver", "Penny");
            dictionaryThree.Add("Gold", "Trophy");
            dictionaryThree.Add("Platinum", "Card");

            Console.WriteLine("Dari dictionary satu, cari value dari 3: {0}", dictionaryOne[3]);
            Console.WriteLine("Banyak item dari dicitionary one: {0}", dictionaryOne.Count);
            Console.WriteLine("Dari dictionary dua, cari value dari Beef: {0}", dictionaryTwo["Beef"]);
            Console.WriteLine("Dari dictionary three, cari value dari Gold: {0}", dictionaryThree["Gold"]);

            //ambil property key dan valuenya satu persatu
            foreach (KeyValuePair<string, string> item in dictionaryThree) { //bisa menggunakan var ketimbang KeyValuePair
                Console.WriteLine("Keynya: {0}, Valuenya: {1}", item.Key, item.Value);
            }

            //Mengumpulkan keynya saja
            Dictionary<string, string>.KeyCollection dicThreeKeys = dictionaryThree.Keys;
            foreach (var key in dicThreeKeys) {
                Console.WriteLine("Key itemnya {0}", key);
            }

            //Mengumpulkan valuenya saja
            Dictionary<int, string>.ValueCollection dicOneValues = dictionaryOne.Values;
            foreach (var value in dicOneValues) {
                Console.WriteLine("Value itemnya {0}", value);
            }

            //Removing satu value
            dictionaryTwo.Remove("Beef");
            foreach (KeyValuePair<string, int> item in dictionaryTwo) {
                Console.WriteLine("Setelah di remove {0}", item);
            }

            //Check contains key
            Console.WriteLine("Dictionary one memiliki key 66: {0}", dictionaryOne.ContainsKey(66));

            //Check contains value
            Console.WriteLine("Dictionary one memiliki value Twelve: {0}", dictionaryOne.ContainsValue("Twelve"));

            //Clear
            dictionaryThree.Clear();
            Console.WriteLine("Jumlah dictionary Three setelah clear {0}", dictionaryThree.Count);

        }
    }
}
