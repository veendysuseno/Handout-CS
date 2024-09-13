using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectAndClass {
    /* OOP atau object oriented programming adalah pemrogramman berbasis object, dimana segala sesuatu data dan informasi disimpan dan diproses oleh setiap object.
     * 
     * Setiap object memiliki:
     * Class: Class adalah kategori atau penggolongan object berdasarkan clasifikasinya di dalam table data.
     * Field: Adalah seluruh data dan informasi yang dimiliki object tersebut. Atau bisa dikatakan seluruh variable yang ekslusif milik object tersebut.
     * Method: Adalah seluruh function yang dimiliki dan digunakan oleh sebuah object.
     */

    public class Karyawan {
        /* Class karyawan merupakan contoh class yang menggunakan penulisan Fields sebagai attributenya.
         * Fields adalah attribute yang bersifat private, dan satu-satunya cara mengaksesnya adalah dengan Get Set Method yang bersifat public.
         * (Very old school)
         */

        //Private Fields
        #region Fields

        private string _nama;
        private DateTime _tanggalLahir;
        private string _nomorKTP;
        private string _jenisKelamin;
        private int _jumlahAnak;
        private string _namaAyah;
        private string _namaIbu;
        private List<Mobil> _koleksiMobil;
        private List<MobilePhone> _koleksiPhone;
        private Company _perusahaan;
        private string _department;
        private decimal _gaji;

        #endregion

        //Field Getter Setter Method
        #region Get & Set Method

        public string GetNama() {
            return this._nama;
        }
        public void SetNama(string argNama) {
            this._nama = argNama;
        }

        public DateTime GetTanggalLahir() {
            return this._tanggalLahir;
        }
        public void SetTanggalLahir(DateTime argTanggalLahir) {
            this._tanggalLahir = argTanggalLahir;
        }

        public string GetNomorKTP() {
            return this._nomorKTP;
        }
        public void SetNomorKTP(string argNomorKTP) {
            this._nomorKTP = argNomorKTP;
        }

        public string GetJenisKelamin() {
            return this._jenisKelamin;
        }
        public void SetJenisKelamin(string argJenisKelamin) {
            this._jenisKelamin = argJenisKelamin;
        }

        public int GetJumlahAnak() {
            return this._jumlahAnak;
        }
        public void SetJumlahAnak(int argJumlahAnak) {
            this._jumlahAnak = argJumlahAnak;
        }

        public string GetNamaAyah() {
            return this._namaAyah;
        }
        public void SetNamaAyah(string argNamaAyah) {
            this._namaAyah = argNamaAyah;
        }

        public string GetNamaIbu() {
            return this._namaIbu;
        }
        public void SetNamaIbu(string argNamaIbu) {
            this._namaIbu = argNamaIbu;
        }

        public List<Mobil> GetKoleksiMobil() {
            return this._koleksiMobil;
        }
        public void SetKoleksiMobil(List<Mobil> argKoleksiMobil) {
            this._koleksiMobil = argKoleksiMobil;
        }

        public List<MobilePhone> GetKoleksiPhone() {
            return this._koleksiPhone;
        }
        public void SetKoleksiPhone(List<MobilePhone> argKoleksiPhone) {
            this._koleksiPhone = argKoleksiPhone;
        }

        public Company GetPerusahaan() {
            return this._perusahaan;
        }
        public void SetPerusahaan(Company argPerusahaan) {
            this._perusahaan = argPerusahaan;
        }

        public string GetDepartment() {
            return this._department;
        }
        public void SetDepartment(string argDepartment) {
            this._department = argDepartment;
        }

        public decimal GetGaji() {
            return this._gaji;
        }
        public void SetGaji(decimal argGaji) {
            this._gaji = argGaji;
        }

        #endregion

        //Method-method milik karyawan
        #region Method

        public void PrintInformation() {
            Console.WriteLine("Nama saya adalah {0}, nomor ktp {1}, jenis kelamin {2}, jumlah anak {3}", this._nama, this._nomorKTP, this._jenisKelamin, this._jumlahAnak);
        }

        public int HitungUmur() {
            int age = DateTime.Today.Year - this._tanggalLahir.Year;
            return age;
        }

        public void PrintSemuaMobil() {
            foreach (Mobil mobil in this._koleksiMobil) {
                Console.WriteLine("Mobil yang dimiliki {0}: {1} {2}", this._nama, mobil.Brand, mobil.Type);
            }
        }

        public void PrintSemuaPhone() {
            foreach (MobilePhone phone in this._koleksiPhone) {
                Console.WriteLine("Phone yang dimiliki {0}: {1} {2}", this._nama, phone.Brand, phone.Type);
            }
        }

        #endregion

    }

    public class University {

        public string Nama { get; set; }
        public DateTime BerdiriSejak { get; set; }
        public Building Building { get; set; }

        public University(string nama, DateTime berdiriSejak, Building building) {
            this.Nama = nama;
            this.BerdiriSejak = berdiriSejak;
            this.Building = building;
        }
    }

    public class Company {
        public string Name { get; set; }
        public string Owner { get; set; }
        public Building Building { get; set; }
    }

    class Program {
        static void Main(string[] args) {
            experimentKaryawan();
            pendataanMahasiswa();

            //Anonymous Object
            var myAnonymousType = new {
                FirstName = "Amelia",
                LastName = "Maxillian",
                IsMarried = true,
                DateOfBirth = new DateTime(1988, 11, 27),
                NumberOfChild = 5
            };

            Console.WriteLine(myAnonymousType.GetType());
            Console.WriteLine(myAnonymousType.FirstName);
        }

        private static void experimentKaryawan() {
            //Membuat sebuah object berkelas Karyawan, dimana nama object itu adalah joko.
            Karyawan joko = new Karyawan();

            //Set Setiap field attribute dengan menggunakan set method.
            joko.SetNama("Joko Anwar");
            DateTime tanggalLahirJoko = new DateTime(1988, 11, 27);
            joko.SetTanggalLahir(tanggalLahirJoko);
            joko.SetNomorKTP("3109928108900002");
            joko.SetJenisKelamin("Laki-laki");
            joko.SetJumlahAnak(2);
            joko.SetNamaAyah("Bagus Anwar");
            joko.SetNamaIbu("Siti Adina");

            //membuat object lain.
            Karyawan anisa = new Karyawan();
            anisa.SetNama("Anisa Hayati");
            DateTime tanggalLahirAnisa = new DateTime(1989, 10, 12);
            anisa.SetTanggalLahir(tanggalLahirAnisa);
            anisa.SetNomorKTP("2108728108900002");
            anisa.SetJenisKelamin("Perempuan");
            anisa.SetJumlahAnak(1);
            anisa.SetNamaAyah("Sugi Sulaiman");
            anisa.SetNamaIbu("Maria Hayati");

            //Mendapatkan satu field attribute dengan menggunakan get method.
            Console.WriteLine(joko.GetNama());
            Console.WriteLine(anisa.GetJenisKelamin());

            //Contoh-contoh menggunakan method yang dimiliki sebuah object.
            joko.PrintInformation();
            anisa.PrintInformation();
            Console.WriteLine("Umur anisa {0}", anisa.HitungUmur());

            //Membuat mobil satu-persatu.
            Mobil brioJoko = new Mobil();
            brioJoko.Brand = "Honda";
            brioJoko.Type = "Brio";
            brioJoko.TahunProduksi = 2014;
            brioJoko.MaxSpeed = 180;
            brioJoko.Warna = "hitam";
            Console.WriteLine(brioJoko.Brand);

            Mobil avanzaJoko = new Mobil();
            avanzaJoko.Brand = "Toyota";
            avanzaJoko.Type = "Avanza";
            avanzaJoko.TahunProduksi = 2018;
            avanzaJoko.MaxSpeed = 180;
            avanzaJoko.Warna = "silver";

            //Menggabungkan 2 mobil ke dalam 1 generic list.
            List<Mobil> koleksiMobil = new List<Mobil>();
            koleksiMobil.Add(brioJoko);
            koleksiMobil.Add(avanzaJoko);

            //Meng-assign koleksi mobil ke dalam property joko.
            joko.SetKoleksiMobil(koleksiMobil);
            joko.PrintSemuaMobil(); // meng-invoke function untuk print semua mobil.

            //Dengan menggunakan index initializer
            List<MobilePhone> koleksiPhone = new List<MobilePhone> {
                new MobilePhone("Iphone 6s", "Apple", "Gray", 5.5, 2 ),
                new MobilePhone("Galaxy S6", "Samsung", "Blue", 5.5, 4)
            };
            MobilePhone anisaSamsung = new MobilePhone("J5 Prime", "Samsung", "Gold", 5.5, 4);
            koleksiPhone.Add(anisaSamsung);
            anisa.SetKoleksiPhone(koleksiPhone);

            anisa.PrintSemuaPhone();

            anisa.SetDepartment("Information Technology");
            anisa.SetGaji(5500000);
            joko.SetDepartment("Information Technology");
            joko.SetGaji(6700000);

            //Dengan menggunakan index initializer
            Company indocyber = new Company() {
                Name = "Indocyber Global Teknologi",
                Owner = "Bharat Ongso",
                Building = new Building("Daan Mogot Kavling 119", "Jakarta", 20)
            };

            anisa.SetPerusahaan(indocyber);
            joko.SetPerusahaan(indocyber);
        }

        private static void pendataanMahasiswa() {
            Building gedungUI = new Building("Jalan Margonda Raya", "Jakarta", 20);
            University universitasIndonesia = new University("Universitas Indonesia", new DateTime(1849, 11, 7), gedungUI);
            List<Mahasiswa> paraMahasiswa = new List<Mahasiswa>() {
                new Mahasiswa("Sandra Maria", new DateTime(1996, 12, 12), "312450045898790001", "Perempuan"){
                    JumlahAnak = 0,
                    NamaAyah = "Suhendra Sonja",
                    NamaIbu = "Shinta Maria",
                    Phone = new MobilePhone("A2", "Samsung", "Silver", 5.5, 4),
                    Universitas = universitasIndonesia,
                    Fakultas = "Kedokteran"
                },
                new Mahasiswa("Andre Tanuwijaya", new DateTime(1995, 10, 5), "314451145898790003", "Laki-laki", 0, "Hartono Tanuwijaya", "Kristina Andasari", universitasIndonesia, "Arsitektur"){
                    Phone = new MobilePhone("6s", "Iphone", "White", 5.5, 4)
                }
            };

            foreach (Mahasiswa siswa in paraMahasiswa) {
                siswa.PrintSetiapSiswa();
            }
        }
    }
}
