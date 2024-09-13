using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderDesignPattern
{
    public class CarBuilder : VehicleBuilder
    {
        public CarBuilder() {
            this.Vehicle = new Vehicle("Car");
        }

        public override void BuildFrame() {
            this.Vehicle.SetParts("frame", "Car Frame");
        }

        public override void BuildEngine() {
            this.Vehicle.SetParts("engine", "2500cc");
        }

        public override void BuildWheels() {
            this.Vehicle.SetParts("wheels", "4");
        }

        public override void BuildDoors() {
            this.Vehicle.SetParts("doors", "4");
        }
    }
}
