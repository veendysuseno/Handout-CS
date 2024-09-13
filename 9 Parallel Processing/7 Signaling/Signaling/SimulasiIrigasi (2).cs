using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Signaling
{
    /*
     * Ini adalah contoh Silumasi Fill Water yang diupgrade sedikit.
     * Sehingga setelah 3 thread (john, alex, ben) mengambil air dan menyimpannya dipenampungan,
     * mereka bertiga akan melakukan irigasi ke pohon-pohon yang ada di perkebunan, tetapi penyiraman harus menunggu wadah penuh dulu dan
     * ada jedah waktu beberapa detik sebelum melakukan proses.
     * 
     * Oleh karena itu setiap thread harus menunggu sampai diberikan signal boleh melakukan irigasi.
     */

    public static class SimulasiIrigasi
    {
        private static int _volumeMaxPenampungan = 26;
        private volatile static int _volumePenampungan = 0;
        private static int _jumlahPohon = 13;
        //private static readonly object _locker = new object();
        private static ManualResetEvent _signal = new ManualResetEvent(false);

        public static void TugasIrigasi() {
            Thread john = new Thread(ProsesIrigasi) { Name = "John" };
            Thread alex = new Thread(ProsesIrigasi) { Name = "Alex" };
            Thread.CurrentThread.Name = "Ben";
            john.Start(1000);
            alex.Start(1000);
            IsiAirSatuLiter(1000);
            Thread.Sleep(5000);
            _signal.Set();
        }

        public static void ProsesIrigasi(object speed) {
            IsiAirSatuLiter((int)speed);
            _signal.WaitOne();
            IrigasiSatuPohon((int)speed);
        }

        public static void IsiAirSatuLiter(int speed) {
            while (_volumePenampungan < _volumeMaxPenampungan) {
                if (_volumePenampungan < _volumeMaxPenampungan) {
                    Console.WriteLine($"Air ditambahkan 1 liter oleh {Thread.CurrentThread.Name}, volume air saat ini {++_volumePenampungan}");
                    Thread.Sleep((int)speed);
                }
            }
        }

        public static void IrigasiSatuPohon(int speed) {
            while (_jumlahPohon > 0) {
                Console.WriteLine($"Pohon disiram oleh {Thread.CurrentThread.Name}, volume air saat ini {--_volumePenampungan}, pohon yang belum disiram {--_jumlahPohon}");
                Thread.Sleep(speed);
            }
        }

    }
}
