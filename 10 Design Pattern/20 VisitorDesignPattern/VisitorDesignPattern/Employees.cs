using System;
using System.Collections.Generic;
using System.Text;

namespace VisitorDesignPattern
{
    public class Employees
    {
        private List<Employee> ListEmployee { get; set; }

        public Employees() {
            this.ListEmployee = new List<Employee>();
        }

        public void Attach(Employee employee) {
            this.ListEmployee.Add(employee);
        }

        public void Detach(Employee employee) {
            this.ListEmployee.Remove(employee);
        }

        public void Accept(IVisitor visitor) {
            foreach (Employee employee in this.ListEmployee) {
                employee.Accept(visitor);
            }
            Console.WriteLine();
        }
    }
}
