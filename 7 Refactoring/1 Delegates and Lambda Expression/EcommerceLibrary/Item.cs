using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceLibrary
{
    public class Item
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }

        public Item(string name, string category, decimal price) {
            this.Name = name;
            this.Category = category;
            this.Price = price;
        }
    }
}
