using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SerializingDataContract.Models
{
    [DataContract(Name = "Produk")]
    public class Product
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember(Name = "Nama")]
        public string Name { get; set; }

        [DataMember(Name = "Deskripsi")]
        public string Description { get; set; }

        [DataMember(Name = "Stok")]
        public int Stock { get; set; }

        [DataMember(Name = "Harga")]
        public decimal Price { get; set; }
    }
}
