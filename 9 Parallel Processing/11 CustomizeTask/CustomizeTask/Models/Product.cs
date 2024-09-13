using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace CustomizeTask.Models
{
    public class Product
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("Nama")]
        public string Name { get; set; }

        [JsonPropertyName("Deskripsi")]
        public string Description { get; set; }

        [JsonIgnore]
        public int Stock { get; set; }

        [JsonPropertyName("Harga")]
        public decimal Price { get; set; }
    }
}
