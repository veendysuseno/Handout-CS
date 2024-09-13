using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceAndAbstractClass {

    /*
     * Jewelries adalah salah satu jenis Item yang merupakan regular class biasa.
     */

    public class Jewelries : Item {

        public string Material { get; set; }
        public double Weight { get; set; }

        public override double TaxPercentage {
            get {
                return TaxPercentage;
            }
            set {
                if(this.Price > 20000000)
                    TaxPercentage = 15;
                TaxPercentage = 10;
            }
        }

        public Jewelries(string itemCode, string name, string brand, decimal price, string material) : base(itemCode, name, brand, price) {
            this.Material = material;
        }

        public override string GetInformationPerPack() {
            return "Jewelries item has no pack";
        }

        public string JewelryInformation() {
            string information = String.Format("the jewelry consist of {0} gram of {1}", this.Material, this.Weight);
            return information;
        }
    }
}
