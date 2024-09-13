using System;
using System.Collections.Generic;
using System.Text;

namespace StateDesignPattern
{
    public abstract class State
    {
        public Account Account { get; set; }
        public double Balance { get; set; }

        protected double Interest { get; set; }
        protected double LowerLimit { get; set; }
        protected double UpperLimit { get; set; }

        public abstract void Deposit(double amount);
        public abstract void Withdraw(double amount);
        public abstract void PayInterest();
    }
}
