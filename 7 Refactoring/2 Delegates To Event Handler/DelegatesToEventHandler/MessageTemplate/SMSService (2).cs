using DelegatesToEventHandler.EventArguments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesToEventHandler {
    /*
     * Class ini digunakan untuk mengatur pengiriman sms secara otomatis kepada customer
     */
    public class SMSService {
        public string ProductInformation { get; set; } //Informasi product yang dibeli

        public SMSService(string productInformation) {
            this.ProductInformation = productInformation;
        }

        /// <summary>
        /// Message SMS yang akan di kirim ke customer pada saat PEMBELIAN PRODUCT.
        /// </summary>
        /// <param name="customer">Object customer yang akan menerima sms.</param>
        /// <param name="eventParam">EvetArgs adalah event parameter yang siap menerima event argument apa pun. Walaupun tidak digunakan, 
        ///     event parameter harus ada untuk function yang akan di daftarkan ke dalam satu event handler.
        /// </param>
        public void OnProductPurchased(Customer customer, EventArgs eventParam) {
            string message = String.Format("{0}, pembayaran mu telah diterima oleh Market Place untuk barang:\n", customer.FullName);
            string entireSMS = String.Format("Send To: {0}\n{1}{2}", customer.PhoneNumber, message, this.ProductInformation);
            Console.WriteLine("======================= SMS Service ======================");
            Console.WriteLine(entireSMS);
            Console.WriteLine("==========================================================\n");
        }

        /// <summary>
        /// Message SMS yang akan di kirim ke customer pada saat PRODUCT DALAM PENGIRIMAN.
        /// </summary>
        /// <param name="customer">Object customer yang akan menerima sms.</param>
        /// <param name="eventParam">Pada contoh kali ini, object EventArgs akan benar-benar digunakan. Agar bisa di sisipkan property yang kita inginkan,
        ///     kita menggunakan class ExpeditionEventArgs yang sudah meng-inherit kemampuan EventArgs class.
        ///     ExpeditionEventArgs memiliki 1 property, yaitu list dari tracking history yang menjelaskan tahap demi tahap setiap pengiriman di distribusi.
        /// </param>
        public void OnProductDelivering(Customer customer, ExpeditionEventArgs eventParam) {
            Console.WriteLine("======================= SMS Service ======================");
            Console.WriteLine("Send To: {0}\nBarang: {1}", customer.PhoneNumber, this.ProductInformation);
            Console.WriteLine("Dear {0}, barang anda saat ini sedang dalam pengiriman. Tracking informationnya kurang lebih seperti ini.", customer.FullName);
            foreach (TrackingHistory track in eventParam.TrackingHistories) {
                Console.WriteLine("{0} - Sudah Sampai: {1} - {2}", track.TrackingDate.ToString("dd/MM/yyyy"), track.Location, track.Description);
            }
            Console.WriteLine("==========================================================\n");
        }

        /// <summary>
        /// SMS yang akan di kirim ke customer pada saat NOTIFIKASI SEHARI-SEHARI.
        /// </summary>
        /// <param name="customer">Object customer yang akan menerima sms.</param>
        /// <param name="eventParam">Di sini, event args akan membawa property berupa berita yang ingin di notifikasikan ke customer lewat class yang kita buat, yaitu News Args/// </param>
        public void OnNotified(object customer, NewsEventArgs newsParam) {
            Console.WriteLine("======================= SMS Service ======================");
            string name = ((Customer)customer).FullName;
            Console.WriteLine("Hai {0}, {1}", name, newsParam.News);
            Console.WriteLine("==========================================================\n");
        }
    }
}
