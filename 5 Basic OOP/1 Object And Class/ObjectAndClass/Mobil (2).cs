using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectAndClass {
    public class Mobil {
        //Private Field
        private string _type;
        private string _brand;
        private int _tahunProduksi;
        private int _maxSpeed;
        private string _warna;

        /*Property adalah pengganti setter getter method, sehingga pengguna class ini tidak perlu aware akan private field dan method dari class ini.*/
        public string Type {
            get {
                return _type;
            }
            set {
                _type = value;
            }
        }

        public string Brand {
            get {
                return _brand;
            }
            set {
                _brand = value;
            }
        }

        public int TahunProduksi {
            get {
                return _tahunProduksi;
            }
            set {
                _tahunProduksi = value;
            }
        }

        public int MaxSpeed {
            get {
                return _maxSpeed;
            }
            set {
                _maxSpeed = value;
            }
        }

        public string Warna {
            get {
                return _warna;
            }
            set {
                _warna = value;
            }
        }
    }
}
