using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderDesignPattern
{
    public class MotorCycleBuilder : VehicleBuilder
    {
        public MotorCycleBuilder() {
            this.Vehicle = new Vehicle("MotorCycle");
        }

        public override void BuildFrame() {
            this.Vehicle.SetParts("frame", "MotorCycle Frame");
        }

        public override void BuildEngine() {
            this.Vehicle.SetParts("engine", "500 cc");
        }

        public override void BuildWheels() {
            this.Vehicle.SetParts("wheels", "2");
        }

        public override void BuildDoors() {
            this.Vehicle.SetParts("doors", "0");
        }
    }
}
