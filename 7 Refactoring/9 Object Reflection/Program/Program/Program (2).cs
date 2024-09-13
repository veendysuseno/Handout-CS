using System;
using System.Collections.Generic;
using System.Reflection;

namespace Program
{
    class Program
    {
        /*
         * Reflection / Object reflection adalah cara atau teknik melakukan inspecting metadata atau hasil code yang sudah di compiled pada run-time.
         * 
         * Hasil compiled isinya hampir semua content dari original source code, sebagian lagi hilang seperti nama local variable dan comment.
         * Sisanya yang tidak hilang bisa diakses oleh reflection, sehingga memungkinkan kita untuk menulis decompiler pada dll atau code apa pun yang sudah di compile.
         * 
         * Kegunaan lain dari reflection adalah untuk membuat dynamic binding pada type object apa pun yang di autoboxing.
         */
        static void Main(string[] args) {
            RunTimeVSCompileTime();
            GetIntegerDataType();
            GetStringDataType();
            GetDateTimeDataType();
            GetArrayDataType();
            GetPersonDataType();
            GetStudentDataType();
            GetStakeHolderDataType();
            GetCustomerDataType();
            GetSupplierDataType();
        }
        public static void RunTimeVSCompileTime() {
            string helloWorld = "Hello World";
            /*  Kita bisa melakukan inspeksi terhadap satu tipe data dengan menggunakan Type.
             *  Memperoleh Type bisa diperoleh dari GetType() method dari variable atau object yang bersangkutan, dimana akan di proses pada saat run time,
             *  atau dengan menggunakan typeof pada tipe datanya langsung, dimana ini akan diproses pada saat compile time.
             */
            Type typeOne = helloWorld.GetType(); //Di dapatkan pada saat run time
            Type typeTwo = typeof(string); //Di dapatkan pada saat compile time
            Console.WriteLine($"Run Time: {typeOne}");
            Console.WriteLine($"Compile Time: {typeTwo}");
            Console.WriteLine("=====================================================\n");
        }
        #region Fungsi pengguna
        public static void GetIntegerDataType() {
            int number = 56;
            GetTypeReflection(number);
            Console.WriteLine("===========================================================================================\n");
        }
        public static void GetStringDataType() {
            string word = "Hello World";
            GetTypeReflection(word);
            Console.WriteLine("===========================================================================================\n");
        }
        public static void GetDateTimeDataType() {
            DateTime today = DateTime.Today;
            GetTypeReflection(today);
            Console.WriteLine("===========================================================================================\n");
        }
        public static void GetArrayDataType() {
            int number = 89;
            Type toArrayType = number.GetType().MakeArrayType();
            Console.WriteLine($"To Array Type: {toArrayType.Name}");
            int[] numberArray = { 5, 7, 9 };
            Type toNormalType = numberArray.GetType().GetElementType();
            Console.WriteLine($"To Normal ELement Type: {toNormalType.Name}");
            GetTypeReflection(numberArray);
            Console.WriteLine("===========================================================================================\n");
        }
        public static void GetPersonDataType() {
            Person arif = new Person {
                Name = "Arif",
                BirthDate = new DateTime(1972, 8, 26)
            };
            GetTypeReflection(arif);
            GettingMemberInfo(arif);
            Console.WriteLine("===========================================================================================\n");
        }
        public static void GetStudentDataType() {
            Student adit = new Student {
                Name = "Aditya",
                BirthDate = new DateTime(1992, 7, 23),
                StudentNumber = "A123"
            };
            GetTypeReflection(adit);
            GettingMemberInfoNetCore(adit);
            Console.WriteLine("===========================================================================================\n");
        }
        public static void GetStakeHolderDataType() {
            Stakeholder ben = new Stakeholder {
                Name = "Ben",
                BirthDate = new DateTime(1986, 4, 5),
                CompanyName = "Microsoft"
            };
            GetTypeReflection(ben);
            GetSingleMemberFromObject(ben, "CompanyName");
            GetSingleProperty(ben, "CompanyName");
            SetPropertiesValue(ben, "CompanyName", "Google");
            GetAllProperties(ben);
            GetDeclaredPropertiesNetCore(ben);
            GetDeclaredPropertiesBindingFlags(ben);
            Console.WriteLine("===========================================================================================\n");
        }
        public static void GetCustomerDataType() {
            Customer calvin = new Customer {
                Name = "Calvin",
                BirthDate = new DateTime(1993, 6, 7),
                CompanyName = "Jaya Abadi",
                Balance = 2500000
            };
            GetTypeReflection(calvin);
            InvokingMethod(calvin, "CalculateAge");
            InvokingMethod(calvin, "CheckBalance");
            object[] parameters = { 200000M, "Brian" };
            InvokingMethod(calvin, "TransferMoneyTo", parameters);
            FindAllBaseType(calvin);
            Console.WriteLine("===========================================================================================\n");
        }
        public static void GetSupplierDataType() {
            Supplier donny = new Supplier {
                Name = "Donny",
                BirthDate = new DateTime(1987, 5, 6),
                CompanyName = "Indofood",
                CompanyAddress = "Jln. XYZ"
            };
            GetTypeReflection(donny);
            Type type = typeof(Supplier);
            ConstructObject<Supplier>(type, donny);
            Console.WriteLine("===========================================================================================\n");
        }

