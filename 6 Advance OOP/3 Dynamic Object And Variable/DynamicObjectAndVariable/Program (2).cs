using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicObjectAndVariable {
    class Program {
        static void Main(string[] args) {

            //Melihat perbedaan dari var, object dan dynamic 
            /* object: 
             * 1. Baik itu class, struct, primitive tipe data, sebuah object, variable, semuanya secara langsung atau tidak langsung meng-inherit object.
             * 2. Sudah ada dari C# 1.0, adalah nenek moyang dari semua tipe data.
             * 3. Penulisannya sendiri sebenarnya merupakan kependekan dari library System.Object.
             * 4. Seperti prinsip pada polymorphism, karena object merupakan moyang dari semuanya, semua assignment tipe data bisa di assign ke dalam deklarasi object.
             * 5. Proses memasukan suatu value ke dalam object disebut juga Boxing.
             * 6. Proses casting kembali suatu variable dengan tipe data object ke dalam tipe data sebelumnya, disebut juga Unboxing.
             * 7. Object merupakan value type.
             */

            string sebuahKata = "Hello World.";
            int bilanganBulat = 45;
            Person person = new Person("Ben Grims", 34);
            Employee employee = new Employee(9837, "Susan Doyle");

            //4. Seperti prinsip pada polymorphism, karena object merupakan moyang dari semuanya, semua assignment tipe data bisa di assign ke dalam deklarasi object.
            object box1 = sebuahKata;
            object box2 = bilanganBulat;
            object box3 = person;
            object box4 = employee;

            //7. Object merupakan value type.
            ChangeValue(box1);
            Console.WriteLine(box1);

            //6. Proses casting kembali suatu variable dengan tipe data object ke dalam tipe data sebelumnya, disebut juga Unboxing.
            UnboxingString(box1);
            UnboxingInteger(box2);
            UnboxingObjectClass(box3);
            UnboxingObjectStruct(box4);

            /* dynamic:
             * 1. Dynamic merupakan value type.
             * 2. Dynamic data type tidak memiliki evaluasi dan validasi saat compile phase, artinya tidak akan build error walaupun tipe datanya salah. Dynamic hanya akan error di run time.
             * 3. Sifat lain dynamic seperti object, dynamic muncul di c# 4.
             */

            dynamic dynamicString = sebuahKata;
            dynamic dynamicInteger = bilanganBulat;
            dynamic dynamicObjectClass = person;
            dynamic dynamicObjectStruct = employee;

            ChangeDynamicValue(dynamicString);
            Console.WriteLine(dynamicString);

            //2. Dynamic data type tidak memiliki evaluasi dan validasi saat compile phase, artinya tidak akan build error walaupun tipe datanya salah. Dynamic hanya akan error di run time.
            //int hasil = dynamicString + 10;

            Console.WriteLine(person.Name);
            Console.WriteLine(dynamicObjectClass.Name); //Tidak tahu error apa gak, pada saat di run baru ketahuan.
            //Console.WriteLine(dynamicObjectClass.TanggalLahir); //akan menyebabkan error pada saat di run saja

            int result = dynamicInteger + 10;
            Console.WriteLine(result);

            Console.WriteLine(DynamicInteger(dynamicInteger));

            /* Anonymous Type/ Var:
             * 1. Var tidak bisa di deklarasi tanpa di assign, karena tipe data var dibuat pada saat assign value.
             * 2. variable yang di declar var dan di assign akan selamanya menjadi deklarasi tersebut, sehingga tidak bisa dipakai sebagai tipe data lain.
             * 3. var tidak bisa digunakan untuk parameter.
             */

            object objectDeclaration;
            object objectVariable = "Hello My Friend";
            objectVariable = 68;
            Console.WriteLine("object variable is {0}, with type {1}", objectVariable, objectVariable.GetType());

            dynamic dynamicDeclaration;
            dynamic dynamicVariable = "Hello My Friend";
            dynamicVariable = 34;
            Console.WriteLine("dynamic variable is {0}, with type {1}", dynamicVariable, dynamicVariable.GetType());

            //var declaration;
            var variableAssignment = "Hello My Friend";
            //variableAssignment = 45;
            variableAssignment = "This is great";
            Console.WriteLine("variable is {0}, with type {1}", variableAssignment, variableAssignment.GetType());

        }

        public static void ChangeValue(object objectArg) {
            objectArg = "Change the value.";
        }
        public static void UnboxingString(object objectArg) {
            string unbox = (string)objectArg;
            Console.WriteLine(unbox.ToUpper());
        }
        public static void UnboxingInteger(object objectArg) {
            int result = (int)objectArg + 3;
            Console.WriteLine("The result is {0}", result);
        }
        public static void UnboxingObjectClass(object objectArg) {
            Person unbox = (Person)objectArg;
            Console.WriteLine(unbox.Name);
        }
        public static void UnboxingObjectStruct(object objectArg) {
            Employee unbox = (Employee)objectArg;
            Console.WriteLine(unbox.Name);
        }

        public static void ChangeDynamicValue(dynamic dynamicArg) {
            dynamicArg = "Change the value";
        }

        public static int DynamicInteger(dynamic dynamicInteger) {
            int result = dynamicInteger + 5;
            return result;
        }

    }
}
