using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeStructs {

    /* Struct: adalah saudara dari Class, banyak hal dari struct yang sifatnya sama seperti class, tetapi dengan beberapa perbedaan.
     * Berikut ini beberapa sifat struct dan hal yang membuatnya berbeda dengan class:
     * 1. Struct merupakan VALUE type, lain dengan Class yang sifatnya Reference Type, sehingga membuat struct sama seperti variable dengan tipe data primitif.
     * 2. Struct sama seperti sebuah Class, bisa memiliki property, field, constructor, constants, dan lain-lain.
     * 3. Struct hanya bisa inherit dari interface, struct tidak bisa inherit dari class, abstract class ataupun struct lainnya.
     * 4. Karena struct tidak bisa diinherit oleh struct lagi, struct tidak bisa memiliki member dengan tipe protected. (gak ada gunanya protected).
     * 5. Struct biasanya dipakai untuk kebutuhan ringan dimana hanya terdiri dari beberapa property atau method yang ringan. Class jauh lebih umum digunakan.
     * 6. Di dalam struct, private fields gak bisa di inisialisasi/assign terkecuali di deklarasi const atau static.
     * 7. Struct tidak bisa deklarasi default constructor atau constructor kosong.
     * 8. Sama seperti variable, saat struct di assign ke variable baru, struct akan menciptakan copy baru, sehingga perubahan pada variable baru tidak mengakibatkan perubahan pada yang lama.
     * 9. Tidak seperti Class, object dari struct bisa diinstantiate tanpa syntax "new".
     */

    public struct StructPerson {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        //4. Karena struct tidak bisa diinherit oleh struct lagi, struct tidak bisa memiliki member dengan tipe protected. (gak ada gunanya protected).
        //protected int TestProperty { get; set; }

        //6. Di dalam struct, private fields gak bisa di inisialisasi/assign terkecuali di deklarasi const atau static.
        //private string PrivateField = "Inisialisasi";

        private const string PrivateField = "Inisialisasi";

        //7. Struct tidak bisa deklarasi default constructor atau constructor kosong.
        //public StructPerson(){}

        public StructPerson(string firstName, string lastName, int age) : this() {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }
    }
}
