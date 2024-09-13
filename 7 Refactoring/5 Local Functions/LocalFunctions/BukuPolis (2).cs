using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalFunctions {
    public class BukuPolis {
        public decimal BiayaPremi { get; set; }
        public string PemegangPolis { get; set; }

        public string PrintInformasiPelunasanPremi(int totalBulan) {

            string informasi = String.Format("Buku polis milik {0} sudah dibayar sampai sejumlah {1}", this.PemegangPolis, TotalPelunasanPremi(totalBulan).ToString("C2"));
            return informasi;

            decimal TotalPelunasanPremi(int multiplier) {
                decimal pengali = Convert.ToDecimal(multiplier);
                decimal totalPremi = pengali * this.BiayaPremi;
                return totalPremi;
            }
        }
    }
}
