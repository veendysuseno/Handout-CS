using System;
using System.Collections.Generic;
using System.Globalization; //Untuk memakasi static CultureInfo
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecimalFormat {
    class Program {
        static void Main(string[] args) {
            decimal decimalSatu = 250000m;
            decimal decimalDua = 2400.56m;

            //C singkatan dari currency, apabila C3, berarti 3 angka dibelakang koma
            string currencySatu = decimalSatu.ToString("C3");
            string currencyDua = decimalDua.ToString("C3");
            Console.WriteLine(currencySatu);
            Console.WriteLine(currencyDua);

            //merubah format negaranya. Untuk code negara lain bisa dilihat di link di bawah ini.
            //https://azuliadesigns.com/list-net-culture-country-codes/
            //supaya CultureInfo bisa bekerja, harus di tambahkan using System.Globalization
            string rupiahSatu = decimalSatu.ToString("C2", CultureInfo.CreateSpecificCulture("id-ID"));
            string rupiahDua = decimalDua.ToString("C2", CultureInfo.CreateSpecificCulture("id-ID"));
            Console.WriteLine(rupiahSatu);
            Console.WriteLine(rupiahDua);

            double doubleSatu = 0.5;
            double doubleDua = 0.2;

            //P adalah percent
            string percentFormatSatu = doubleSatu.ToString("P0");
            string percentFormatDua = doubleDua.ToString("P2");
            Console.WriteLine(percentFormatSatu);
            Console.WriteLine(percentFormatDua);
        }
    }
}
