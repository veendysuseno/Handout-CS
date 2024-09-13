using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SerializingDataContract.Models
{
    [DataContract(Name = "Toko")]
    public class Store
    {
        [DataMember]
        public long Id { get; set; }

        [DataMember(Name = "Nama")]
        public string Name { get; set; }

        [DataMember(Name = "Alamat")]
        public string Address { get; set; }

        [DataMember(Name = "ProdukDijual")]
        public List<Product> ProducsOnSale { get; set; }
    }
}
