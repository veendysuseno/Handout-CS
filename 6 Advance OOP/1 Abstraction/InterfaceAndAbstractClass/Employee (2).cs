using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceAndAbstractClass {

    /*
     * Employee adalah abstract class yang akan di inherit oleh setiap class pekerja.
     */
    public abstract class Employee {
        public string EmployeeNumber { get; set; }
        public DateTime HireDate { get; set; }
        public decimal Salary { get; set; }

        public abstract void EmployeeInformation();

        public decimal GetAnnualSalary() {
            return 12 * this.Salary;
        }

        public int YearsOfWorking() {
            int years = DateTime.Today.Year - HireDate.Year;
            return years;
        }

    }
}
