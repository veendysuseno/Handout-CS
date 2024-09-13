using System;
using System.Threading;

namespace WhyThreadPool
{
    /*
     * Sebelum mempelajari Thread Pool, kita akan bahas dulu beberapa teori mengenai hubungan antara thread dengan processor core.
     * 
     * 
     * ================================================ CPU CORES AND LOGICAL PROCESSORS ========================================================================
     * 
     * CPU / Processor pada PC atau Server kalian bisa memiliki 1 Core (Single Core Processor) atau memiliki 2 atau lebih Core (Multi-Core Processor).
     * Dimana jumlah core pada processor ini akan mempengaruhi cara kerja Thread kalian.
     * 
     * Mari kita check berapa core yang ada pada processor kalian. (Ini untuk windows)
     * Pergi ke Task Manager > Performance > CPU
     * 
     * Coba perhatikan, di situ ada 2 hal, yang pertama ada Cores dan yang kedua ada Logical Processors.
     * Apabila misalnya terdapat 4 Cores dan 8 Logical Processors, itu artinya setiap Cores memiliki 2 Logical Processors.
     * Kalau misalnya terdapat 6 Cores dan 6 Logical Processors, itu artinya setiap Cores memiliki 1 Logical Processors.
     * 
     * Cores adalah inti dari processor anda yang sifatnya physical.
     * Logical Processors adalah yang bertanggung jawab langsung menangani thread-thread yang ada di setiap aplikasi.
     * 
     * Kalian bisa memantau performa logical processors dengan cara:
     * Click kanan > Change Graph To > Logical Processor.
     * 
     * Kita juga bisa melihat Threads yang sedang berjalan dari OS dan seluruh aplikasi atau service yang berjalan di pc kalian dengan cara:
     * Task Manager > Performance > Open Resource Monitor > CPU > Threads.
     * 
     * 
     * =============================================================== IDEAL THREADS ============================================================================
     * 
     * Dari sini kita tau kalau 1 logical processor bisa menangani lebih dari 1 thread untuk aplikasi C# kita. Tetapi 1 Thread kita tidak bisa kerjakan oleh 2 atau lebih logical processors.
     * Tapi idealnya 1 logical processors lebih baik mengerjakan 1 thread dari aplikasi kita, Mengapa?
     * 
     * Saya perumpamakan bahwa CPU kita adalah customer services sebuah cabang kantor sebuah bank.
     * Saat saya memiliki 4 Cores, itu artinya ada 4 meja registrasi.
     * Ketika saya memiliki 8 Logical Processors, itu artinya di setiap meja registrasi ada 2 customer service staff.
     * 
     * Ketika customer berdatangan dengan membawa permintaan atau keluhan, di situlah adanya Thread.
     * 1 customer adalah 1 thread. 
     * Dan setiap permintaan yang dibawa oleh customer memiliki berat eksekusi yang berbeda-beda tergantung dari code kita.
     * 
     * Tentunya idealnya adalah 1 customer service staff menangani 1 customer.
     * Artinya 1 Logical Processor menangani 1 Thread.
     * Tetapi kita bisa memaksa aplikasi kita untuk melakukan asynchronous lebih dari jumlah logical processors yang ada.
     * Itu artinya ada beberapa customer services yang dipaksa menangani lebih dari 1 customers sekaligus.
     * 
     * Seperti layaknya manusia, logical processors bila dipaksa melakukan multi-tasking, konsentrasi dan performancenya akan terbagi.
     * Di situlah peran Thread Priority, dimana kita bisa memerintahkan customer service untuk menangani customer yang lebih penting dahulu.
     * Tetapi ada akibatnya, dengan memprioritaskan 1 customer prioritas, customer yang non prioritas akan di korbankan, sehingga terjadi persaingan
     * di dalam satu logical processor.
     * 
     * Jadi bisa disimpulkan, apabila processor kita memiliki 1 logical processors, melakukan membuat multi-threading code tidak akan menambah performance, walaupun bisa asynchronous.
     * Apabila kita memiliki multi logical processor, menulis code di atas main thread akan membuat sisa logical processor menganggur.
     * Kalau di sesuaikan dengan perumpamaan tadi, bisa dibilang hanya 1 customer service staff yang bekerja, sisanya menganggur, karena hanya ada 1 customer yang datang, tetapi
     * request yang dimintanya sangat panjang dan harus dikerjakan satu-persatu secara berurutan.
     * 
     * 
     * ============================================================= BAHAYA MULTI-TASKING LOGICAL PROCESSORS =======================================================
     * 
     * Ada bahaya lain yang bisa diakibatkan kalau 1 logical processor kita melakukan terlalu banyak thread selain performance yang turun.
     * Pada OS di PC kita, ada yang disebut dengan Time Slice.
     * Time Slice ini bisa berbeda antara jenis OS, versinya atau bahkan mungkin updatenya, dimana saya juga tidak tau persis.
     * 
     * Time Slice adalah periode waktu yang diberikan OS pada sebuah thread untuk memakai sebuah logical processors.
     * Misalnya saja time slice OS kita adalah 20 milliseconds, itu artinya kalau 1 logical processor kita tidak bisa menyelesaikan sebuah thread dalam waktu 20 ms, dia akan
     * berhenti mengerjakan thread tersebut dan dia akan beralih ke thread lainnya yang sedang dia urus sekarang.
     * 
     * Kita ibaratkan kembali dengan perumpamaan. Apabila 1 customer service staff anda mengurusi 3 customer sekaligus, misalnya Customer A, Customer B dan Customer C sekaligus.
     * Lalu time slice setiap customer anda adalah 30 menit (karena manusia tidak mungkin kita kasih 20 ms).
     * Itu artinya kalau customer service anda saat ini fokus mengurusi Customer A, dan setelah 30 menit request Customer A belum juga selesai dipenuhi, 
     * customer service staff anda selesai tidak selesai harus mengalihkan konsentrasinya ke Customer B.
     * Apabila setelah setengah jam belum selesai juga mengurusi Customer B, maka akan beralih ke Customer C.
     * 
     * Kalau permintaan Customer C selesai dalam waktu 5 menit, maka Customer C akan pulang dan menjadi thread yang tidak aktif.
     * Lalu customer service staff anda akan kembali beralih ke Customer A yang tadi urusannya belum selesai.
     * Customer service anda pertama-tama akan check sampai dimana tadi mengerjakan request customer A, dan oh ternyata tinggal sedikit lagi.
     * Lalu customer service staff anda akan melanjutkan pekerjaannya dan bisa menyelesaikan permintaan Customer A dalam waktu 3 menit.
     * Selanjutnya bisa kalian perkirakan, customer service staff anda akan lanjut melunasi hutangnya ke Customer B.
     * 
     * Tindakan sebuah Logical Processor untuk meninggalkan Thread yang belum selesai dikerjakan (Seperti customer service staff anda meninggalkan Customer A dan beralih ke Customer B),
     * disebut juga sebagai Preemption atau Preemptive Action.
     * Tindakan memindah-mindahkan fokus Logical Processor ke Thread lain disebut juga Context-Switch.
     * 
     * Di sini kalian bisa ambil kesimpulan, sebenarnya 1 logical processor tidak bisa benar-benar multi-tasking. Sama selayaknya customer service staff anda yang manusia,
     * otaknya tidak benar-benar sanggup multi tasking. Mereka hanya melakukan switch antar context atau antar thread yang seolah-olah multi-tasking karena berlangsung selama 20ms.
     * Kalau pekerjaanya ringan bisa switch lebih kecil dari 20ms (Contohnya seperti Customer C yang requestnya tidak berat).
     * 
     * Lalu apa bahaya lebihnya?
     * Pernahkah kalian melakukan multi-tasking seperti customer service staff dalam perumpamaan?
     * Misalnya saja kalian mengerjakan 2 atau 3 project yang berbeda dalam waktu yang bersamaan.
     * Atau kalian menonton Serial TV dengan 7 film yang berbeda bergantian dalam waktu yang relative bersamaan.
     * Maka kalian akan lost in track, kalian lupa sampai dimana project A dikerjakan karena fokusnya mengerjakan project B.
     * Lalu ketika kalian kembali kerjakan project A, maka kalian akan kembali kagok mengerjakan project B dan C.
     * Seperti menonton TV serial, kalian harus ingat-ingat lagi nama tokoh-tokoh di ceritanya, sampai di episode mana dan apa konflik-konflik yang dialami setiap tokoh.
     * 
     * "Ingat-ingat lagi sampai dimana", itulah yang saya mau bahas. Berarti di dalam tindakan switch antar pekerjaan ini, kalian membutuhkan memory untuk mengingat-ingat.
     * Thread atau pekerjaan yang belum selesai harus disimpan informasi sampai dimana dikerjakan, dan juga ketika kembali ke thread tersebut logical processor membutuhkan waktu
     * untuk mereview last track dia.
     * 
     * 
     * ================================================== EXPENSIVE CONTEXT SWITCH dan OVERSUBSCRIPTION ====================================================
     * 
     * Ketika PC kalian menderita performance karena context switch berlebihan dikarenakan terlalu banyak thread yang sedang dikerjakan, maka aplikasi anda bisa dinilai
     * mengalami oversubscription, dan performance penalty yang diakibatkan karena switch context malah memperlambat performance.
     * 
     * Oversubscription adalah membuat terlalu banyak membuat active thread yang jumlahnya jauh melebihi logical processor kalian.
     * Terlalu banyaknya kegiatan Context Switch bisa dikatakan sebagai Expensive Context Switch.
     * 
     * Detailnya ini adalah proses menderitanya Expensive Context Switch:
     * 
     * 1. Ketika Logical Processor anda fokus mengerjakan 1 thread, performancenya akan terus meningkat, sama seperti ketika kalian fokus mengerjakan satu pekerjaan,
     * short-term memory di otak kalian masih sangat fresh terhadap pekerjaan ini, dan kalian tidak gampang lupa terhadap progressnya. Short-term memory pada Logical Processor ini
     * disebut juga dengan CPU Cache. CPU Cache akan invalidate atau dibuang setiap kali logical processor kalian meninggalkan thread tersebut dan beralih ke yang lain.
     * 
     * 2. Memory sampai dimana thread tersebut dikerjakan tidak bisa disimpan dalam CPU Cache, melainkan akan disimpan sebagai State di dalam RAM kalian.
     * Sehingga menyebabkan tidak hanya menderita di CPU, tetapi di RAM juga.
     * 
     * 3. Ketika fokus logical processor kembali ke thread yang tadi, CPU cache mulai dibentuk lagi ("Ingat-ingat sampai dimana"). Dan ini akan memakan extra performance lagi.
     * 
     * 4. Membaca, menganalisa dan memilih next thread sesuai dengan prioritynya setiap kali context switch. Apabila priority di set manual di code kalian, maka logical processor akan
     * membaca itu, bila tidak di set manual maka logical processor akan melakukan analisanya sendiri dan memilihnya secara otomatis yang di anggap penting oleh logical processor kalian.
     * Baik manual ataupun otomatis, kegiatan ini akan memakan effort dan performance lagi.
     * 
     * 
     * ======================================================== SOLUTION FROM PREVIOUS PROBLEM ================================================================
     * 
     * Di sini kita bisa merumuskan beberapa solusi untuk masalah customer services dalam perumpamaan:
     * 1. Dibuatnya aturan mengantri, sehingga customer service tidak perlu pusing mengurusi banyak customer yang duduk di depan dia.
     * 2. Maximum customer yang dihandle saat ini sejumlah customer service staffnya.
     * 3. Mengurangi context switch, sehingga antrian disusun sedemikian rupa sesuai dengan panjang tasknya dan antrian dibagikan seadil-adilnya untuk setiap customer service staff,
     * agar mereka bisa selesai bersamaan sebisa mungkin.
     * 
     * Tetapi di sini kita memiliki beberapa kesulitan untuk melakukan tersebut di dalam code, karena:
     * Solusi 1: bagaimana cara membuat antriannya di dalam code? Kalau kita manual dengan menggunakan signal dan join akan sangat rumit sekali.
     * Solusi 2: untuk mengetahui maximum thread yang bisa dihandle oleh logical processor, kita harus terlebih dahulu tau jumlah logical processor pada PC.
     *      Sedangkan setiap PC berbeda-beda jumlahnya. Kita ingin agar aplikasi kita bersifat dinamis, sehingga pada pc 6 logical processor, kita akan membuat 6 thread yang di urus dalam satu waktu,
     *      tetapi pada pc dengan 8 logical processor akan diurus 8 dalam satu waktu. Bagaimana caranya?
     * Solusi 3: bagaimana kita bisa menyusun sedimikan rupa agar setiap logical processor mendapat proporsi yang sifatnya equality.
     * 
     * Jawabannya hanya 1, yaitu dengan menggunakan Thread Pool. Thread Pool akan secara otomatis membuatkan system antrian (Que), secara otomatis membaca jumlah logical processor pada pc, dan
     * menyusun antrian thread dengan menggunakan Hill Climbing Algorithm yang kalian tinggal nikmati saja.
     * 
     * Sebagai bonusnya, ThreadPool juga akan membuatkan recycle thread, dimana total thread yang dibuat hanya sejumlah logical processornya saja.
     * Jadi yang mengantri hanya processnya saja. Proses pada antrian akan diambil oleh thread yang sama lagi.
     */

