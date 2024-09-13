using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderDesignPattern
{
    public class Vehicle
    {
        public string VehicleType { get; set; }
        public Dictionary<string, string> Parts { get; set; }

        public Vehicle(string vehicleType) {
            this.VehicleType = vehicleType;
            this.Parts = new Dictionary<string, string>();
        }

        public string GetParts(string key) {
            return this.Parts[key];
        }

        public void SetParts(string key, string value) {
            this.Parts[key] = value;
        }

        public void Show() {
            Console.WriteLine("\n---------------------------");
            Console.WriteLine("Vehicle Type: {0}", this.VehicleType);
            Console.WriteLine(" Frame : {0}", this.Parts["frame"]);
            Console.WriteLine(" Engine : {0}", this.Parts["engine"]);
            Console.WriteLine(" #Wheels: {0}", this.Parts["wheels"]);
            Console.WriteLine(" #Doors : {0}", this.Parts["doors"]);
        }
    }
}
