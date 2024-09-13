using EcommerceLibrary;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesVariation
{
    class Program
    {
        static void Main(string[] args) {
            Cart keranjang = new Cart();
            keranjang.ItemList = new List<Item>();
            keranjang.ItemList.Add(new Item("Kaos Giordano", "Fashion", 200000m));
            keranjang.ItemList.Add(new Item("Casing Handphone", "Gadget", 120000m));
            keranjang.ItemList.Add(new Item("Charger Iphone", "Electronic", 220000m));

            //mengirim 3 functions dari class Program ke class Cart
            var totalWajibBayar = keranjang.HitungTotalWajibBayar(HitungTotalHargaBarangAlert, HitungTotalDiskonAlert, HitungTotalWajibBayarAlert);

            /*
             * totalWajibBayarLambda akan menerima hasil yang sama persis dengan ongkosKirim, bahkan functionnya sama dan melakukan proses yang sama.
             * Yang menjadi perbedaan adalah, teknik dibawah ini tidak mengharuskan class Program mempersiapkan method yang akan dimasukan ke dalam parameter delegate.
             * 
             * Seluruh proses method langsung ditulis di parameter HitungTotalWajibBayar, sehingga function tidak pernah dibuat dan diberi nama.
             * Oleh karena tidak pernah dibuat dan diberi nama, teknik ini disebut dengan "Anonymous Method" dengan Lambda Expression.
             * 
             * Lambda Expression adalah tanda "=>" yang berarti masukkan function ke dalam parameter atau variable ini.
             * (total)/(diskon)/(wasibBayar) adalah parameter dari fungsi delegate, dimana isi methodnya adalah {}.
             */
            var totalWajibBayarLambda = keranjang.HitungTotalWajibBayar(
                (total) => {
                    string totalString = total.ToString("C2", CultureInfo.CreateSpecificCulture("id-ID"));
                    Console.WriteLine("(Anonymous Method) Total Harga Barangnya adalah: {0}", totalString);
                },
                (diskon) => {
                    string totalString = diskon.ToString("C2", CultureInfo.CreateSpecificCulture("id-ID"));
                    Console.WriteLine("(Anonymous Method) Total Diskonnya adalah: {0}", totalString);
                },
                (wajibBayar) => {
                    string totalString = wajibBayar.ToString("C2", CultureInfo.CreateSpecificCulture("id-ID"));
                    Console.WriteLine("(Anonymous Method) Total Wajib Bayar adalah: {0}", totalString);
                }
            );

            //mengirim function ProcessOngkosKirim ke function HitungOngkosKirim punya Cart
            var ongkosKirim = keranjang.HitungOngkosKirim(20000m, ProcessOngkosKirim);
            Console.WriteLine("Ongkos kirimnya {0}", ongkosKirim);

            /*
             * Multicast Delegates adalah trick untuk menggabungkan lebih dari satu delegates
             * Sehingga multiple delegates atau multiple function bisa dipanggil sekaligus bersamaan.
             */
            Console.WriteLine("=========================== Multicast ===========================");
            AllNotifications();
        }

        public static void HitungTotalHargaBarangAlert(decimal total) {
            string totalString = total.ToString("C2", CultureInfo.CreateSpecificCulture("id-ID"));
            Console.WriteLine("Total Harga Barangnya adalah: {0}", totalString);
        }

        public static void HitungTotalDiskonAlert(decimal total) {
            string totalString = total.ToString("C2", CultureInfo.CreateSpecificCulture("id-ID"));
            Console.WriteLine("Total Diskonnya adalah: {0}", totalString);
        }

        public static void HitungTotalWajibBayarAlert(decimal total) {
            string totalString = total.ToString("C2", CultureInfo.CreateSpecificCulture("id-ID"));
            Console.WriteLine("Total Wajib Bayar adalah: {0}", totalString);
        }

        public static decimal ProcessOngkosKirim(List<Item> items, decimal ongkosKirimAwal) {
            int jumlahBarang = items.Count;
            decimal diskonOngkosKirim = 0.5m;
            decimal totalOngkosKirim = ongkosKirimAwal;
            if (jumlahBarang >= 3) { //apabila membeli lebih dari 3 barang, ongkos kirim di hemat sampai 50%
                totalOngkosKirim = ongkosKirimAwal - (diskonOngkosKirim * ongkosKirimAwal);
            }
            return totalOngkosKirim;
        }

        public static void CashbackNotification(string message) {
            Console.WriteLine(message);
        }

        public static void WelcomeNotes() {
            Console.WriteLine("Selamat datang di Toko online kami.");
        }

        public static void PromotionNotification() {
            Console.WriteLine("Check promo quick sales yang kami tampilkan di halaman sebelah");
        }

        public static void SaldoNotification() {
            Console.WriteLine("Saldo anda saat ini Rp 50.000,-");
        }

        /*
         * Multicast Delegates adalah trick untuk menggabungkan lebih dari satu delegates
         * Sehingga multiple delegates atau multiple function bisa dipanggil sekaligus bersamaan.
         */

        public delegate void ClusterNotification();

        public static void AllNotifications() {
            ClusterNotification welcome, promotion, saldo, multipleNotification;

            welcome = WelcomeNotes;
            promotion = PromotionNotification;
            saldo = SaldoNotification;

            multipleNotification = welcome + promotion + saldo;
            multipleNotification();
        }
    }
}
