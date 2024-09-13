using ClassLibrary;
using System;
using System.Collections.Generic;

namespace GenericTemplate
{
    class Program {
        static void Main(string[] args) {

            Employee jack = new Employee {
                FullName = "Jack Sparrow",
                BirthDate = new DateTime(1988, 11, 27),
                Gender = "Male",
                EmployeeNumber = "J233",
                HireDate = new DateTime(2015, 10, 4),
                Salary = 12000000
            };
            PrintSingleProperty<Employee>(jack, "EmployeeNumber");

            Stakeholder helen = new Stakeholder {
                FullName = "Helen Garcia",
                BirthDate = new DateTime(1982, 12, 27),
                Gender = "Female",
                Company = "Microsoft",
                Business = "Technology"
            };
            PrintSingleProperty<Stakeholder>(helen, "Company");

            List<Person> people = new List<Person> { jack, helen };
            PrintAllForProperty<Person>(people, "FullName");

            List<Staff> staffs = new List<Staff> {
                new Staff("Adrian Hartanto", new DateTime(1987, 10, 8), "Male", "A577", new DateTime(2018,4,4), 7000000, 1000000 ),
                new Staff("Silvia Marrison", new DateTime(1988, 7, 6), "Female", "A587", new DateTime(2019,4,2), 6000000, 500000 )
            };
            PrintAllEmployeeInfo<Staff>(staffs);

            List<Manager> managers = new List<Manager> {
                new Manager("Agustina Suwandi", new DateTime(1986, 1, 5), "Female", "B500", new DateTime(2018,4,4), 30000000, 30),
                new Manager("Donny Darko", new DateTime(1984, 2, 2), "Male", "B501", new DateTime(2017,6,8), 20000000, 25)
            };
            PrintAllEmployeeInfo<Manager>(managers);

            List<Supplier> suppliers = new List<Supplier> {
                new Supplier("Harrison Ford", new DateTime(1986, 1, 5), "Male", "Company X", "Food Industry", "Sales Manager"),
                new Supplier("Johnny Mnemonic", new DateTime(1976, 1, 6), "Male", "Company Y", "Construction", "Sales Manager")
            };
            List<Supplier> updatedSuppliers = GetAndUpdateAllStakeholders<Supplier>(suppliers, "Blue Diamond");
            foreach (var supplier in updatedSuppliers) {
                supplier.PrintCompanyInfo();
            }

            Manager donny = new Manager("Donny Darko", new DateTime(1984, 2, 2), "Male", "B501", new DateTime(2017, 6, 8), 20000000, 25);
            Manager updatedDonny = AssigningDetails<Manager, Staff>(donny, staffs, "Subordinates");

            GroupOfSomething<Person> groupOfPeople = new GroupOfSomething<Person>(people);
            groupOfPeople.PrintAllSelectedProperty("FullName");
            groupOfPeople.PrintAllPropertiesName();

            GroupOfSomething<Staff> groupOfStaff = new GroupOfSomething<Staff>(staffs);
            groupOfStaff.PrintAllSelectedProperty("FullName");
            groupOfStaff.PrintAllPropertiesName();

            Staff adrian = new Staff("Adrian Hartanto", new DateTime(1987, 10, 8), "Male", "A577", new DateTime(2018, 4, 4), 7000000, 1000000);
            Staff silvia = new Staff("Silvia Marrison", new DateTime(1988, 7, 6), "Female", "A587", new DateTime(2019, 4, 2), 6000000, 500000);
            Supplier harrison = new Supplier("Harrison Ford", new DateTime(1986, 1, 5), "Male", "Company X", "Food Industry", "Sales Manager");
            IndependentEntity<Staff>.Entity = adrian;
            IndependentEntity<Staff>.Entity = silvia;
            IndependentEntity<Supplier>.Entity = harrison;
            Console.WriteLine(IndependentEntity<Staff>.GetSelectedProperty("FullName"));
            Console.WriteLine(IndependentEntity<Supplier>.GetSelectedProperty("FullName"));

            GroupOfEmployees<Staff> staffEmployees = new GroupOfEmployees<Staff> {
                Employees = staffs
            };
            staffEmployees.PrintAllEmployeeInfos();
            staffEmployees.PrintAllOriginalDataType();
            GroupOfEmployees<Manager> managerEmployees = new GroupOfEmployees<Manager> {
                Employees = managers
            };
            managerEmployees.PrintAllEmployeeInfos();
            managerEmployees.PrintAllOriginalDataType();
            GroupOfEmployees<Employee> mixEmployees = new GroupOfEmployees<Employee> {
                Employees = new List<Employee> { 
                    jack, donny, adrian
                }
            };
            mixEmployees.PrintAllEmployeeInfos();
            mixEmployees.PrintAllOriginalDataType();

            GroupOfSpecificPeople<Staff> groupOfSpecificStaff = new GroupOfSpecificPeople<Staff>(staffs);
            groupOfSpecificStaff.PrintAllPropertiesName();
            groupOfSpecificStaff.PrintAllMethodsName();

            GroupOfSpecificEmployees<Manager> groupOfSpecificManagers = new GroupOfSpecificEmployees<Manager> { 
                Employees = managers
            };
            groupOfSpecificManagers.PrintAllWorkingDuration();

            GroupOfHeaderDetails<Manager, Staff> donnyHeaderDetails = new GroupOfHeaderDetails<Manager, Staff>(updatedDonny, updatedDonny.Subordinates);
            donnyHeaderDetails.PrintHeaderAndDetails();
        }

