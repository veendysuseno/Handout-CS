using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectDestructor {
    public class Agenda {
        public string Name { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public Agenda(string name, DateTime from, DateTime to) {
            Console.WriteLine("Invoking a constructor");
            this.Name = name;
            this.From = from;
            this.To = to;
            Console.WriteLine($"{this.Name} baru saja dibuat.");
        }

        /*
         * Destructor/Finalizer: Destructor (ditulis dengan ~NamaClass()) adalah lawannya constructor, dimana tugasnya adalah menghapus/menghancurkan object dan mengembalikan heap memory atau reference memory,
         * agar bisa dipakai oleh system untuk penyimpanan object atau variable lainnya.
         * 
         * Pada pemrogramman C dan C++, Destructor sering sekali dipakai untuk membebaskan memory yang sudah tidak terpakai lagi, tapi...
         * Lain dengan C++, C# sama dengan Java, yaitu bahasa pemrograman dengan system Garbage Collection atau memiliki Garbage Collector yang biasa disebut juga dengan GC.
         * GC adalah program otomatis yang akan membersihkan seluruh memory yang tidak terpakai pada system, oleh karena itu Destructor akan di invoke oleh GC dengan otomatis
         * tanpa kita harus panggil secara manual (non-deterministic call).
         * 
         * GC akan memanggil Destructor tanpa bisa kita kendalikan, dan Destructor akan dipanggil saat main stack application sudah benar-benar habis atau tidak terpakai
         * sama sekali. Dalam kasus ini saat console program kita selesai. (Nanti akan kita experiment pada class Program)
         * 
         * Oleh karena itu, programmer dengan feature GC tidak pernah memperdulikan Destructor, walaupun kita masih bisa memonitornya, tetapi 
         * kita tidak perlu mengontrolnya secara manual.
         */
        ~Agenda(){
            Console.WriteLine($"Agenda use destructor on {this.Name}");
        }
    }
}
