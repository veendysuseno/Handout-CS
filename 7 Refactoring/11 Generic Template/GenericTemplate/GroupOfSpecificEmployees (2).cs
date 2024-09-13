using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericTemplate
{
    /* Pada class generic ini, digabungkan pemakaian inheritance dan constraint. Kurang lebih syntax penulisannya seperti di bawah ini.
     */
    public class GroupOfSpecificEmployees<Template> : GroupOfEmployees<Template> where Template : Employee
    {
        public void PrintAllWorkingDuration() {
            foreach (var employee in this.Employees) {
                Console.WriteLine($"Durations: {employee.GetWorkingMonthDuration()} months");
            }
        }
    }
}
