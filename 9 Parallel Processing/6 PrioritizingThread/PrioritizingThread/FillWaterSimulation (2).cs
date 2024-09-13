using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace PrioritizingThread
{
    public static class FillWaterSimulation
    {
        private static volatile bool _kehabisanWaktu = false;
        private static int _volumeMax = 22;

        //Attribute thread static membuat field ini bersifat local atau berbeda-beda untuk setiap thread.
        [ThreadStatic] private static long _volumeAir = 0;
        public static readonly object _locker = new object();

        /// <summary>
        /// Fungsi dibawah ini adalah contoh fungsi simulasi pengisian air yang ada pada topik sebelumnya.
        /// Tapi perhatikan kalau hasilnya berbeda dengan simulasi pada topik sebelumnya.
        /// 
        /// Di sini thread dari John, Alex dan Ben tidak mengisi wadah bersama, malah memiliki wadah masing-masing.
        /// Itu dikarenakan attribute [ThreadStatic] pada _volumeAir.
        /// Attribute thread static membuat field di atas bersifat local atau berbeda-beda untuk setiap thread.
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
        /// Ini adalah contoh dalam keadaan Locked.
        /// </summary>
        public static void LockedPenuhkanWadahBersama() {
            Thread john = new Thread(LockedIsiAirSatuLiter);
            john.Name = "John";
            Thread alex = new Thread(LockedIsiAirSatuLiter);
            alex.Name = "Alex";
            Thread.CurrentThread.Name = "Ben";
            john.Start(1000);
            alex.Start(1000);
            LockedIsiAirSatuLiter(1000);
        }

        /*
         * Masing-masing setiap Thread memiliki tingkat prioritas.
         * Tingkat prioritas adalah lama dan banyak nya performance yang diberikan oleh 1 logical processor (nanti akan di bahas pada chapter Thread Pool) kepada beberapa thread yang sedang aktif dikerjakan.
         * 
         * Apabila PC anda adalah PC yang memiliki hanya 1 core logical processor, maka seluruh percobaan Thread Priority di bawah ini akan berhasil, 
         * tetapi apabila PC anda memiliki lebih dari 1 logical processor, maka seluruh percobaan prioritas dibawah ini tidak akan ada effectnya dan silahkan skip pelajaran ini.
         * 
         * Bagaimana cara mengetahui jumlah logical processor kalian?
         * Silahkan aksesk Task Manager > Performance > CPU
         */

        public static void PerbedaanDuaPrioritas() {

            /*
             * Percobaan di bawah ini adalah dengan menggunakan 2 thread biasa yang mengeksekusi infinite loop dalam waktu 10 detik.
             * 
             * Thread pertama diberikan priority ter-rendah (Lowest) dan yang kedua dengan priority tertinggi (Highest).
             * Priority diberikan dengan tipe data enum ThreadPriority.
             * 
             * Apabila kalian mencoba ini di atas single logical processor, maka volume air pada highest priority akan jauh lebih banyak.
             * Itu karena ada 1 logical processor yang menjalan 2 thread sekaligus, maka fokus dan performance core tersebut terbagi dua, 
             * dan kita bisa memberikan konsentrasi lebih ke priority yang lebih tinggi.
             * 
             * Di atas multi logical processor, persaingan 2 thread tidak terjadi, dan hasil volume air pada kedua thread tersebut hasilnya random.
             */

            Console.WriteLine("Menunggu 10 detik proses...\n");

            var lowest = new Thread(FarLoop);
            lowest.Priority = ThreadPriority.Lowest;

            var highest = new Thread(FarLoop);
            highest.Priority = ThreadPriority.Highest;

            lowest.Start();
            highest.Start();
            Thread.Sleep(10000);
            _kehabisanWaktu = true;
        }

        /// <summary>
        /// Di bawah ini ditunjukan seluruh macam priority, dari yang paling rendah ke yang paling tinggi secara berurutan:
        /// Lowest < Below Normal < Normal < Above Normal < Highest
        /// </summary>
        public static void SeluruhMacamPrioritas() {
            Console.WriteLine("Menunggu 10 detik proses:\n");
            new Thread(FarLoop) {
                Priority = ThreadPriority.Lowest
            }.Start();
            new Thread(FarLoop) {
                Priority = ThreadPriority.BelowNormal
            }.Start();
            new Thread(FarLoop) {
                Priority = ThreadPriority.Normal
            }.Start();
            new Thread(FarLoop) {
                Priority = ThreadPriority.AboveNormal
            }.Start();
            new Thread(FarLoop) {
                Priority = ThreadPriority.Highest
            }.Start();
            Thread.Sleep(10000);
            _kehabisanWaktu = true;
        }

        public static void IsiAirSatuLiter(object speed) {
            while (_volumeAir < _volumeMax) {
                Console.WriteLine($"Air ditambahkan 1 liter oleh {Thread.CurrentThread.Name}, volume air saat ini {++_volumeAir}");
                Thread.Sleep((int)speed);
            }
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

        public static void FarLoop() {
            while (!_kehabisanWaktu) {
                _volumeAir++;
            }
            Console.WriteLine($"Thread dengan priority {Thread.CurrentThread.Priority}, volume air: \n{_volumeAir.ToString("N0")}\n");
        }
    }
}
