using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternMatching {
    class Program {
        static void Main(string[] args) {

            /*
             * Pattern matching adalah feature di dalam C# untuk melakukan cross check tipe data dari sebuah object..
             * pattern matching membandingkan tipe data dengan menggunakan keyword "is"
             * 
             * Feature ini bisa digunakan untuk memfilter sebelum meng-unbox polymorph yang sifatnya covariance pada tipe data parentnya.
             */

            Employee aldhi = new Employee("Aldhi", 'M', new DateTime(1988, 10, 23), "Jakarta", 15000000, "A233CAH", new DateTime(2018, 6, 28));
            MobilePhone iphone = new MobilePhone("Iphone 6s", 5500000, "Iphone", "Gray", 2);
            Employee michael = new Employee("Michael", 'M', new DateTime(1988, 8, 21), "Jakarta", 15000000, "K4457CAH", new DateTime(2018, 6, 28));
            MobilePhone galaxy = new MobilePhone("Galaxy J5 prime", 5500000, "Samsung", "Blue", 4);

            CompareDataType(aldhi);
            CompareDataType(iphone);

            CompareAbstractDataType(aldhi);
            CompareAbstractDataType(iphone);

            SwitchCaseStyle(aldhi);
            SwitchCaseStyle(iphone);

            WhenSwitchCaseStyle(aldhi);
            WhenSwitchCaseStyle(michael);
            WhenSwitchCaseStyle(iphone);
            WhenSwitchCaseStyle(galaxy);
        }

        //Dengan is, system bisa membedakan mana yang object employee atau mobile phone
        public static void CompareDataType(object parameter) {
            if (parameter is Employee) {
                Console.WriteLine("Parameter is employee");
            } else if (parameter is MobilePhone) {
                Console.WriteLine("Parameter is mobile");
            } else {
                Console.WriteLine("Parameter is not employee or not mobile");
            }
        }

        //Bisa dibandingkan dengan base classnya juga.
        public static void CompareAbstractDataType(object parameter) {
            if (parameter is Person) {
                Console.WriteLine("Parameter is person");
            } else if (parameter is Item) {
                Console.WriteLine("Parameter is item");
            } else {
                Console.WriteLine("Parameter is not person or not item");
            }
        }

        //Style seperti ini digunakan pada kasus switch case
        public static void SwitchCaseStyle(object parameter) {
            switch (parameter) {
                case Employee emp:
                    Console.WriteLine($"{emp.Name} is an employee");
                    break;
                case MobilePhone mob:
                    Console.WriteLine($"{mob.Name} is a mobile phone");
                    break;
                default:
                    Console.WriteLine("Not an employee or mobile phone");
                    break;
            }
        }

        //Switch case dengan comparison logic
        public static void WhenSwitchCaseStyle(object parameter) {
            switch (parameter) {
                case Employee emp when emp.Name == "Aldhi":
                    Console.WriteLine("Yes! This is Aldhi!");
                    break;
                case Employee emp:
                    Console.WriteLine($"{emp.Name} is an employee");
                    break;
                case MobilePhone mob when mob.Brand == "Samsung" && mob.Memory == 4:
                    Console.WriteLine($"{mob.Name} is samsung with 4Gb memory");
                    break;
                case MobilePhone mob:
                    Console.WriteLine($"{mob.Name} is a mobile phone");
                    break;
                default:
                    Console.WriteLine("Not an employee or mobile phone");
                    break;                
            }
        }

    }
}
