using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethods {
    class Program {
        static void Main(string[] args) {

            VaultSystem.VaultNumber = 145;

            /*
             * Extension method memanfaatkan object atau variable yang meng-invoke method tersebut sebagai parameternya.
             * Jadi rasanya seperti object yang memakai method tersebut, tetapi object tersebut malah menjadi parameternya.
             */
            string namaUser = "Albertus";
            var message = namaUser.AccessingVault();
            Console.WriteLine(message);

            namaUser.AccessingVault("openLock");

            //Pemanfaatan extension method bisa dilihat dari penggunaan method bertumpuk seperti dibawah ini.
            //seolah-olah ada method yang meng-invoke method lain.
            int initial = 50;
            int hasil = initial.CalculateNumber(2).CalculateNumber(3);
            Console.WriteLine("Hasilnya {0}", hasil);
        }
    }
}
