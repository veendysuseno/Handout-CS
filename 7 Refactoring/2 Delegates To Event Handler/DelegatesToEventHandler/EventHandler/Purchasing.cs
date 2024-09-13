using DelegatesToEventHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHandler.DelegatesToEventHandler {
    /*
     * Static class Purchasing adalah class yang bertanggung jawab untuk menjadi trigger pada saat PEMBELIAN PRODUCT.
     */
    public static class Purchasing {

        //Delegate yang diperuntukan memiliki parameter Customer dan return void. (Dengan parameter EventArgs, delegate ini bisa dibuatkan event handlernya)
        public delegate void ProductPurchasedEventHandler(Customer customer, EventArgs args);

        //Event handler yang bisa meregister seluruh function yang di point oleh delegates ProductPurchasedEventHandler
        public static event ProductPurchasedEventHandler ProductPurchaseEvents;

        public static Customer Customer { get; set; }

        /// <summary>
        /// Method OnProductPurchased adalah satu-satunya method yang di invoke pada saat pembelian product.
        /// </summary>
        public static void OnProductPurchased() {
            //check apakah ada setidaknya 1 function/delegates yang ter-register di daslam property event handler ini.
            //apa bila ada, langsung di invoke semuanya.
            if (ProductPurchaseEvents != null) {
                ProductPurchaseEvents(Customer, EventArgs.Empty);
            }
        }

    }
}
