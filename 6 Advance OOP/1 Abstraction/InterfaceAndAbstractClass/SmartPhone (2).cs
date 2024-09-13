using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceAndAbstractClass {

    /*
     * SmartPhone merupakan salah satu jenis Electronic, tetapi juga mewariskan template dari IMobilePhone
     */
    public class SmartPhone : Electronic, IMobilePhone {

        public string PhoneType { get; set ; }
        public double DisplaySize { get; set; }
        public int BatteryCapacity { get; set; }
        public string OperatingSystem { get; set; }
        public List<string> Applications { get; set; }

        public SmartPhone(string itemCode, string name, string brand, decimal price, int yearsOfWarranty, string phoneType, string operatingSystem) : base(itemCode, name, brand, price, yearsOfWarranty) {
            this.PhoneType = phoneType;
            this.OperatingSystem = operatingSystem;
        }

        public void ExecuteCalling(string phoneNumber) {
            Console.WriteLine("Calling this number {0}", phoneNumber);
        }

        public void OperatingSystemInformation() {
            Console.WriteLine("Operating system in this phone is {0}", this.OperatingSystem);
        }
    }
}
