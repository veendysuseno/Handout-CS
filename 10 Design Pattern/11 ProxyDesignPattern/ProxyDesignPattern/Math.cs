using System;
using System.Collections.Generic;
using System.Text;

namespace ProxyDesignPattern
{
    public class Math : IMath
    {
        public double Add(double x, double y) { 
            return x + y; 
        }
        public double Substract(double x, double y) { 
            return x - y; 
        }
        public double Multiply(double x, double y) { 
            return x * y; 
        }
        public double Divide(double x, double y) { 
            return x / y; 
        }
    }
}
