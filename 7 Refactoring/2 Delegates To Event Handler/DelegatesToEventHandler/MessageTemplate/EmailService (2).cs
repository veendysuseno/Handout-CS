using DelegatesToEventHandler.EventArguments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesToEventHandler {
    /*
     * Class ini digunakan untuk mengatur pengiriman email secara otomatis kepada customer
     */
    public class EmailService {
        public string Subject { get; set; } //Subject dari Email
        public string ProductInformation { get; set; } //Informasi product yang dibeli

        public EmailService(string subject, string productInformation) {
            this.Subject = subject;
            this.ProductInformation = productInformation;
        }

        /// <summary>
        /// Subject and Body email yang akan di kirim ke customer pada saat PEMBELIAN PRODUCT.
        /// </summary>
        /// <param name="customer">Object customer yang akan menerima email.</param>
        /// <param name="eventParam">EvetArgs adalah event parameter yang siap menerima event argument apa pun. Walaupun tidak digunakan, 
        ///     event parameter harus ada untuk function yang akan di daftarkan ke dalam satu event handler.
        /// </param>
        public void OnProductPurchased(Customer customer, EventArgs eventParam) {
            string mail = String.Format("Terimakasih {0}, karena sudah berbelanja di Market Place kami, click link di bawah ini untuk melihat sisa point anda: \nwww.marketplace.com\n\nBarang belanjaan anda adalah:", customer.FullName);
            string entireEmail = String.Format("Send To: {0}\nSubject: {1}\n\n{2}\n{3}\n\nBest Regards,\nStaff Market Place", customer.EmailAddress, this.Subject, mail, this.ProductInformation);
            Console.WriteLine("======================= Mail Service ======================");
            Console.WriteLine(entireEmail);
            Console.WriteLine("==========================================================\n");
        }

        /// <summary>
        /// Subject and Body email yang akan di kirim ke customer pada saat PRODUCT DALAM PENGIRIMAN.
        /// </summary>
        /// <param name="customer">Object customer yang akan menerima email.</param>
        /// <param name="eventParam">Pada contoh kali ini, object EventArgs akan benar-benar digunakan. Agar bisa di sisipkan property yang kita inginkan,
        ///     kita menggunakan class ExpeditionEventArgs yang sudah meng-inherit kemampuan EventArgs class.
        ///     ExpeditionEventArgs memiliki 1 property, yaitu list dari tracking history yang menjelaskan tahap demi tahap setiap pengiriman di distribusi.
        /// </param>
        public void OnProductDelivering(Customer customer, ExpeditionEventArgs eventParam) {
            Console.WriteLine("======================= Mail Service ======================");
            Console.WriteLine("Send To: {0}\nSubject: {1}\n", customer.EmailAddress, this.Subject);
            Console.WriteLine("Dear {0}, barang anda {1} saat ini sedang dalam pengiriman. Tracking informationnya kurang lebih seperti ini.", customer.FullName, this.ProductInformation);
            foreach (TrackingHistory track in eventParam.TrackingHistories) {
                Console.WriteLine("{0} - Sudah Sampai: {1} - {2}", track.TrackingDate.ToString("dd/MM/yyyy"), track.Location, track.Description);
            }
            Console.WriteLine("\nBest Regards,\nStaff Market Place");
            Console.WriteLine("==========================================================\n");
        }

        /// <summary>
        /// Subject and Body email yang akan di kirim ke customer pada saat NOTIFIKASI SEHARI-SEHARI.
        /// </summary>
        /// <param name="customer">Object customer yang akan menerima email.</param>
        /// <param name="eventParam">Di sini, event args akan membawa property berupa berita yang ingin di notifikasikan ke customer lewat class yang kita buat, yaitu News Args/// </param>
        public void OnNotified(object customer, NewsEventArgs newsParam) {
            Console.WriteLine("======================= Mail Service ======================");
            string name = ((Customer)customer).FullName;
            Console.WriteLine("Dear {0}, {1}", name, newsParam.News);
            Console.WriteLine("==========================================================\n");
        }
    }
}
