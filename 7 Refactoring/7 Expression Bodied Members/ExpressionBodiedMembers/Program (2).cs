using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionBodiedMembers {
    class Program {
        static void Main(string[] args) {
            Person mandy = new Person("Mandy", "Monroe", new DateTime(1988, 11, 27), 5);
            Console.WriteLine(mandy);
            mandy.DisplayName();

            Console.WriteLine($"Umur Mandy kurang lebih: {mandy.CalculateAge()} tahun");
        }
    }
}
