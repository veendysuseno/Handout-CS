using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuplesAndDeconstruction {
    public class Person {
        public string Name { get; set; }
        public Car PrivateCar { get; set; }
        public City BirthCity { get; set; }

        public Person() {

        }

        public Person(string name, Car privateCar, City birthCity) {
            this.Name = name;
            this.PrivateCar = privateCar;
            this.BirthCity = birthCity;
        }
    }
}
