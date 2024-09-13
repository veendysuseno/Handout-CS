using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstantAndReadOnly {
    class Program {

        public const int kakiMejaMakan = 4;

        static void Main(string[] args) {

            /*================= CONSTANT =================*/

            const double PI = 3.14; //Sifat Constant, artinya sebuah variable itu tidak akan bisa dirubah / immutable.
            double contohDouble = 5.6;
            Console.WriteLine("PI dari lingkaran: {0}", PI);
            Console.WriteLine("PI dari lingkaran: {0}", contohDouble);
            contohDouble = 99.5;
            //PI = 107.89; //akan error saat di check oleh compiler
            Console.WriteLine("PI dari lingkaran: {0}", contohDouble);

            //const int konstanInt; Constant harus langsung diberi value saat deklarasi.
            Console.WriteLine("jumlah kaki meja makan model a: {0}", kakiMejaMakan);

            /*================= READ ONLY =================*/

            Prescription panadol = new Prescription("panadol", "Glaxo Smith Kline", "Paracetamol", 8, new DateTime(2020, 11, 23));
            Console.WriteLine("Nama Obat: {0}, Perusahaan: {1}, Bahan baku: {2}, Jumlah Kapsul: {3}, Tanggal Expire: {4}", 
                panadol.NamaObat, panadol.Perusahaan, panadol.BahanObat, panadol.JumlahKapsul, panadol.ExpireDate.ToShortDateString());
            panadol.NamaObat = "panadol extra";
            //panadol.Perusahaan = "Cendo"; akan compile error kalau dilakukan
            panadol.JumlahKapsul = 6;
            Console.WriteLine("Nama Obat: {0}, Perusahaan: {1}, Bahan baku: {2}, Jumlah Kapsul: {3}, Tanggal Expire: {4}",
                panadol.NamaObat, panadol.Perusahaan, panadol.BahanObat, panadol.JumlahKapsul, panadol.ExpireDate.ToShortDateString());
        }
    }
}
