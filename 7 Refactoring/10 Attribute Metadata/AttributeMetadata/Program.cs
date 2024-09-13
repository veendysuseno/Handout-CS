#define DEFAULT_EXECUTION

using AttributeMetadata.ClassLibrary;
using AttributeMetadata.CustomAttribute;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeMetadata {

    class Program {

        /*
         * Attribute adalah cara C# mengirim metadata (tambahan informasi) ke dalam class, function, property, parameter, assembly dan lain sebagainya.
         * Attribute di tulis dengan syntax unik di dalam [] (square bracket).
         * 
         * Bagi kalian yang sudah pernah mempelajari java sebelumnya, C# attribute adalah versi annotation @ pada Java.
         * Sama seperti pada Java, attribute terdiri dari 2 macam, yang built-in atau predefined yang sudah diberikan dari C# atau yang kita buat sendiri.
         */
        static void Main(string[] args) {

            //Semua Obsolete invocation akan mendapatkan warning.
            ObsoleteSample();
            ObsoleteSample("test");
            //ErrorObsolete();

            Executed();
            GettingSkipped(); //akan di skip oleh compiler dan run time.

            FirstStack();

            var john = DisplayingDebuggerDetail();


            /*
             * Berikut ini adalah contoh-contoh meng-ekstrasi metadata informasi dari dalam attribute.
             * Tetapi pada umumnya ini sudah dilakukan di dalam library atau framework.
             */
            var iEmployeeAttribute = (RestrictionAttribute)(typeof(IEmployee).GetCustomAttributes(typeof(RestrictionAttribute), false).FirstOrDefault());
            Console.WriteLine($"Restriction Attribute di dalam IEmployee: SystemName({iEmployeeAttribute.SystemName}), Version({iEmployeeAttribute.Version})");

            var staffAttribute = (RestrictionAttribute)(typeof(Staff).GetCustomAttributes(typeof(RestrictionAttribute), false).FirstOrDefault());
            Console.WriteLine($"Restriction Attribute di dalam Staff: SystemName({staffAttribute.SystemName}), Version({staffAttribute.Version})");

            var staffNameAttribute = (ValidationAttribute)(typeof(Staff).GetProperty("Name").GetCustomAttributes(typeof(ValidationAttribute), false).FirstOrDefault());
            Console.WriteLine($"Validation Attribute di dalam Staff.Name: Nullable({staffNameAttribute.Nullable}), CharLength({staffNameAttribute.CharLength})");

            var managerDepartmentAttribute = (ValidationAttribute)(typeof(Manager).GetProperty("Department").GetCustomAttributes(typeof(ValidationAttribute), false).FirstOrDefault());
            Console.WriteLine($"Validation Attribute di dalam Manager.Department: Nullable({managerDepartmentAttribute.Nullable}), CharLength({managerDepartmentAttribute.CharLength})");

            var managerNumberAttribute = (NumberAttribute)(typeof(Manager).GetProperty("Salary").GetCustomAttributes(typeof(NumberAttribute), false).FirstOrDefault());
            Console.WriteLine($"Validation Attribute di dalam Manager.Salary: Minimum({managerNumberAttribute.Minimum}), Maximum({managerNumberAttribute.Maximum})");

            /*
             * Akan ada lebih banyak lagi pre-defined attribute, khususnya bagi yang mempelajari C# untuk penggunaan .NET framework,
             * dan juga akan di contohkan pada chapter-chapter lanjutan.
             */
        }

        /*
         * Obsolete adalah synonym dari Deprecated (Di sebagian basa pemrograman juga di sebut deprecated) yang artinya usang.
         *  atau sudah tidak best practice untuk dipakai, atau tidak disarankan untuk dipakai lagi. (Kalau manusia mungkin bisa dikatakan sudah waktunya pensiun)
         *  
         *  Attribute [Obsolete] adalah pre-defined attribute yang digunakan untuk menandakan suatu function, class, property atau lainnya (Di contoh ini hanya pakai function saja)
         *  bahwa hal-hal tersebut sudah tidak boleh dipakai lagi. Ini adalah bentuk komunikasi yang baik bagi kalian para developer bila ingin berkomunikasi ke developer lain,
         *  kalau kalian tidak menyarankan developer lain untuk tetap memakai feature tersebut.
         *  
         *  Kenapa tidak langsung dihapus atau di komen saja? Kalau dihapus atau di komen, maka seluruh aplikasi terancam compile error karena feature tidak lagi ditemukan.
         *  Obsolete bisa dibilang adalah komunikasi yang mengatakan "Yang sudah terlanjur pakai biarkan saja, nanti kalau ada waktu bisa di re-factoring, tetapi untuk development baru jangan pakai ini lagi."
         */
        #region Obsolete

        //Ini adalah contoh attribute obsolete pada method
        [Obsolete]
        public static void ObsoleteSample() {
            Console.WriteLine("This function is obsolete");
        }

        //Obsolete bisa menerima parameter string yang gunakanya untuk memberi catatan bagi siapa pun yang masih memaksakan diri menggunakan ini.
        [Obsolete("Fungsi ini masih berfungsi, tetapi sudah deprecated, lebih baik pakai fungsi lain sebagai alternatif.")]
        public static void ObsoleteSample(string parameter) {
            Console.WriteLine($"This function is obsolete, parameters {parameter}");
        }

        /*Obsolete juga memiliki feature error, yang akan membuat error seluruh penggunanya.
            Obsolete error akan menerima konsekuensi seperti kalian menghapus atau meng-komen fungsi ini, tetapi
            dia bisa meninggalkan note dan implementasi fungsi juga masih bisa dilihat dan di check karena code masih ada.
         */
        [Obsolete("TIDAK BOLEH PAKAI FUNGSI INI!", error:true)]
        public static void ErrorObsolete() {
            Console.WriteLine("There is no way you can run this function");
        }

        #endregion

        /*
         * Conditional attribute digunakan untuk menunjukan code mana yang akan di compile dan di eksekusi oleh run-time.
         * 
         * String dari setiap parameter conditional di declare dalam #define.
         * #define harus berada di paling atas, bahkan sebelum using name space di tulis.
         * 
         * Sebagai alternative string define bisa di tulis di dalam Properties project di dalam
         * Project > Properties > Build > Conditional compilation symbol.
         */
        #region Conditional

        [Conditional("DEFAULT_EXECUTION")]
        public static void Executed() {
            Console.WriteLine("Executed by condition");
        }

        //Fungsi ini akan di skip, karena tidak ada di dalam #define dan bukan default juga.
        [Conditional("SKIP")]
        public static void GettingSkipped() {
            Console.WriteLine("Skip, Compiler won't check this");
        }

        #endregion

        /*
         * Berikut ini adalah contoh beberapa attribute yang memanipulasi proses debugging.
         */
        #region Debugger

        /*
         * Pada contoh ini, SkippedByDebugger di invoke oleh FirstStack dan SkippedByDebugger memanggil LastStack, sehingga
         * ketiga fungsi ini akan bertumpuk menjadi satu di dalam call-stack pada saat debugging.
         * 
         * Perhatikan kalau fungsi SkippedByDebugger tidak terdeteksi di dalam visual studio call-stack window pada saat debugging.
         * Seluruh function yang diberi attribute [DebuggerStepThrough] akan ditulis sebagai "External Code" di daslam call-stack window.
         */
        public static void FirstStack() {
            SkippedByDebugger();
        }

        /*
         * DebuggerStepThrough adalah attribute yang digunakan pada function agar function tersebut di jalankan,
         * tetapi tidak di lewat oleh di debugger.
         */
        [DebuggerStepThrough]
        public static void SkippedByDebugger() {
            Console.WriteLine("This won't be detected by debugger");
            Console.WriteLine("However it will be executed in the result.");
            LastStack();
        }

        public static void LastStack() {
            Console.WriteLine("The last call stack");
        }

        public static Person DisplayingDebuggerDetail() {
            /*
             * Perhatikan saat kalian debug someone dengan hover atau watch windows.
             * [DebuggerDisplay] attribute akan mengganti valuenya ke dalam satu format yang lebih read-able
             */
            var someone = new Person("John Doe", "Male", "London");
            return someone;
        }

        #endregion
    }
}
