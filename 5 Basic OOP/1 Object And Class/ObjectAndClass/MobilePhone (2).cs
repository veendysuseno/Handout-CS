using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectAndClass {
    public class MobilePhone {
        //Private Field
        private string _type;
        private string _brand;
        private string _warna;
        private double _ukuranLayar;
        private int _ramSize;

        //Function constructor
        public MobilePhone(string type, string brand, string warna, double ukuranLayar, int ramSize) {
            this._type = type;
            this._brand = brand;
            this._warna = warna;
            this._ukuranLayar = ukuranLayar;
            this._ramSize = ramSize;
        }

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

        public string Warna {
            get {
                return _warna;
            }
            set {
                _warna = value;
            }
        }

        public double UkuranLayar {
            get {
                return _ukuranLayar;
            }
            set {
                _ukuranLayar = value;
            }
        }

        public int RamSize {
            get {
                return _ramSize;
            }
            set {
                _ramSize = value;
            }
        }
    }
}
