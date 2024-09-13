using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousType
{
    class Program
    {
        static void Main(string[] args) {

            /*
             * Anonymous object adalah object yang dibentuk dengan menggunakan deklarasi var, tanpa harus membuat class dan constructornya dulu untuk
             * meng-instantiatenya.
             * 
             * Anonymous object memiliki limitasi tertentu dan memiliki tipe data yang anonymous (tidak diketahui).
             * Anonymous pada C# bisa dikatakan adalah cara adaptasi C# membuat object literal yang biasa dilakukan pada javascript.
             * 
             * Tapi lain dengan javascript 2 limitasi pertamanya adalah, member dari anonymous harus property, tidak bisa function atau delegates.
             * Isi dari Property juga tidak boleh null.
             */
            var person = new {
                Name = "Walter",
                Age = 37,
                HireDate = new DateTime(2012, 5, 4),
                IsMarried = true,
                //Level = null
            };

            //Cara membaca value property dari anonymous object sama seperti biasa.
            Console.WriteLine($"{person.Name}, {person.Age}, {person.HireDate.ToString("dd MMMM yyyy")}, {person.IsMarried}");

            //Tipe datanya adalah anonymous dan dijelaskan setiap tipe data propertynya di sana.
            Console.WriteLine(person.GetType());

            //Seluruh anonymous object, value dari propertynya bersifat read only, jadi tidak bisa di set.
            //person.Name = "Mike";

            //Terkecuali ke object atau ke deklarasi dynamic, anonymous type tidak bisa di cast ke tipe data lain.
            object personObject = person;
            dynamic personDynamic = person;

            //Annonymous Array: Seluruh object di dalam array harus memiliki jumlah dan nama property yang sama
            var anonymousArray = new[] {
                new{
                    Name = "Albert",
                    Age = 37
                },
                new {
                    Name = "Ben",
                    Age = 36
                },
                new {
                    Name = "Calvin",
                    Age = 36
                }
            };

            //Untuk membuat list anonymous kalian harus menggunakan trik seperti di bawah ini.
            var anonymousList = (new[] {
                new{
                    Name = "Albert",
                    Age = 37
                },
                new {
                    Name = "Ben",
                    Age = 36
                },
                new {
                    Name = "Calvin",
                    Age = 36
                }
            }).ToList();

        }

        //Tidak ada return data type anonymous, harus dikembalikan dalam bentuk object biasa.
        public static object GetAnonymous() {
            var person = new {
                Name = "Sonya",
                HireDate = new DateTime(2012, 3, 4),
                IsMarried = true
            };
            return person;
        }
    }
}
