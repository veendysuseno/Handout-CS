using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectAndClass {
    public class Building {

        public Building(string alamat, string kota, int totalLevel) {
            Alamat = alamat;
            Kota = kota;
            TotalLevel = totalLevel;
        }

        //Auto Property: feature C# version 3. Membuat property dengan lebih singkat dan lebih mudah. Sifatnya seperti gabungan dari field dan getter setter method.
        public string Alamat { get; set; }
        public string Kota { get; set; }
        public int TotalLevel { get; set; }
    }
}
