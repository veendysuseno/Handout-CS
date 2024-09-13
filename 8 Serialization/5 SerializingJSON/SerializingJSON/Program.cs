using SerializingJSON.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace SerializingJSON
{
    class Program
    {
        static void Main(string[] args) {
            SerializationProcess();
            DeserializationProcess();
        }

        public static void SerializationProcess() {
            var indomaret = MakeStore();
            var options = new JsonSerializerOptions {
                WriteIndented = true
            };
            string jsonString = JsonSerializer.Serialize(indomaret, options);
            string writePath = ReturnPath("store.json");
            using (StreamWriter writer = new StreamWriter(writePath)) {
                writer.WriteLine(jsonString);
            }
        }

        public static void DeserializationProcess() {
            string pathRead = ReturnPath("store.json");
            var jsonString = new StringBuilder();
            using (StreamReader reader = new StreamReader(pathRead)) {
                string line;
                while ((line = reader.ReadLine()) != null) {
                    jsonString.Append(line);
                }
            }
            Store indomaret = JsonSerializer.Deserialize<Store>(jsonString.ToString());
            PrintStore(indomaret);
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
