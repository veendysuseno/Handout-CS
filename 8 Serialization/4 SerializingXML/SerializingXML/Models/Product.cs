using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace SerializingXML.Models
{
    public class Product
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlElement(ElementName = "Deskripsi", Order = 3)]
        public string Description { get; set; }

        [XmlElement(ElementName = "Nama", Order = 1)]
        public string Name { get; set; }

        [XmlIgnore]
        public int Stock { get; set; }

        [XmlElement(ElementName = "Harga", Order = 2)]
        public decimal Price { get; set; }
    }
}
