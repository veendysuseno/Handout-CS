using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicVsStatic {
    class Program {
        static void Main(string[] args) {

            /* Static Class: adalah class yang tidak bisa dipakai untuk membuat suatu object.
             * Oleh karena itu static class tidak memiliki constructor atau penggunaan this tidak akan memiliki arti.
             */
            Item.Name = "Hard Disk";
            Item.Brand = "Sea Gate";
            Item.Stock = 30;
            Item.PrintInfo();

            /* Non Static Class yang memiliki static member.
             * Class ini bisa di inisialisasi, tapi pemberian property ke class tersebut tidak selalu berdasarkan object.
             */
            Customer alex = new Customer("00234AAC", "Alex Sanjaya", new DateTime(1987, 11, 23));
            Customer.MinimumVoucher = 5000;
            Customer.MaximumVoucher = 15000;
            alex.PrintCustomerInfo();
            Customer.PrintVoucher();
        }
    }
}
