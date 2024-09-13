using DelegatesToEventHandler;
using DelegatesToEventHandler.EventArguments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHandler.DelegatesToEventHandler {
    /*
     * Static class Purchasing adalah class yang bertanggung jawab untuk menjadi trigger pada saat PEMBELIAN PRODUCT.
     */
    public static class Notification {

        /*
         * Perhatikan perbedaan event handler pada class Purchasing dan Delivering dengan event handler pada class Notification ini.
         * Ini adalah feature yang lebih baru pada C#, sehingga developer tidak perlu lagi menulis delegates untuk menciptakan event, itu dikarenakan
         * developer bisa langsung menulis tipe EventHandler dengan generic dengan data type yang merupakan keturunan dari EventArgs
         */
        public static event EventHandler<NewsEventArgs> NotifyEvents;
        public static Customer Customer { get; set; }

        public static void OnNotified(string news) {
            //Lihatlah contoh di bawah, ini sudah sama seperti yang ada pada Delivering class. Kita bisa langsung siap menggunakan NotifyEvents tanpa deklarasi delegates terlebih dahulu.
            if (NotifyEvents != null) {
                NewsEventArgs newsArgs = new NewsEventArgs();
                newsArgs.News = news;
                //Parameter customer juga bisa langsung digunakan tanpa deklarasi terlebih dahulu.
                NotifyEvents(Customer, newsArgs);
            }
        }
    }
}
