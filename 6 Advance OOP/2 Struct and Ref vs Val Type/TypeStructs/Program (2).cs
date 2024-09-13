using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeStructs {
    class Program {

        static void Main(string[] args) {

            int angka = 56;

            StructPerson janet = new StructPerson();
            janet.FirstName = "Janet";
            janet.LastName = "Benoist";
            janet.Age = 23;

            ClassPerson sandy = new ClassPerson();
            sandy.FirstName = "Sandy";
            sandy.LastName = "Seymour";
            sandy.Age = 26;

            //1. Struct merupakan VALUE type, lain dengan Class yang sifatnya Reference Type, sehingga membuat struct sama seperti variable dengan tipe data primitif.
            /*
             * Ada 2 jenis memory type, yaitu Stack dan Heap.
             * Seluruh reference type akan menggunakan Heap seperti class, dan stack seperti value type.
             */
            MakeChanges(angka, janet, sandy);
            Console.WriteLine("angka: {0}, structPerson.FirstName: {1}, classPerson.FirstName: {2}", angka, janet.FirstName, sandy.FirstName);

            //9. Tidak seperti Class, object dari struct bisa diinstantiate tanpa syntax "new".

            //ClassPerson danny;
            //danny.FirstName = "Daniel";

            Manager agung;
            agung.Salary = 5000000m;
         
            StructPerson ronald = new StructPerson();
            ronald.FirstName = "Ronald";
            ronald.LastName = "McCullen";
            ronald.Age = 44;

            ClassPerson samuel = new ClassPerson();
            samuel.FirstName = "Samuel";
            samuel.LastName = "Jackson";
            samuel.Age = 37;

            StructPerson newRonald = ronald;
            ClassPerson newSamuel = samuel;
            newRonald.FirstName = "New Ronald";
            newSamuel.FirstName = "New Samuel";

            //8. Sama seperti variable, saat struct di assign ke variable baru, struct akan menciptakan copy baru, sehingga perubahan pada variable baru tidak mengakibatkan perubahan pada yang lama.
            Console.WriteLine("Ronald First Name: {0}, Samuel First Name: {1}", ronald.FirstName, samuel.FirstName);
        }

        public static void MakeChanges(int angka, StructPerson structPerson, ClassPerson classPerson) {
            angka = 999;
            structPerson.FirstName = "Melinda";
            classPerson.FirstName = "Jessica";
            Console.WriteLine("(Inside MakeChanges) angka: {0}, structPerson.FirstName: {1}, classPerson.FirstName: {2}", angka, structPerson.FirstName, classPerson.FirstName);
        }
    }
}
