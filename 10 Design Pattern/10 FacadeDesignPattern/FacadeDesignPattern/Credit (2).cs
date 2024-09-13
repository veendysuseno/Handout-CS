using System;
using System.Collections.Generic;
using System.Text;

namespace FacadeDesignPattern
{
    public class Credit
    {
        public bool HasGoodCredit(Customer customer) {
            Console.WriteLine("Check credit for " + customer.Name);
            return true;
        }
    }
}
