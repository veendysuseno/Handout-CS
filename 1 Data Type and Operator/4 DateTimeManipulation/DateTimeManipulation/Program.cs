using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateTimeManipulation {
    class Program {
        static void Main(string[] args) {
            //Set waktu untuk sekarang
            DateTime sekarang = DateTime.Now;
            DateTime hariIni = DateTime.Today;
            DateTime max = DateTime.MaxValue;
            DateTime min = DateTime.MinValue;
            Console.WriteLine(sekarang);
            Console.WriteLine(hariIni);
            Console.WriteLine(max);
            Console.WriteLine(min); //Minimum date di dalam SQL Server dan kebanyakan DB adalah January 1, 1753

            //Mengambil bagian dari waktu
            int year = sekarang.Year;
            Console.WriteLine("tahun: {0}", year);
            int month = sekarang.Month;
            Console.WriteLine("bulan: {0}", month);
            int day = sekarang.Day;
            Console.WriteLine("hari: {0}", day);
            int hour = sekarang.Hour;
            Console.WriteLine("jam: {0}", hour);
            int minutes = sekarang.Minute;
            Console.WriteLine("menit: {0}", minutes);
            int seconds = sekarang.Second;
            Console.WriteLine("detik: {0}", seconds);
            int miliseconds = sekarang.Millisecond;
            Console.WriteLine("detik/1000: {0}", miliseconds);

            //Conversion
            string formatSatu = sekarang.ToShortDateString();
            Console.WriteLine(formatSatu);
            string formatDua = sekarang.ToLongTimeString();
            Console.WriteLine(formatDua);
            string formatTiga = sekarang.ToString("dd MMMM yyyy");
            Console.WriteLine(formatTiga);
            string formatEmpat = sekarang.ToString("dd/MM/yy hh:mm:ss");
            Console.WriteLine(formatEmpat);

            //Formatting bahasa
            DateTime sebuahtanggal = new DateTime(2018, 3, 12);
            string date = sebuahtanggal.ToString("dd MMMM yyyy");
            Console.WriteLine(date);
            //Memaksakan dalam format bahasa indonesia
            string tanggalan = sebuahtanggal.ToString("dd MMMM yyyy", CultureInfo.CreateSpecificCulture("id-ID"));
            Console.WriteLine("Dalam indonesia: " + tanggalan);

            //Calculate Date
            DateTime startTanggal = new DateTime(2018, 9, 10);
            Console.WriteLine(startTanggal.ToLongDateString());

            DateTime limaHariKemudian = startTanggal.AddDays(5);
            Console.WriteLine(limaHariKemudian.ToLongDateString());

            DateTime duaTahunKemudian = startTanggal.AddYears(2);
            Console.WriteLine(duaTahunKemudian.ToLongDateString());

            DateTime bulanDepan = startTanggal.AddMonths(1);
            Console.WriteLine(bulanDepan.ToLongDateString());

            //Time Span
            //Time Span adalah tipe data yang menampung durasi waktu antara 2 DateTime. Satuan tertingginya dihitung lewat jumlah hari.
            DateTime today = DateTime.Today;
            DateTime target = new DateTime(1994, 9, 18);

            TimeSpan durasi = today - target;
            Console.WriteLine(durasi);
            Console.WriteLine("Dalam hari: " + durasi.TotalDays);

            DateTime total = min + durasi;
            Console.WriteLine(total);

        }
    }
}
