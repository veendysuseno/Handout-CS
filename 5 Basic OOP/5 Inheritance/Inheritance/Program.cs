using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance {
    class Program {
        static void Main(string[] args) {

            Person michael = new Person("Michael Shanon", new DateTime(1988, 10, 20), "Jakarta", "Male", "31279523490088", "Christian", 'O', 172, 69.55, "Indonesia");
            Student sarah = new Student("Sarah Brightman", new DateTime(1987, 11, 30), "California", "Female", "30334589793455", "Buddhist", 'A', 180, 60.78, "USA", "MIT", 
                "Massachusset", "IT", new DateTime(2018, 12, 27), 4);
            Customer ricky = new Customer("Ricky Gervais", new DateTime(1984, 12, 12), "London", "Male", "234888890888909009", "Christian", 'B', 145, 67.89, "Englandd", 
                "R556", 5600000.50m, 50500, new DateTime(2016, 10, 24));
            Employee rudy = new Employee("Rudy Wijaya", new DateTime(1987, 2, 5), "Bandung", "Male", "45677900004523422", "Moslem", 'O', 170, 75.50, "Indonesia", "R2340888", 
                "IT", 6, 575000, new DateTime(2012, 11, 5));
            Employee damar = new Employee("Damar Sianturi", new DateTime(1987, 2, 5), "Aceh", "Male", "4567790000454552", "Moslem", 'O', 170, 75.50, "Indonesia", "R2355888",
                "IT", 6, 575000, new DateTime(2012, 11, 5));
            List<Employee> groupEmployees = new List<Employee>() { rudy, damar };
            Manager robert = new Manager("Robert Downey", new DateTime(1985, 2, 5), "Bali", "Male", "45677900002344422", "Moslem", 'O', 175, 65.50, "Indonesia", "R2340888",
                "IT", 6, 575000, new DateTime(2012, 11, 5), 23.5, "Store Manager", "Legian", groupEmployees);

            //Sarah bisa mengakses property dan method Person maupun Student
            Console.WriteLine(sarah.Name);
            Console.WriteLine(sarah.UniversityLocation);
            sarah.PrintPersonalInformation();
            sarah.PrintEducationInformation();

            //Robert bisa mengakses property dan method Person, Employee, dan Manager
            Console.WriteLine(robert.Name);
            Console.WriteLine(robert.HiredDate);
            Console.WriteLine(robert.ManagerType);
            robert.PrintPersonalInformation();
            robert.PrintManagerialInfo();

            //overriding method
            rudy.PrintEmployeeInfo();
            robert.PrintEmployeeInfo();

            /*
             * Polymorphism: dalam bahasa yunani Poly dan Morph yang artinya banyak bentuk.
             * Polymorphism memanfaatkan base class dari setiap jenis class object nya, sehingga semua bisa di declare ke dalam satu bentuk.
             */
            Person cindy = new Student("Cindy Garcia", new DateTime(1987, 11, 30), "California", "Female", "30334589793455", "Buddhist", 'A', 180, 60.78, "USA", "MIT",
                "Massachusset", "IT", new DateTime(2018, 12, 27), 4);
            Person garry = new Customer("Garry Oldman", new DateTime(1984, 12, 12), "London", "Male", "234888890888909009", "Christian", 'B', 145, 67.89, "Englandd",
                "R556", 5600000.50m, 50500, new DateTime(2016, 10, 24));
            Person brian = new Employee("Brian Soprano", new DateTime(1987, 2, 5), "Medan", "Male", "456667000400422", "Christian", 'O', 170, 75.50, "Indonesia", "R2340888",
                "IT", 8, 577000, new DateTime(2010, 8, 5));
            Person arifin = new Manager("Arifin Nurwansa", new DateTime(1985, 2, 5), "Bali", "Male", "456779000444422", "Hindu", 'O', 175, 65.50, "Indonesia", "R236788",
                "IT", 6, 575000, new DateTime(2012, 11, 5), 23.5, "Store Manager", "Legian", groupEmployees);


            List<Person> kelompokManusia = new List<Person>() { cindy, garry, brian, arifin };
            foreach (Person manusia in kelompokManusia) {
                manusia.PrintPersonalInformation();
            }

            //Polymorphism in overriding

            Employee aji = new Employee("Aji Sanjaya", new DateTime(1980, 2, 17), "Bandung", "Male", "45677900004523422", "Moslem", 'O', 170, 75.50, "Indonesia", "R2340888",
                "IT", 6, 575000, new DateTime(2012, 11, 5));
            Employee sakti = new Manager("Sakti Kutrapali", new DateTime(1985, 2, 5), "India", "Male", "45677900002344422", "Hindu", 'O', 175, 65.50, "India", "R2340888",
                "IT", 6, 575000, new DateTime(2012, 11, 5), 23.5, "Store Manager", "Legian", groupEmployees);

            //keduanya akan menggunakan method pada base class, yaitu employee class, karena deklarasi tipe datanya di parent.
            aji.PrintEmployeeInfo();
            sakti.PrintEmployeeInfo();

            //Ini tidak bisa, karena sakti sudah jadi employee, tapi tidak berarti informasi bonus percentagenya hilang.
            //sakti.PrintManagerialInfo();
            //sakti.BonusPercentage

            //Re-Casting
            Manager saktiManager = (Manager)sakti;
            var bonus = saktiManager.BonusPercentage;
            Console.WriteLine(bonus);
            saktiManager.PrintManagerialInfo();

            Student jodi = new Student("Jodi Pusaka", new DateTime(1996, 12, 30), "Aceh", "Male", "30334589793455", "Moslem", 'A', 180, 60.78, "USA", "MIT",
                "Massachusset", "IT", new DateTime(2018, 12, 27), 4);
            Student ronald = new PhdStudent("Ronald Wijaya", new DateTime(1988, 10, 21), "Surabaya", "Male", "3133454345745", "Moslem", 'A', 180, 60.78, "USA", "MIT",
                "Massachusset", "IT", new DateTime(2018, 12, 27), 4);

            //virtual dan override key word akan mengakibatkan hasil yang opposite dari new keyword. Keduanya akan print berdasarkan method pada saat dia di construct.
            jodi.PrintEducationInformation();
            ronald.PrintEducationInformation();

        }
    }
}
