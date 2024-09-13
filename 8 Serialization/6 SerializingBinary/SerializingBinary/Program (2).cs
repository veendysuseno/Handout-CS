using SerializingBinary.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace SerializingBinary
{
    class Program
    {
        /*
         * Binary adalah format yang bisa menyimpan macam-macam data, sampai image atau file apapun, tetapi binary memiliki beberapa kelemahan, seperti:
         * 1. Hal yang di format ke dalam binary biasanya sudah mengikut sertakan data assemblies dan yang lainnya, 
         *      sehingga ada kemungkinan ketika di deserialized pada project lain akan terjadi error.
         * 2. Serializer harus kerja keras performancenya, terutama kalau data yang disimpan rumit dan memiliki banyak object di dalam object (object relation di dalam object graph).
         */
        static void Main(string[] args) {
            SerializationProcess();
            DeserializationProcess();
        }

        public static void SerializationProcess() {
            var indomaret = MakeStore();
            IFormatter formatter = new BinaryFormatter();
            var writePath = ReturnPath("store.bin");
            using (FileStream stream = File.Create(writePath)) {
                formatter.Serialize(stream, indomaret);
            }
        }

        public static void DeserializationProcess() {
            IFormatter formatter = new BinaryFormatter();
            var readPath = ReturnPath("store.bin");
            using (FileStream stream = File.OpenRead(readPath)) {
                Store indomaret = (Store)(formatter.Deserialize(stream));
                PrintStore(indomaret);
            }
        }

        public static Store MakeStore() {
            var store = new Store {
                Id = 3,
                Name = "Indomaret",
                Address = "Taman Ratu",
                City = "Jakarta",
                RegisterDate = new DateTime(2018, 7, 22),
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
                    },
                    new Product{
                        Id = 6,
                        Name = "Silverqueen",
                        Description = "Coklat susu dengan kacang cashew.",
                        Stock = 80,
                        Price = 12000
                    }
                }
            };
            return store;
        }

        public static void PrintStore(Store toko) {
            Console.WriteLine("====================================");
            Console.WriteLine($"Id: {toko.Id}\nName: {toko.Name}\nAddress: {toko.Address}, Register Date: {toko.RegisterDate.ToString("dd MMMM yyyy")}");
            Console.WriteLine("=============Products==============");
            foreach (var product in toko.ProducsOnSale) {
                Console.WriteLine($"Id:{product.Id}, Name:{product.Name}, Description:{product.Description}, Price:{product.Price}");
            }
            Console.WriteLine("====================================");
        }

        public static string ReturnPath(string fileName) {
            var path = Path.GetFullPath($"../../../Files/{fileName}");
            return path;
        }
    }
}
