using System;
using System.Collections.Generic;
using System.Text;

namespace SerializingBinary.Models
{
    [Serializable]
    public class Store
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public DateTime RegisterDate { get; set; }
        public List<Product> ProducsOnSale { get; set; }
    }
}
