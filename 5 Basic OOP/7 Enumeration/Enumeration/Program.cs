using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enumeration {
    class Program {
        static void Main(string[] args) {

            /* Enumeration digunakan untuk membuat suatu tipe pilihan, dimana semua valuenya merupakan seluruh hal yang terdaftar di dalamnya.
             * Enum sifatnya seperti static class, tetapi hanya memiliki satu property yang di simpan di enum itu sendiri.
             */

            UserAccount anthony = new UserAccount() {
                Username = "anthony",
                Password = "Jackal89",
                Privilege = Privileges.Moderator
            };

            if (anthony.Privilege == Privileges.Moderator) {
                Console.WriteLine("Anthony is moderator");
            }

            switch (anthony.Privilege) {
                case Privileges.Admin:
                    Console.WriteLine("Anthony is Admin");
                    break;
                case Privileges.Editor:
                    Console.WriteLine("Anthony is Editor");
                    break;
                case Privileges.Manager:
                    Console.WriteLine("Anthony is Manager");
                    break;
                case Privileges.Moderator:
                    Console.WriteLine("Anthony is Moderator");
                    break;
                case Privileges.User:
                    Console.WriteLine("Anthony is User");
                    break;
                default:
                    Console.WriteLine("Anthony is unknown");
                    break;
            }
        }
    }
}
