using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeStructs {

    //3. Struct hanya bisa inherit dari interface, struct tidak bisa inherit dari class, abstract class ataupun struct lainnya.
    public struct Manager : IEmployee {
        public string EmployeeNumber { get; set; }
        public string Name { get; set; }
        public decimal Salary;
    }
}
