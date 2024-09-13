using System;
using System.Collections.Generic;
using System.Text;

namespace FacadeDesignPattern
{
    public class Bank
    {
        public bool HasSufficientSavings(Customer customer, int amount) {
            Console.WriteLine("Check bank for " + customer.Name);
            return true;
        }
    }
}
