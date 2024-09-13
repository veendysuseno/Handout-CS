using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceAndAbstractClass {
    /*
     * ICitizen adalah interface yang menjadi template untuk semua warga negara yang mendapatkan keuntungan asuransi dari negara.
     */
    public interface ICitizen {
        bool CitizenMedicalInsuranceShipProgram { get; set; }
        bool CitizenshipLifeInsuranceProgram { get; set; }
        bool CitizenshipRetirementProgram { get; set; }
    }
}