        /* Generic adalah template data type yang bisa diatur pada saat pemakaian pada sebuah method atau class.
         * 
         * Generic memungkinkan satu macam tipe data pada class atau pada method untuk dipakai beberapa kali dalam pengaplikasian tipe data yang berbeda.
         * Contoh paling mencolok dalam Generic adalah tipe-tipe generic collection seperti List misalnya.
         */
        //Ini adalah contoh Generic yang mengatur tipe data pada parameter, dan yang tidak memiliki constraint.
        public static void PrintSingleProperty<Template>(Template anyObject, string propertyName) {
            var type = anyObject.GetType();
            var value = type.GetProperty(propertyName).GetValue(anyObject);
            Console.WriteLine($"{propertyName} : {value}");
        }

        //Penggunaan generic juga bisa kita pass dari generic ke generic seperti contoh di bawah.
        public static void PrintAllForProperty<Template>(List<Template> collections, string propertyName) {
            foreach (Template anyObject in collections) {
                var type = anyObject.GetType();
                var value = type.GetProperty(propertyName).GetValue(anyObject);
                Console.WriteLine($"{propertyName} : {value}");
            }
        }

        /*
         * Saat sebuah generic tidak memiliki constraint, mengakses member dari tipe data tersebut menjadi sulit.
         * Oleh karena itu dibuatkan constraint pada Generic.
         * 
         * Semua generic di bawah ini memiliki constraint, atau batasan.
         * Semua constraint ditandai dengan keyword "where".
         * 
         * Beberapa constraint yang dimiliki Generic adalah seperti di bawah ini:
         * 
         * 1. where Template : struct
         * Ini artinya template harus berasal dari struct, sehingga generic akan menolak semua yang bukan struct
         * 
         * 2. where Template : class
         * Ini artinya template harus berasal dari class, sehingga generic akan menolak semua yang bukan class
         * 
         * 3. where Template : unmanaged
         * Ini artinya template harus berasal dari tipe data yang tidak reference type, atau harus stack type
         * 
         * 4. where Template : (Type)
         * Template ini diatur oleh nama class, nama base class, nama abstract class, nama interface atau nama struct tertentu.
         */
        public static void PrintAllEmployeeInfo<Template>(List<Template> collections) where Template : Employee {
            //Dengan menggunakan constraint, kita bisa meminimalkan penggunaan reflection dan kembali ke prinsip polymorphism
            foreach (var employee in collections) {
                employee.PrintEmployeeInfo();
                Type employeeType = employee.GetType();
                var paymentSlipInfo = employeeType.GetMethod("PaymentSlip");
                paymentSlipInfo.Invoke(employee, null);
            }
        }

        /*Template juga bisa mengatur return typenya.
         *Note: constraint class tidak bisa digabung dengan Stakeholder, karena Stakeholder sudah pasti class, dengan menggunakan IStakeholder, template belum tentu adalah class.
         *  Sehingga constraint class jadi jelas fungsinya
         */
        public static List<Template> GetAndUpdateAllStakeholders<Template>(List<Template> stakeholders, string companyName) where Template : class, IStakeholder {
            List<Template> updatedStakeholders = new List<Template>();
            foreach (var stakeholder in stakeholders) {
                stakeholder.Company = companyName;
                updatedStakeholders.Add(stakeholder);
            }
            return updatedStakeholders;
        }

        //Contoh penggunaan lebih dari satu template.
        public static TemplateHeader AssigningDetails<TemplateHeader, TemplateDetail>(TemplateHeader header, List<TemplateDetail> details, string propertyName) {
            Type headerType = header.GetType();
            var propertyInfo = headerType.GetProperty(propertyName);
            propertyInfo.SetValue(header, details);
            return header;
        }

    }
}
