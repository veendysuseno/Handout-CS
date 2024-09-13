using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuplesAndDeconstruction {
    public class City {
        public string Name { get; set; }
        public string CountryName { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }

        public City() {

        }

        public City(string name, string countryName, double longitude, double latitude) {
            this.Name = name;
            this.CountryName = countryName;
            this.Longitude = longitude;
            this.Latitude = latitude;
        }
    }
}
