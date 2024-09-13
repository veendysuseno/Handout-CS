using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceAndAbstractClass {
    class Program {
        static void Main(string[] args) {

            /* Interface adalah kontrak atau template keharusan dari setiap class atau interface lain yang mewariskannya untuk mengikuti setiap member yang interface tuliskan.
             * Sifat-sifat interface adalah:
             * 1.Semua class yang mewariskan interface harus memiliki member property dan method yang dituliskan interface.
             * 2.Interface hanya bisa inherit dari interface lain.
             * 3.Setiap member di dalam interface tidak memiliki access modifier.
             * 4.Seluruh property dan method di dalam interface hanya bisa di deklarasi, tetapi tidak bisa diimplementasikan.
             * 5.Naming convention dari interface sama seperti class, bedanya ada huruf I besar di depan namanya.
             * 6.Interface gak bisa di instantiate atau dibuat objectnya secara langsung.
             * 7.Satu class bisa inherit lebih dari satu interface.
             */

            /* Abstract class adalah campuran daripada interface dan base class biasa.
             * Sifat-sifat abstract class kurang lebih:
             * 1. Tidak bisa di instantiate seperti Interface, karena tidak ada gunanya membuat object dari class yang sifatnya abstrak.
             * 2. Tidak seperti Interface, abstract bisa memiliki member yang diimplementasi
             * 3. Member yang tidak diimplementasi dan menjadi contract, di label sebagai abstract.
             * 4. Method abstract bisa di override di class yang menjadi keturunannya.
             * 5. Sisa method yang tidak di declare abstract akan bersifat seperti member dari base class biasa.
             */

            //Tidak bisa instantiate Electronic, Employee, ICitizen, IMobilePhone, IPerson, IResident, Item

            Customer alexa = new Customer() {
                FirstName = "Alexa",
                LastName = "Red",
                Gender = "Female",
                BirthDate = new DateTime(1989, 10, 21),
                BirthPlace = "Jakarta",
                IDCardNumber = "314999006788",
                Citizenship = "Indonesia",
                MaritalStatus = "Single",
                MemberCode = "KC8371934",
                Balance = 500000m
            };

            IPerson susan = new Customer() {
                FirstName = "Susan",
                LastName = "Ryle",
                Gender = "Female",
                BirthDate = new DateTime(1978, 10, 21),
                BirthPlace = "Jakarta",
                IDCardNumber = "314999006788",
                Citizenship = "Indonesia",
                MaritalStatus = "Single",
                MemberCode = "KC8371934",
                Balance = 500000m
            };

            Console.WriteLine("==================== ALEXA THE CUSTOMER ======================");
            alexa.CalculateAge();
            alexa.PrintBiodata();
            alexa.PrintPersonIdentity();
            alexa.PrintMemberInformation();
            Console.WriteLine("==============================================================\n");

            Console.WriteLine("==================== SUSAN THE IPERSON, CUSTOMER ======================");
            susan.CalculateAge();
            susan.PrintBiodata();
            susan.PrintPersonIdentity();
            Console.WriteLine("==============================================================\n");

            TaxResident john = new TaxResident() {
                VisaStatus = "Citizen",
                TaxFileNumber = "HG768324XNN",
                VisaGrantTime = new DateTime(1978, 8, 12),
                FirstName = "John",
                LastName = "Connor",
                Gender = "Male",
                BirthDate = new DateTime(1978, 8, 12),
                BirthPlace = "Jakarta",
                IDCardNumber = "13847192838479234",
                Citizenship = "United States of America",
                MaritalStatus = "Married",
                CitizenMedicalInsuranceShipProgram = true,
                CitizenshipLifeInsuranceProgram = false,
                CitizenshipRetirementProgram = false
            };

            Console.WriteLine("==================== JOHN THE TAX RESIDENT ======================");
            john.CalculateAge();
            john.PrintBiodata();
            john.PrintPersonIdentity();
            john.PayTax();
            john.ResidencyInformation();
            Console.WriteLine("==============================================================\n");

            /*Bisa instantiate Tax Resident di banyak data type*/
            IResident andre = new TaxResident();
            ICitizen silvia = new TaxResident();
            IPerson sumandi = new TaxResident();

            Manager sheldon = new Manager("Temporary Resident", "JK7998714VVN", new DateTime(2012, 11, 12), "Sheldon", 
                "Cooper", "Male", new DateTime(1967, 10, 8), "Texas", "93417923741093824", "USA", "Single");
            sheldon.EmployeeNumber = "123";
            sheldon.HireDate = new DateTime(2012, 7, 22);

            Console.WriteLine("==================== SHELDON THE MANAGER ======================");
            sheldon.CalculateAge();
            sheldon.EmployeeInformation();
            sheldon.PayTax();
            sheldon.PrintBiodata();
            sheldon.PrintPersonIdentity();
            sheldon.ResidencyInformation();
            sheldon.GetAnnualSalary();
            sheldon.YearsOfWorking();
            Console.WriteLine("==============================================================\n");

            /*Instantiate di tipe data lain*/
            Employee brian = new Manager("Temporary Resident", "JK799KJDLFJ", new DateTime(2012, 11, 12), "Brian",
                "Soprano", "Male", new DateTime(1967, 10, 8), "Texas", "93417923741093824", "USA", "Single");
            IResident mustafa = new Manager("Temporary Resident", "JK788KDFJFJ", new DateTime(2012, 11, 12), "Mustafa",
                "Mamfud", "Male", new DateTime(1987, 10, 8), "Saudi Arabia", "93417923741093824", "Saudi Arabia", "Married");

            //Feature di C# terbaru bisa memeriksa apakah satu deklarasi polymorphism di construct dari satu class turunannya.
            if (susan is Customer) {
                Console.WriteLine("Susan is Customer");
            }
            if (susan is Customer customer) {
                Console.WriteLine("{0} is a Customer", customer.FirstName);
            }

            Item permata = new Jewelries("9837592734", "gelang permata", "brumani", 50000000, "platinum");
            Item iphone = new SmartPhone("7491273941", "iphone 6", "Apple", 10000000, 2, "GSM", "IOS");
            Item cocaCola = new SoftDrink("874917234829", "coca-cola", "Coca Cola", 5000, new DateTime(2019, 10, 19));

            if (iphone is SmartPhone) {
                Console.WriteLine("Iphone is smartphone");
            }
            if (iphone is Jewelries) {
                Console.WriteLine("Iphone is jewelry");
            }
        }
    }
}
