using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceAndAbstractClass {

    /*
     * Electronic merupakan jenis Item yang sifatnya abstract class,
     * artinya belum bisa di instantiate tanpa mengetahui jelas ini electronic macam apa.
     */

    public abstract class Electronic : Item {

        public int YearsOfWarranty { get; set; }

        public override double TaxPercentage {
            get {
                return TaxPercentage;
            }
            set {
                TaxPercentage = 10;
            }
        }

        public Electronic(string itemCode, string name, string brand, decimal price, int yearsOfWarranty) : base(itemCode, name, brand, price) {
            this.YearsOfWarranty = yearsOfWarranty;
        }

        public override string GetInformationPerPack() {
            return "Electronic item has no pack";
        }

        public DateTime CalculateWarrantyExpire(DateTime purchaseDate) {
            DateTime warrantyExpireDate = purchaseDate.AddYears(this.YearsOfWarranty);
            return warrantyExpireDate;
        }

    }
}
