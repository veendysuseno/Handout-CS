using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectAndClass {
    public class Mahasiswa {
        //Auto Property: feature C# version 3. Membuat property dengan lebih singkat dan lebih mudah. Sifatnya seperti gabungan dari field dan getter setter method.
        public string Nama { get; set; }
        public DateTime TanggalLahir { get; set; }
        public string NomorKTP { get; set; }
        public string JenisKelamin { get; set; }
        public int JumlahAnak { get; set; }
        public string NamaAyah { get; set; }
        public string NamaIbu { get; set; }
        public Mobil Mobil { get; set; }
        public MobilePhone Phone { get; set; }
        public University Universitas { get; set; }
        public string Fakultas { get; set; }


        //Overloading constructor
        public Mahasiswa() {
        }

        public Mahasiswa(string nama, DateTime tanggalLahir, string nomorKTP, string jenisKelamin) {
            this.Nama = nama;
            this.TanggalLahir = tanggalLahir;
            this.NomorKTP = nomorKTP;
            this.JenisKelamin = jenisKelamin;
        }

        public Mahasiswa(string nama, DateTime tanggalLahir, string nomorKTP, string jenisKelamin, int jumlahAnak, string namaAyah, string namaIbu, University universitas, string fakultas) {
            this.Nama = nama;
            this.TanggalLahir = tanggalLahir;
            this.NomorKTP = nomorKTP;
            this.JenisKelamin = jenisKelamin;
            this.JumlahAnak = jumlahAnak;
            this.NamaAyah = namaAyah;
            this.NamaIbu = namaIbu;
            this.Universitas = universitas;
            this.Fakultas = fakultas;
        }

        public void PrintSetiapSiswa() {
            Console.WriteLine("Namanya: {0}, Nomor KTPnya: {1}, Fakultasnya {2}, HPnya: {3}, Universitasnya: {4}", this.Nama, this.NomorKTP, this.Fakultas, this.Phone.Brand + " " + this.Phone.Type, this.Universitas.Nama);
        }
    }
}