    class Program
    {
        static void Main(string[] args) {
            /*
             * Uncomment satu persatu thread untuk melihat hasilnya.
             */
            ThreadPoolVsManualThread();
            //ParameterizedThreadPool();
            //InvokeWithCallback();
        }

        public static void ThreadPoolVsManualThread() {
            for (int index = 0; index < 20; index++) {
                ThreadPool.QueueUserWorkItem(PrintThreadPool);
            }
            /*
                ThreadPool dieksekusi dengan memasukan delegasi fungsi ke dalam method QueueUserWorkItem() milik ThreadPool.
                Perhatikan seluruh ThreadId hasil print contoh hasil di atas.

                Banyak Id akan sama seperti jumlah logical processor pada PC kamu, misalnya hasil saya:
                Thread ID:9, Apakah Thread ini adalah Thread Pool:True
                Thread ID:8, Apakah Thread ini adalah Thread Pool:True
                Thread ID:6, Apakah Thread ini adalah Thread Pool:True
                Thread ID:6, Apakah Thread ini adalah Thread Pool:True
                Thread ID:10, Apakah Thread ini adalah Thread Pool:True
                Thread ID:10, Apakah Thread ini adalah Thread Pool:True
                Thread ID:10, Apakah Thread ini adalah Thread Pool:True
                Thread ID:10, Apakah Thread ini adalah Thread Pool:True
                Thread ID:10, Apakah Thread ini adalah Thread Pool:True
                Thread ID:10, Apakah Thread ini adalah Thread Pool:True
                Thread ID:10, Apakah Thread ini adalah Thread Pool:True
                Thread ID:10, Apakah Thread ini adalah Thread Pool:True
                Thread ID:10, Apakah Thread ini adalah Thread Pool:True
                Thread ID:11, Apakah Thread ini adalah Thread Pool:True
                Thread ID:7, Apakah Thread ini adalah Thread Pool:True
                Thread ID:9, Apakah Thread ini adalah Thread Pool:True
                Thread ID:8, Apakah Thread ini adalah Thread Pool:True
                Thread ID:5, Apakah Thread ini adalah Thread Pool:True
                Thread ID:6, Apakah Thread ini adalah Thread Pool:True
                Thread ID:4, Apakah Thread ini adalah Thread Pool:True

                Di sini ada 8 Id: 4, 5, 6, 7, 8, 9, 10, 11
                Dikarenakan PC saya memiliki 8 parallel process thread poolnya hanya menghasilkan 8 thread.
                Thread degan Id yang sama digunakan berulang.
             */

            new Thread(() => {
                Console.WriteLine($"Thread ID:{Thread.CurrentThread.ManagedThreadId}, Apakah Thread ini adalah Thread Pool:{Thread.CurrentThread.IsThreadPoolThread}");
            }).Start();
            //IsThreadPoolThread digunakan untuk menginformasikan apakah thread ini termasuk thread pool atau bukan.
            Thread.Sleep(2000);

            /*
             * Di sini main thread saya sleep selama 2 detik dengan tujuan menunggu agar threadpool selesai dijalankan.
             * Kenapa harus menunggu? Itu dikarenakan seluruh ThreadPool sudah pasti adalah Background Thread, sehingga apabila main thread kita terlalu cepat selesai,
             * background thread akan dilewati selesai atau tidak selesai.
             */
        }

