using DelegatesToEventHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHandler.DelegatesToEventHandler {
    /*
     * Static class Delivering adalah class yang bertanggung jawab untuk menjadi trigger pada saat PENGIRIMAN PRODUCT.
     */
    public static class Delivering {
        //Delegate yang diperuntukan memiliki parameter Customer dan return void. (Dengan parameter EventArgs, delegate ini bisa dibuatkan event handlernya)
        public delegate void ProductDeliveringEventHandler(Customer customer, ExpeditionEventArgs args);

        //Event handler yang bisa meregister seluruh function yang di point oleh delegates ProductDeliveringEventHandler
        public static event ProductDeliveringEventHandler DeliveringProductEvents;

        public static Customer Customer { get; set; }

        /// <summary>
        /// Method ini tidak ada gunanya, method ini hanya untuk menunjukan kepada kalian kalau OnProductDelivering method tidak harus di invoke langsung untuk
        /// meng-invoke seluruh isi function yang ke register.
        /// 
        /// Dan dengan method ini kalian bisa melakukan debugging dan melihat seluruh delegates akan di panggil bukan pada method ini, melainkan pada OnProductDelivering.
        /// </summary>
        /// <param name="trackHistories"></param>
        public static void ProcessDelivery(List<TrackingHistory> trackHistories) {
            OnProductDelivering(trackHistories);
        }

        /// <summary>
        /// OnProductDelivery method akan sedikit berbeda dengan OnPurchased yang tidak memiliki parameter, karena pada method ini, parameter akan digunakan.
        /// </summary>
        /// <param name="trackHistories">List TrackHistory akan dimasukan ke dalam property ExpeditionEventArgs</param>
        public static void OnProductDelivering(List<TrackingHistory> trackHistories) {
            //check apakah ada setidaknya 1 function/delegates yang ter-register di daslam property event handler ini.
            //apa bila ada, langsung di invoke semuanya.
            if (DeliveringProductEvents != null) {
                //set trackHistories ke dalam event args agar bisa masuk ke dalam event handler parameter
                ExpeditionEventArgs expeditionEventArgs = new ExpeditionEventArgs();
                expeditionEventArgs.TrackingHistories = trackHistories;
                DeliveringProductEvents(Customer, expeditionEventArgs);
            }
        }

    }
}
