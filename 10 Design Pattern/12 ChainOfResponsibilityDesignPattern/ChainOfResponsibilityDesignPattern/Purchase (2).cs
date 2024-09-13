using System;
using System.Collections.Generic;
using System.Text;

namespace ChainOfResponsibilityDesignPattern
{
    public class Purchase
    {
        public int Number { get; set; }
        public double Amount { get; set; }
        public string Purpose { get; set; }

        public Purchase(int number, double amount, string purpose) {
            this.Number = number;
            this.Amount = amount;
            this.Purpose = purpose;
        }
    }
}