        /// <summary>
        /// Untuk penulisan parameterized thread pool seperti di bawah ini.
        /// </summary>
        public static void ParameterizedThreadPool() {
            ThreadPool.QueueUserWorkItem(PrintThreadPool);
            ThreadPool.QueueUserWorkItem(PrintName, "Agus");
            ThreadPool.QueueUserWorkItem(PrintPerson, new Person { Name = "Hendra", Country = "Indonesia" });
            Thread.Sleep(2000);
        }

        /// <summary>
        /// Di bawah ini adalah contoh penulisan methode yang lama.
        /// </summary>
        public static void InvokeWithCallback() {
            ThreadPool.QueueUserWorkItem(new WaitCallback(PrintThreadPool));
            ThreadPool.QueueUserWorkItem(new WaitCallback(PrintName), "Agus");
            ThreadPool.QueueUserWorkItem(new WaitCallback(PrintPerson), new Person { Name = "Hendra", Country = "Indonesia" });
            Thread.Sleep(2000);
        }

        /// <summary>
        /// Setiap function yang akan tambahkan ke dalam thread pool harus memiliki parameter object, walaupun tidak ada parameter sekalipun.
        /// Itu dikarenakan signature delegates di dalam threadpool sudah memiliki object parameter.
        /// </summary>
        /// <param name="stateInfo"></param>
        public static void PrintThreadPool(object stateInfo) {
            Console.WriteLine($"Thread ID:{Thread.CurrentThread.ManagedThreadId}, Apakah Thread ini adalah Thread Pool:{Thread.CurrentThread.IsThreadPoolThread}");
        }

        public static void PrintName(object namaArgs) {
            string nama = (string)namaArgs;
            Console.WriteLine($"Hello {namaArgs}");
        }

        public static void PrintPerson(object personArgs) {
            var person = (Person)personArgs;
            Console.WriteLine($"Nama: {person.Name}, Negara asal: {person.Country}");
        }

    }
}
