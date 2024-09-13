using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceAndAbstractClass {

    /*
     * Item merupakan abstract class, karena aplikasi ini tidak mengijin kan program untuk membuat object tanpa item yang spesifik.
     */
    public abstract class Item {
        public string ItemCode { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public abstract double TaxPercentage { get; set; }

        public Item(string itemCode, string name, string brand, decimal price) {
            this.ItemCode = itemCode;
            this.Name = name;
            this.Brand = brand;
            this.Price = price;
        }

        public virtual decimal CalculatePriceAndTax() {
            var taxPercentage = Convert.ToDecimal(this.TaxPercentage / 100);
            var tax = taxPercentage * this.Price;
            var total = this.Price + tax;
            return total;
        }

        public abstract string GetInformationPerPack();
    }
}