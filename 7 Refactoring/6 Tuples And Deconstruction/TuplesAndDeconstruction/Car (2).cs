using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuplesAndDeconstruction {
    public class Car {
        public string Model { get; set; }
        public string Brand { get; set; }
        public double MaxSpeed { get; set; }

        public Car() {

        }

        public Car(string model, string brand, double maxSpeed) {
            this.Model = model;
            this.Brand = brand;
            this.MaxSpeed = maxSpeed;
        }
    }
}
