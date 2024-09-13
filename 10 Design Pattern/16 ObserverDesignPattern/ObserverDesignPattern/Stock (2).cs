using System;
using System.Collections.Generic;
using System.Text;

namespace ObserverDesignPattern
{
    public abstract class Stock
    {
        public string Symbol { get; set; }
        private double _price;
        public List<IInvestor> Investors { get; set; }

        public double Price {
            get { return this._price; }
            set {
                if (this._price != value) {
                    this._price = value;
                    Notify();
                }
            }
        }

        public Stock(string symbol, double price) {
            this.Symbol = symbol;
            this.Price = price;
            this.Investors = new List<IInvestor>();
        }

        public void Attach(IInvestor investor) {
            this.Investors.Add(investor);
        }

        public void Detach(IInvestor investor) {
            this.Investors.Remove(investor);
        }

        public void Notify() {
            foreach (IInvestor investor in this.Investors) {
                investor.Update(this);
            }
            Console.WriteLine("Notification!");
        }

    }
}
