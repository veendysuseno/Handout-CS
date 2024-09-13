using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace CustomizeTask.Models
{
    public class Store
    {
        [JsonPropertyName("Id")]
        public long Id { get; set; }

        [JsonPropertyName("RegisterDate")]
        public DateTime RegisterDate { get; set; }

        [JsonPropertyName("Nama")]
        public string Name { get; set; }

        [JsonPropertyName("Alamat")]
        public string Address { get; set; }

        [JsonIgnore]
        public string City { get; set; }
        public List<Product> ProducsOnSale { get; set; }
    }
}