        #endregion
        public static void GetTypeReflection(object anyObject) {
            Type type = anyObject.GetType();
            Console.WriteLine($"Type: {type}");
            Console.WriteLine($"Name: {type.Name}"); //Nama dari data typenya
            Console.WriteLine($"Base Type: {type.BaseType}"); //Parent/ Base typenya
            Console.WriteLine($"Assembly: {type.Assembly}"); //Name space assemblynya
        }
        public static void GettingMemberInfo(object anyObject) {
            Type type = anyObject.GetType();
            /* MemberInfo merupakan tipe data pada System.Reflection, yang gunanya untuk menampung seluruh metadata dari member, baik itu field, property, constructor, method, dan lainnya.
             * Multiple member di terima dalam member infos array hasil dari method GetMembers().
             */
            MemberInfo[] memberInfos = type.GetMembers();
            Console.WriteLine("+++++ MEMBER INFOS +++++");
            foreach (MemberInfo member in memberInfos) {
                Console.WriteLine($"Member: {member}");
                Console.WriteLine($"    Nama: {member.Name}");
                Console.WriteLine($"    Type: {member.MemberType}");
            }
        }
        public static void GettingMemberInfoNetCore(object anyObject) {
            Type type = anyObject.GetType();
            /* Langkah di bawah ini cara mendapatkan member info pada .net core (.net framework standard biasa tidak bisa).
             * Hasilnya bisa di terima dengan collection IEnumerable, dan kita bisa langsung mendapatkan members dengan filter tanpa harus menggunakan BindingFlags
             */
            IEnumerable<MemberInfo> memberInfos = type.GetTypeInfo().DeclaredMembers; //DeclaredMembers hanya pendapatkan member yang ditulis pada class tersebut, yang di inherit tidak masuk.
            Console.WriteLine("+++++ .NET CORE MEMBER INFOS +++++");
            foreach (MemberInfo member in memberInfos) {
                Console.WriteLine($"Member: {member}");
                Console.WriteLine($"    Name: {member.Name}");
                Console.WriteLine($"    Type: {member.MemberType}");
            }
        }
        public static void GetSingleMemberFromObject(object anyObject, string memberName) {
            Type type = anyObject.GetType();
            MemberInfo[] memberInfos = type.GetMember(memberName); //Mendapatkan satu member dengan menggunakan namanya
            MemberInfo selectedMemberInfo = memberInfos[0];
            Console.WriteLine("+++++ GET SINGLE MEMBER +++++");
            Console.WriteLine($"Selected {memberName} is {selectedMemberInfo}");
            Console.WriteLine($"    Name: {selectedMemberInfo.Name}");
            Console.WriteLine($"    Member Type: {selectedMemberInfo.MemberType}");
            Console.WriteLine($"    Reflected Type: {selectedMemberInfo.ReflectedType}"); //Tipe Data yang memiliki member ini.
        }
        public static void GetSingleProperty(object anyObject, string propertyName) {
            //Mendapatkan satu property dan mendapatkan nilai dari property tersebut.
            Type type = anyObject.GetType();
            PropertyInfo propertyInfo = type.GetProperty(propertyName);
            var value = propertyInfo.GetValue(anyObject);
            Console.WriteLine($"The value of Property {propertyName} is {value}");
        }
        public static void SetPropertiesValue(object anyObject, string propertyName, string propertyValue) {
            //Set value untuk satu property.
            Console.WriteLine($"+++++ SET {propertyName} with {propertyValue}  +++++");
            Type type = anyObject.GetType();
            PropertyInfo propertyInfo = type.GetProperty(propertyName);
            propertyInfo.SetValue(anyObject, propertyValue);
        }
        public static void GetAllProperties(object anyObject) {
            Type type = anyObject.GetType();
            PropertyInfo[] propertyInfos = type.GetProperties();
            Console.WriteLine("+++++ GET ALL PROPERTIES INFO +++++");
            foreach (PropertyInfo propertyInfo in propertyInfos) {
                Console.WriteLine($"Property: {propertyInfo}");
                Console.WriteLine($"    Value: {propertyInfo.GetValue(anyObject)}");
                Console.WriteLine($"    Type: {propertyInfo.PropertyType}");
            }
        }
        public static void GetDeclaredPropertiesNetCore(object anyObject) {
            Type type = anyObject.GetType();
            /* Dengan DeclaredProperties pada .Net Core kita bisa mendapatkan Declared Only Properties (Property yang hanya di tulis pada class, bukan di inherit)
             * Yang pada umumnya langkah ini harus menggunakan Enumeration Binding Flags.
             */
            IEnumerable<PropertyInfo> propertyInfos = type.GetTypeInfo().DeclaredProperties;
            Console.WriteLine("+++++ GET DECLARED PROPERTIES DOT NET CORE+++++");
            foreach (PropertyInfo propertyInfo in propertyInfos) {
                Console.WriteLine($"Property: {propertyInfo}");
                Console.WriteLine($"    Value: {propertyInfo.GetValue(anyObject)}");
                Console.WriteLine($"    Type: {propertyInfo.PropertyType}");
            }
        }
        public static void GetDeclaredPropertiesBindingFlags(object anyObject) {
            /*Contoh penggunaan BindingFlags saat kita menginginkan Declared Properties dengan access modifier bukan public.
             */
            Type type = anyObject.GetType();
            PropertyInfo[] propertyInfos = type.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.NonPublic | BindingFlags.Instance);
            Console.WriteLine("+++++ GET NON PUBLIC AND DECLARED PROPERTIES (BINDING FLAGS) +++++");
            foreach (PropertyInfo propertyInfo in propertyInfos) {
                Console.WriteLine($"Property: {propertyInfo}");
            }
        }
        public static void InvokingMethod(object anyObject, string methodName) {
            Type type = anyObject.GetType();
            MethodInfo methodInfo = type.GetMethod(methodName);
            Console.WriteLine("+++++ INVOKING METHOD +++++");
            var result = methodInfo.Invoke(anyObject, null); //Hasil return. null disiapkan untuk parameters bila ada
            Console.WriteLine($"The result is: {result}");
        }
        public static void InvokingMethod(object anyObject, string methodName, object[] parameters) {
            Type type = anyObject.GetType();
            MethodInfo methodInfo = type.GetMethod(methodName);
            Console.WriteLine("+++++ INVOKING METHOD WITH PARAMETERS +++++");
            var result = methodInfo.Invoke(anyObject, parameters);
            //parameters menerima object array karena bisa banyak jumlahnya dan tipe datanya tidak diketahui.
            Console.WriteLine($"The result is: {result}");
        }
        /// <summary>
        /// Fungsi di bawah ini adalah strategy untuk melihat seluruh lapisan base classs dari tipe object yang di inspect
        /// </summary>
        /// <param name="anyObject"></param>
        public static void FindAllBaseType(object anyObject) {
            Type type = anyObject.GetType();
            Console.WriteLine("+++++ LOOP BASE TYPE +++++");
            while (type != null) {
                Console.WriteLine($"Type: {type}");
                type = type.BaseType;
            }
        }
        /// <summary>
        /// Menginstantiate dengan menggunakan reflection.
        /// </summary>
        public static void ConstructObject<Template>(Type type, Template constructedObject) {
            Template newInstance = (Template)Activator.CreateInstance(type);
            newInstance = constructedObject;
            GetAllProperties(newInstance);
        }
    }
}
