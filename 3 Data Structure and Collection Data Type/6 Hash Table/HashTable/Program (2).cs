using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable {
    class Program {
        static void Main(string[] args) {
            /*Hash table collection hampir sama dengan Dictionary, dimana collection yang menyimpan pair Key dan Value.*/

            //inisialisasi 1
            Hashtable hashTable = new Hashtable();
            hashTable.Add(1, "One");
            hashTable.Add(2, "Two");
            hashTable.Add(3, "Three");
            hashTable.Add(4, "Four");
            hashTable.Add(5, null);
            hashTable.Add("Fv", "Five");
            hashTable.Add(8.5F, 8.5);

            Hashtable hashTable2 = new Hashtable() {
                { 1, "One" },
                { 2, "Two" },
                { 3, "Three" },
                { 4, "Four" },
                { 5, null },
                { "Fv", "Five" },
                { 8.5F, 8.5 }
            };
            Console.WriteLine("Value dari key 4 adalah: {0}", hashTable[4]);

            //iteration
            foreach (DictionaryEntry item in hashTable) {
                Console.WriteLine("Key-nya: {0}, Value-nya: {1}", item.Key, item.Value);
            }

            Console.WriteLine("Apakah contain key Fv: {0}", hashTable2.Contains("Fv"));
            Console.WriteLine("Apakah contain key 4: {0}", hashTable2.ContainsKey(4));
            Console.WriteLine("Apakah contain value: {0}", hashTable2.ContainsValue("Three"));

            //Clear table
            Console.WriteLine("Sebelum clear table: {0}", hashTable2.Count);
            hashTable2.Clear();
            Console.WriteLine("Setelah clear table: {0}", hashTable2.Count);            
        }
    }
}