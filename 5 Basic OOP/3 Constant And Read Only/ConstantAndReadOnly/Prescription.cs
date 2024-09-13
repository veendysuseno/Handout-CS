using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstantAndReadOnly {
    public class Prescription {

        //Penulisan Public Field
        public string NamaObat { get; set; }
        //Readonly adalah property yang bisa di CREATE tetapi tidak bisa di EDIT/UPDATE, contohnya bisa di lihat di Program.cs
        public readonly string Perusahaan;
        public readonly string BahanObat;
        public int JumlahKapsul { get; set; }
        public readonly DateTime ExpireDate;

        /*readonly harus berada dalam field, tidak boleh dalam property atau memiliki set method.*/

        public Prescription() {

        }

        public Prescription(string namaObat, string perusahaan, string bahanObat, int jumlahKapsul, DateTime expireDate) {
            this.NamaObat = namaObat;
            this.Perusahaan = perusahaan;
            this.BahanObat = bahanObat;
            this.JumlahKapsul = jumlahKapsul;
            this.ExpireDate = expireDate;
        }
    }
}
