using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternMatching {
    public class MobilePhone : Item {
        public string Brand { get; set; }
        public string Color { get; set; }
        public int Memory { get; set; }

        public MobilePhone() : base() {

        }

        public MobilePhone(string name, decimal price, string brand, string color, int memory) : base(name, price){
            this.Brand = brand;
            this.Color = color;
            this.Memory = memory;
        }
    }
}
