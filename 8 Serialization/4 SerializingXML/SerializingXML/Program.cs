using SerializingXML.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace SerializingXML
{
    class Program
    {
        static void Main(string[] args) {
            SerializationProcess();
            DeserializationProcess();
        }

        public static void SerializationProcess() {
            var indomaret = MakeStore();
            var serializer = new XmlSerializer(typeof(Store));
            string writePath = ReturnPath("store.xml");
            using (Stream stream = File.Create(writePath)) {
                serializer.Serialize(stream, indomaret);
            }
        }

        public static void DeserializationProcess() {
            var serializer = new XmlSerializer(typeof(Store));
            string readPath = ReturnPath("store.xml");
            Store indomaret;
            using (Stream stream = File.OpenRead(readPath)) {
                indomaret = (Store)serializer.Deserialize(stream);
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
