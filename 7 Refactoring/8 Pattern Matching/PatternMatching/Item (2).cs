using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternMatching {
    public class Item {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Item() {
        }

        public Item(string name, decimal price) {
            this.Name = name;
            this.Price = price;
        }
    }
}
