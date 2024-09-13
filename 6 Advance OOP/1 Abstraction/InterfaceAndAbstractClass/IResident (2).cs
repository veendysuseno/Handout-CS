using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceAndAbstractClass {

    /*
     * IResident adalah interface kependudukan. Penduduk belum tentu warga negara, penduduk hanyalah seseorang yang berada di satu negara karena
     * hal-hal tertentu seperti traveling, bekerja, atau belajar. Setiap penduduk pasti harus membayar pajak apabila bekerja dan beraktifitas di negara tersebut.
     */
    public interface IResident : IPerson {
        string VisaStatus { get; set; }
        string TaxFileNumber { get; set; }
        DateTime VisaGrantTime { get; set; }

        void PayTax();
        void ResidencyInformation();
    }
}
