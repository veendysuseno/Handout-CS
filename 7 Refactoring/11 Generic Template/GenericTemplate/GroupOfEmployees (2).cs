using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericTemplate
{
    /* Generic constraint tidak hanya berlaku pada method, tetapi pada class juga.
     */
    public class GroupOfEmployees<Template> where Template : Employee
    {
        public List<Template> Employees { get; set; }

        public void PrintAllEmployeeInfos() {
            foreach (var employee in this.Employees) {
                employee.PrintEmployeeInfo();
            }
        }

        public void PrintAllOriginalDataType() {
            foreach (var employee in this.Employees) {
                var type = employee.GetType();
                Console.WriteLine($"Original Type: {type.Name}");
            }
        }
    }
}
