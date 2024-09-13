using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceAndAbstractClass {

    /*
     * Softdrink adalah salah satu jenis Item dan merupakan class regular
     */

    public class SoftDrink : Item {

        public DateTime ExpireDate { get; set; }
        public int TotalPerPack { get; set; }
        public int Type { get; set; }
        public int Volume { get; set; }

        public override double TaxPercentage {
            get {
                return TaxPercentage;
            }
            set {
                TaxPercentage = 5;
            }
        }

        public SoftDrink(string itemCode, string name, string brand, decimal price, DateTime expireDate) : base(itemCode, name, brand, price) {
            this.ExpireDate = expireDate;
        }

        public override string GetInformationPerPack() {
            string information = String.Format("{0}{1} of {2} per pack", this.TotalPerPack, this.Volume, this.Type);
            return information;
        }

        public int DaysToExpire() {
            int range = (DateTime.Today - ExpireDate).Days;
            return range;
        }
    }
}
