using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceAndAbstractClass {
    public interface IMobilePhone {
        string PhoneType { get; set; }
        double DisplaySize { get; set; }
        int BatteryCapacity { get; set; }
        string OperatingSystem { get; set; }

        void OperatingSystemInformation();
        void ExecuteCalling(string phoneNumber);
    }
}
