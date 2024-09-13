using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericAndNonGenericSortedList {
    class Program {
        static void Main(string[] args) {

            /*
             * Sorted List: merupakan collection dari kombinasi dari Dictionary dan List. Di dalam sorted list, semua value dapat memiliki tipe data yang berbeda, tapi keynya harus memiliki tipe data yang sama.
             * Keunggulan dari sorted list adalah value dapat diakses oleh index maupun key. Index akan di urutkan berdasarkan ascending order dari key.
             * Oleh karena itu collection ini diberi nama sorted list karena apabila berdasarkan 
             */

            SortedList sortedList = new SortedList();
            sortedList.Add("key A", "value one");
            sortedList.Add("key C", 2);
            sortedList.Add("key B", "value three");

            Console.WriteLine(sortedList["key A"]);
            Console.WriteLine(sortedList.GetKey(1));

            //Menggunakan For loop iteration dengan index
            for (int index = 0; index < sortedList.Count; index++) {
                Console.WriteLine("Index: {0}, Keynya: {1}, Valuenya {2}", index, sortedList.GetKey(index), sortedList.GetByIndex(index));
            }

            //Menggunakan For each iteration dengan index
            foreach(DictionaryEntry item in sortedList){
                Console.WriteLine("Keynya: {0}, Valuenya: {1}", item.Key, item.Value);
            }

            /*
             * Generic Sorted List: merupakan collection dari kombinasi dari Dictionary dan Generic List.
             * Generic sorted list hampir sama dengan sorted list, bedanya adalah generic sorted list mendefine data type seperti pada generic list.
             */
            SortedList<int, string> genericSortedList = new SortedList<int, string>();
            genericSortedList.Add(45, "empat puluh lima");
            genericSortedList.Add(12, "dua belas");
            genericSortedList.Add(123, "seratus dua puluh tiga");

            Console.WriteLine(genericSortedList[12]);
            Console.WriteLine(genericSortedList.Keys[0]);
            Console.WriteLine(genericSortedList.Values[0]);

            //Menggunakan For loop iteration dengan index
            for (int index = 0; index < genericSortedList.Count; index++) {
                Console.WriteLine("Index: {0}, Keynya: {1}, Valuenya {2}", index, genericSortedList.Keys[index], genericSortedList.Values[index]);
            }

            //Menggunakan For each iteration dengan index
            foreach (KeyValuePair<int, string> item in genericSortedList) {
                Console.WriteLine("Keynya: {0}, Valuenya: {1}", item.Key, item.Value);
            }
        }
    }
}
