using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternMatching {
    public class Employee : Person{
        public decimal Salary { get; set; }
        public string StaffNumber { get; set; }
        public DateTime HireDate { get; set; }

        public Employee() : base() {

        }

        public Employee(string name, char gender, DateTime dateOfBirth, string placeOfBirth, decimal salary, string staffNumber, DateTime hireDate) : 
            base(name, gender, dateOfBirth, placeOfBirth) {
            this.Name = name;
            this.Gender = gender;
            this.DateOfBirth = dateOfBirth;
            this.PlaceOfBirth = placeOfBirth;
            this.Salary = salary;
            this.StaffNumber = staffNumber;
            this.HireDate = hireDate;
        }
    }
}
