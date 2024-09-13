using System;
using System.Collections.Generic;
using System.Text;

namespace ProxyDesignPattern
{
    public class MathProxy : IMath
    {
        private Math Math { get; set; }

        public MathProxy() {
            this.Math = new Math();
        }

        public double Add(double x, double y) {
            return this.Math.Add(x, y);
        }
        public double Substract(double x, double y) {
            return this.Math.Substract(x, y);
        }
        public double Multiply(double x, double y) {
            return this.Math.Multiply(x, y);
        }
        public double Divide(double x, double y) {
            return this.Math.Divide(x, y);
        }
    }
}
