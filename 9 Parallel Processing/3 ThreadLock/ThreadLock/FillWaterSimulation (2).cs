using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ThreadLock
{
    /*
     * Ini merupakan static class yang mensimulasikan sekelompok orang / individu yang ingin mengisi sebuah wadah air dengan volume maximum 22 liter.
     * Setiap orang / individu hanya dilengkapi dengan gelas yang mampu menampung air sebanyak 1 liter.
     * Dengan gelas masing-masing, setiap orang / individu harus bulak balik mengambil air dari sumber air dengan gelas tersebut, dan menuangnya ke wadah 22 liter tersebut.
     * Fungsi-fungsi static milik class ini harus selesai ketika wadah air sudah penuh 22 liter.
     */
    public static class FillWaterSimulation
    {

        /*
         * Bisa kalian lihat, bahwa _volumeMax dan _volumeAir adalah private field dari class ini.
         * Sama seperti global variable pada contoh sebelumnya di program, field juga di share sebagai memory bersama.
         */
        private static int _volumeMax = 22; //pre-defined maximum volume wadah

        /*
         * keyword volatile digunakan pada _volumeAir dikarenakan field ini akan di modify lebih dari satu thread secara bersamaan.
         * Volatile digunakan untuk mencegah terjadinya double update/set secara bersamaan sekaligus. (tergantung probability terjadinya).
         * Karena field _volumenAir kita bersifat non-idempotent.
         */
        private static volatile int _volumeAir = 0; //startnya wadah dari kosong 0 (tidak ada air sama sekali)

        //satu-satunya object kunci yang dimiliki thread yang berhak masuk ke dalam lock code-block. Penjelasan lebih lengkap ada di fungsi LockedIsiAirSatuLiter()
        public static readonly object _locker = new object();

        /// <summary>
        /// Fungsi ini hanya menjalankan single main thread saja.
        /// 
        /// Pada kasus ini, Ben bekerja seorang diri.
        /// Ben memerlukan waktu 1 detik untuk mengambil dan menuang air ke wadah.
        /// Ben memerlukan +- 22 detik untuk mengisi satu wadah.
        /// </summary>
        public static void PenuhkanWadahSendirian() {
            Thread.CurrentThread.Name = "Ben";
            IsiAirSatuLiter(1000);
        }

        /// <summary>
        /// Fungsi ini mecoba menjalankan 3 thread sekaligus dengan kecepatan yang sama untuk menyelesaikan 1 goal bersama.
        /// 
        /// Pada kasus ini, Ben dibantu oleh John dan Alex yang memiliki kecepatan mengisi air yang sama dengan Ben untuk mengisi 1 wadah yang sama.
        /// Wadah yang sama dishare karena, _volumeAir di wadah berada pada global heap.
        /// 
        /// Pada kasus ini bisa dilihat peningkatan performance mengerjakan 1 goals ber 3 secara parallel.
        /// Proses parallel untuk menyelesaikan 1 goals terkait disebut juga dengan Concurrency.
        /// </summary>
        public static void PenuhkanWadahBersama() {
            Thread john = new Thread(IsiAirSatuLiter);
            john.Name = "John";
            Thread alex = new Thread(IsiAirSatuLiter);
            alex.Name = "Alex";
            Thread.CurrentThread.Name = "Ben";
            john.Start(1000);
            alex.Start(1000);
            IsiAirSatuLiter(1000);
        }

        /// <summary>
        /// Concurrency tidak berarti setiap thread memiliki kecepatan yang sama, tetapi tetap bisa saling membantu.
        /// Contohnya seperti simulasi dibawah ini.
        /// 
        /// Goal mengisi air saat ini dikerjakan oleh John, Paman Richard, dan Nenek Susie
        /// Paman Richard sudah lebih tua dan 3 kali lebih lambat dari John, sedangkan Nenek Susie lebih lambat 6 kali dari John.
        /// 
        /// Wadah adalah milik bersama, tetapi kecepatan adalah milik masing-masing orang, oleh karena itu kecepatan bersifat local di dalam setiap Thread.
        /// </summary>
        public static void SimulasiPerbedaanKecepatan() {
            Thread john = new Thread(IsiAirSatuLiter);
            john.Name = "John";
            Thread uncleRichard = new Thread(IsiAirSatuLiter);
            uncleRichard.Name = "Uncle Richard";
            Thread.CurrentThread.Name = "Grandma Susie";
            john.Start(1000);
            uncleRichard.Start(3000);
            IsiAirSatuLiter(6000);
        }

        /// <summary>
        /// Kalau kalian perhatikan, apakah methods PenuhkanWadaBersama() dan SimulasiPerbedaanKecepatan() pernah mengisi
        /// wadah sampai lebih dari 22 liter dan tumpah?
        /// 
        /// Mungkin tidak setiap kali kalian eksekusi, tetapi terkadang suka terjadi. Kalau penasaran silahkan coba berkali-kali.
        /// Terkadang wadah terisi 23 atau lebih.
        /// 
        /// Di bawah ini contoh goal mengisi wadah dikerjakan oleh 5 robot berkecepatan sangat tinggi, dimana hanya butuh 100 ms untuk mengambil air
        /// 1 gelas dan menuangnya ke wadah.
        /// Dengan banyak thread yang cepat seperti dibawah ini, kemungkinan wadah diisi kepenuhan lebih tinggi dan sering terjadi overflow atau tumpah.
        /// 
        /// Kenapa hal tersebut bisa terjadi? Padahal method IsiAirSatuLiter sudah diberikan kondisi while()...
        /// Itu dikarenakan ada 2 atau lebih individu yang masuk ke dalam while code block bersamaan dan tetap menuang air dikarenakan mereka
        /// bersama-sama melihat kalau wadah belum penuh tanpa memperdulikan teman disebelahnya sedang menuang atau tidak.
        /// 
        /// Iya, setiap thread tentunya tidak akan aware dengan aksi thread lain.
        /// Bisa jadi ada 2 atau lebih thread yang menambahkan wadah bersamaan.
        /// </summary>
        public static void SimulasiOverflow() {
            Thread robot1 = new Thread(IsiAirSatuLiter);
            robot1.Name = "Robot 1";
            Thread robot2 = new Thread(IsiAirSatuLiter);
            robot2.Name = "Robot 2";
            Thread robot3 = new Thread(IsiAirSatuLiter);
            robot3.Name = "Robot 3";
            Thread robot4 = new Thread(IsiAirSatuLiter);
            robot4.Name = "Robot 4";
            Thread robot5 = new Thread(IsiAirSatuLiter);
            robot5.Name = "Robot 5";
            robot1.Start(100);
            robot2.Start(100);
            robot3.Start(100);
            robot4.Start(100);
            robot5.Start(100);
        }

        public static void IsiAirSatuLiter(object speed) {
            while (_volumeAir < _volumeMax) {
                Console.WriteLine($"Air ditambahkan 1 liter oleh {Thread.CurrentThread.Name}, volume air saat ini {++_volumeAir}");
                Thread.Sleep((int)speed);
            }
        }

        #region Lock Statement

        /*
         * Untuk mencegah terjadinya overflow air pada wadah, kita bisa menggunakan lock statement.
         * 
         * Lock statement adalah teknologi pada C# yang gunanya adalah untuk membatasi kalau hanya 1 thread yang boleh memasuk code-block ini
         * dalam satu waktu. Sehingga mustahil untuk 2 atau lebih Thread membaca while statement dalam method IsiAirSatuLiter bersamaan.
         * 
         * Bisa diibaratkan seperti ini:
         * Saat ini wadah ditempatkan di dalam satu bilik kecil (seperti WC), dan selayaknya bilik WC, hanya 1 orang yang boleh masuk bilik per satu waktu.
         * Untuk memastikan tidak ada thread lain yang bisa masuk bilik WC, maka WC tersebut harus bisa dikunci.
         * 
         * Bilik WC dalam hal ini adalah lock statement dan code-blocknya.
         * Sedangkan kunci bilik WC adalah _locker object yang saat ini adalah field pada Class ini.
         * locker harus dibuat dengan reference type object dengan tipe data apa saja (cari yang paling sederhana yaitu object data type).
         * Bagaimana cara kerjanya? kunci harus satu dan bersifat unik, reference number dari object dimanfaatkan sebagai kuncinya.
         * 
         * Tapi, kalian harus berhati-hati dalam memberi penempatan lock statement.
         * Di bawah ini saya berikan 2 contoh, yaitu yang salah dan yang benar.
         * 
         */

        /// <summary>
        /// Fungsi di bawah ini memanggil fungsi FailedLockedIsiAirSatuLiter di setiap threadnya.
        /// Dimana locked statement diletakan di dalam fungsi FailedLockedIsiAirSatuLiter
        /// </summary>
        public static void FailedSimulasiLocked() {
            Thread robot1 = new Thread(FailedLockedIsiAirSatuLiter);
            robot1.Name = "Robot 1";
            Thread robot2 = new Thread(FailedLockedIsiAirSatuLiter);
            robot2.Name = "Robot 2";
            Thread robot3 = new Thread(FailedLockedIsiAirSatuLiter);
            robot3.Name = "Robot 3";
            Thread robot4 = new Thread(FailedLockedIsiAirSatuLiter);
            robot4.Name = "Robot 4";
            Thread robot5 = new Thread(FailedLockedIsiAirSatuLiter);
            robot5.Name = "Robot 5";
            robot1.Start(100);
            robot2.Start(100);
            robot3.Start(100);
            robot4.Start(100);
            robot5.Start(100);
        }

        /// <summary>
        /// Penulisan lock statement pada fungsi ini memang sudah benar, tetapi penempatannya yang salah.
        /// Itu dikarenakan lock di taruh tepat diluar while.
        /// 
        /// Ini menyebabkan hanya 1 thread atau dalam perumpamaan ini hanya 1 individu yang bisa masuk ke dalam lock statement.
        /// Dia akan berlama-lama dan melanjutkan loopnya sendirian yang mengakibatkan thread yang lain tidak kebagian sama sekali.
        /// 
        /// (hanya thread yang tercepat bisa masuk dan terjebak di dalam loop)
        /// </summary>
        /// <param name="speed"></param>
        public static void FailedLockedIsiAirSatuLiter(object speed) {
            lock (_locker) {
                while (_volumeAir < _volumeMax) {
                    Console.WriteLine($"Air ditambahkan 1 liter oleh {Thread.CurrentThread.Name}, volume air saat ini {++_volumeAir}");
                    Thread.Sleep((int)speed);
                }
            }
        }

        /// <summary>
        /// Ini adalah fungsi yang mirip, tetapi function yang di dalam threadnya yang berbeda,
        /// mari kita lihat.
        /// </summary>
        public static void SimulasiLocked() {
            Thread robot1 = new Thread(LockedIsiAirSatuLiter);
            robot1.Name = "Robot 1";
            Thread robot2 = new Thread(LockedIsiAirSatuLiter);
            robot2.Name = "Robot 2";
            Thread robot3 = new Thread(LockedIsiAirSatuLiter);
            robot3.Name = "Robot 3";
            Thread robot4 = new Thread(LockedIsiAirSatuLiter);
            robot4.Name = "Robot 4";
            Thread robot5 = new Thread(LockedIsiAirSatuLiter);
            robot5.Name = "Robot 5";
            robot1.Start(100);
            robot2.Start(100);
            robot3.Start(100);
            robot4.Start(100);
            robot5.Start(100);
        }

        public static void LockedIsiAirSatuLiter(object speed) {
            while (_volumeAir < _volumeMax) {
                lock (_locker) {
                    if (_volumeAir < _volumeMax) {
                        Console.WriteLine($"Air ditambahkan 1 liter oleh {Thread.CurrentThread.Name}, volume air saat ini {++_volumeAir}");
                        Thread.Sleep((int)speed);
                    }
                }
            }
        }

        #endregion
    }
}
