using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicObjectAndVariable {
    public struct Employee {
        public int EmployeeNumber { get; set; }
        public string Name { get; set; }

        public Employee(int employeeNumber, string name) {
            this.EmployeeNumber = employeeNumber;
            this.Name = name;
        }
    }
}
