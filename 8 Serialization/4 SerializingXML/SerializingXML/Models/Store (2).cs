using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace SerializingXML.Models
{
    public class Store
    {
        [XmlAttribute("id")]
        public long Id { get; set; }

        [XmlElement(ElementName = "TanggalRegister", Order = 3)]
        public DateTime RegisterDate { get; set; }

        [XmlElement(ElementName = "Alamat", Order = 2)]
        public string Address { get; set; }

        [XmlElement(ElementName = "Nama", Order = 1)]
        public string Name { get; set; }

        [XmlIgnore]
        public string City { get; set; }

        [XmlElement(ElementName = "ProdukJualan", Order = 4)]
        public List<Product> ProducsOnSale { get; set; }
    }
}
