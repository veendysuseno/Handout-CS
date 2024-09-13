using System;
using System.Collections.Generic;
using System.Text;

namespace ObserverDesignPattern
{
    public class Investor : IInvestor
    {
        private string Name { get; set; }
        public Stock Stock { get; set; }

        public Investor(string name) {
            this.Name = name;
        }

        public void Update(Stock stock) {
            Console.WriteLine("Notified {0} of {1}'s change to {2:C}", this.Name, stock.Symbol, stock.Price);
        }
    }
}
