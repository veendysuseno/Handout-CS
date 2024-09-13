using SerializingDataContract.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace SerializingDataContract
{
    class Program
    {
        /*
         * Serialization: tindakan merubah object di dalam memory, termasuk struktur objectnya (object graph), lalu merubahnya menjadi stream, dan disusun kembali
         * dalam format standard seperti XML, JSON atau binary. Lalu hasilnya ini bisa dikirim ke system lain melalui API atau disimpan ke dalam file/database.
         * Dalam hal ini kita akan berikan contoh hanya untuk di record ke dalam file, karena kita belum mempelajari API dan melakukan koneksi C# ke database.
         * 
         * Deserialization: Ini adalah proses kebalikan dari serialization, dimana kita akan mengubah format JSON/XML/binary kembali ke dalam state object di dalam C#.
         * 
         * Serialization di dalam .Net Framework dibagi menjadi 2:
         * 1. Explicit Serialization: memilih dan menggunakan serialization engine dan menggunakan formatter kalau perlu.
         * 2. Implicit Serialization: serialization yang terjadi secara otomatis.
         *      Baik serialization pada child object (object yang berada pada object lagi) atau pada saat menerima atau melempar data via API.
         * 
         * Di dalam C#/.NET, ada 4 serialization engine yang bisa kalian pilih dan gunakan sesuai dengan situasi dan kondisi, masing-masing:
         * 1. Data Contract Serializer
         * 2. Xml Serializer
         * 3. Json Serializer
         * 4. Binary Serializer
         * 
         * Untuk topik kali ini, kita akan mencoba menggunakan Data Contract Serializer dulu. Serializer engine lain akan di coba pada topic lain.
         * Data Contract sama seperti Xml Serializer, karena akan sama-sama menggunakan.
         * 
         * XML (Extensible Markup Language): Jenis lain markup language (non-logical language dengan syntax berupa tag <></>) selain HTML. HTML fokusnya adalah untuk
         * membuat content pada UI web, sedangkan XML fokusnya adalah untuk menyimpan data, menerima data, mengirim data (biasanya via API) dan juga untuk menyimpan setting/ configuration
         * suatu aplikasi.
         * 
         * JSON (Javascript Object Notation): Notasi penulisan object yang diadaptasi dari penulisan object literal pada javascript. JSON lebih kecil dan lebih praktis dibandingkan dengan
         * XML dan dibuat dengan tujuan menggantikan XML, karena fungsinya hampir sama.
         */
        static void Main(string[] args) {
            SerializationProcess();
            DeserializationProcess();
        }

        /// <summary>
        /// Serialize C# object menjadi XML.
        /// </summary>
        public static void SerializationProcess() {
            var indomaret = MakeStore();
            var serializer = new DataContractSerializer(typeof(Store));
            var writePath = ReturnPath("store.xml");
            var settings = new XmlWriterSettings { Indent = true };
            using (var writer = XmlWriter.Create(writePath, settings)) {
                serializer.WriteObject(writer, indomaret);
            }
        }

        /// <summary>
        /// Membaca xml dan men deserialize xml tersebut menjadi object C#.
        /// </summary>
        public static void DeserializationProcess() { 
            var readPath = ReturnPath("store.xml");
            var serializer = new DataContractSerializer(typeof(Store));
            var settings = new XmlReaderSettings();
            using (var reader = XmlReader.Create(readPath, settings)) {
                Store indomaret = (Store)(serializer.ReadObject(reader, true));
                PrintStore(indomaret);
            }
        }

        public static Store MakeStore() {
            var store = new Store {
                Id = 3,
                Name = "Indomaret",
                Address = "Jakarta, Taman Ratu",
                ProducsOnSale = new List<Product>() {
                    new Product{
                        Id = 2,
                        Name = "Biscuit Regal",
                        Description = "Makanan ringan sehat yang baik untuk pencernaan.",
                        Stock = 250,
                        Price = 25000
                    },
                    new Product{
                        Id = 4,
                        Name = "Yakult",
                        Description = "Susu Fermentasi",
                        Stock = 50,
                        Price = 15000
                    }
                }
            };
            return store;
        }

        public static void PrintStore(Store toko) {
            Console.WriteLine("====================================");
            Console.WriteLine($"Id: {toko.Id}\nName: {toko.Name}\nAddress: {toko.Address}");
            Console.WriteLine("=============Products==============");
            foreach (var product in toko.ProducsOnSale) {
                Console.WriteLine($"Id:{product.Id}, Name:{product.Name}, Description:{product.Description}, Stock:{product.Stock}, Price:{product.Price}");
            }
            Console.WriteLine("====================================");
        }

        public static string ReturnPath(string fileName) {
            var path = Path.GetFullPath($"../../../Files/{fileName}");
            return path;
        }
    }
}
