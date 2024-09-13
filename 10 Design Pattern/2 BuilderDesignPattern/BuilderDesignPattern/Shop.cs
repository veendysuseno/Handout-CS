﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderDesignPattern
{
    public class Shop
    {
        public void Construct(VehicleBuilder vehicleBuilder) {
            vehicleBuilder.BuildFrame();
            vehicleBuilder.BuildEngine();
            vehicleBuilder.BuildWheels();
            vehicleBuilder.BuildDoors();
        }
    }
}
