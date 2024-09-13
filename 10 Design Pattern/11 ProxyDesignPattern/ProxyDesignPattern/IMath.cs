using System;
using System.Collections.Generic;
using System.Text;

namespace ProxyDesignPattern
{
    public interface IMath
    {
        double Add(double x, double y);
        double Substract(double x, double y);
        double Multiply(double x, double y);
        double Divide(double x, double y);
    }
}
