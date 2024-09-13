using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderDesignPattern
{
    public class ScooterBuilder : VehicleBuilder
    {
        public ScooterBuilder() {
            this.Vehicle = new Vehicle("Scooter");
        }

        public override void BuildFrame() {
            this.Vehicle.SetParts("frame", "Scooter Frame");
        }

        public override void BuildEngine() {
            this.Vehicle.SetParts("engine", "50 cc");
        }

        public override void BuildWheels() {
            this.Vehicle.SetParts("wheels", "2");
        }

        public override void BuildDoors() {
            this.Vehicle.SetParts("doors", "0");
        }
    }
}
