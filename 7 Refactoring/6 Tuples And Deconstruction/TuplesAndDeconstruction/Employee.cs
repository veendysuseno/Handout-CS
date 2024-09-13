using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuplesAndDeconstruction {
    public class Employee {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public decimal Salary { get; set; }
        public int Weight { get; set; }

        public Employee() {

        }

        public Employee(string name, DateTime birthDate, string birthPlace, decimal salary, int weight) {
            this.Name = name;
            this.BirthDate = birthDate;
            this.BirthPlace = birthPlace;
            this.Salary = salary;
            this.Weight = weight;
        }

        public void Deconstruct(out string name, out DateTime birthDate, out string birthPlace, out decimal salary, out int weight) {
            name = this.Name;
            birthDate = this.BirthDate;
            birthPlace = this.BirthPlace;
            salary = this.Salary;
            weight = this.Weight;
        }

    }
}
