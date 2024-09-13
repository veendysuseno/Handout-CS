using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethods {
    public static class VaultSystem {
        public static int VaultNumber { get; set; }

        /*
         * Extension method dipanggil pada sebuah method yang memiliki kata this pada parameternya.
         * Extension method hanya bisa ditulis pada class yang sifatnya static dan pada static method.
         */

        public static string AccessingVault(this string username) {
            string accessingMessage = String.Format($"{username} is accessing vault {VaultNumber}");
            return accessingMessage;
        }

        public static void AccessingVault(this string username, string password) {
            Console.WriteLine(AccessingVault(username));
            Console.WriteLine(String.Format($"accessing with {password}"));       
        }

        public static int CalculateNumber(this int value, int pengali) {
            return value * pengali;
        }
    }
}
