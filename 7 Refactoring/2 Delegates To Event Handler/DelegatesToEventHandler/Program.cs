using EventHandler.DelegatesToEventHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesToEventHandler {
    class Program {
        static void Main(string[] args) {

            /*
             * Event Driven Programming adalah suatu tata cara menulis code dengan memanfaatkan event handler yang bisa dibuat dengan menggunakan delegates.
             * 
             * Event handler sendiri adalah sebuah function yang dibuat dimana apabila function ini di invoke, akan ada function lain yang ikut terinvoke apabila di daftarkan
             * kedalam event handler tersebut.
             */

            //variable ini adalah product yang akan dibeli di contoh setelah ini
            string productInformation = "1 buah mouse Logitech M20";

            /*
             * Pada contoh business case di bawah ini, seorang customer akan dikirimkan email dan sms untuk setiap langkah-langkah pembelian barang di dalam
             * aplikasi ini.
             * 
             * Contoh di region pertama adalah pada saat customer melakukan pembelian.
             */
            #region Purchasing

            Customer nadia = new Customer("Nadia Margareth", "nadia.margareth@gmail.com", "08216778994");
            
            Purchasing.Customer = nadia;
            EmailService emailService = new EmailService("Konfirmasi Pembelian Barang", productInformation);
            SMSService smsService = new SMSService(productInformation);

            //Mendaftarkan seluruh function dengan parameter EventArgs ke dalam event handler yang merupakan property dari Purchasing.
            //Function yang di daftarkan berbentuk delegates atau function pointer, dan ditambahkan hanya dengan menggunakan += operator.
            Purchasing.ProductPurchaseEvents += emailService.OnProductPurchased;
            Purchasing.ProductPurchaseEvents += smsService.OnProductPurchased;

            Purchasing.OnProductPurchased();

            #endregion

            #region Delivering

            Customer joko = new Customer("Joko Anwar", "joko.anwar@gmail.com", "082577845568");

            Delivering.Customer = joko;
            EmailService emailServicePengiriman = new EmailService("Track Pengiriman Barang", productInformation);
            SMSService smsServicePengiriman = new SMSService(productInformation);

            Delivering.DeliveringProductEvents += emailServicePengiriman.OnProductDelivering;
            Delivering.DeliveringProductEvents += smsServicePengiriman.OnProductDelivering;

            List<TrackingHistory> trackHistories = new List<TrackingHistory>() {
                new TrackingHistory("Location X", new DateTime(2017, 5, 12), "Sudah di sampai di lokasi X"),
                new TrackingHistory("Location Y", new DateTime(2017, 5, 14), "Sudah diterima di lokasi Y")
            };

            Delivering.ProcessDelivery(trackHistories);

            #endregion

            #region Notification

            Notification.Customer = joko;
            EmailService emailServiceNotif = new EmailService("", "");
            SMSService smsServiceNotif = new SMSService("");

            Notification.NotifyEvents += emailServiceNotif.OnNotified;
            Notification.NotifyEvents += smsServiceNotif.OnNotified;

            Notification.OnNotified("Ada promo terbaru untuk setiap pembelian...");

            #endregion

        }
    }
}
