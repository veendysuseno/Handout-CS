using System;
using System.Collections.Generic;
using System.Text;

namespace StateDesignPattern
{
    public class Account
    {
        public State State { get; set; }
        public string Owner { get; set; }

        public double Balance {
            get { return this.State.Balance; }
        }

        public Account(string owner) {
            this.Owner = owner;
            this.State = new SilverState(0.0, this);
        }

        public void Deposit(double amount) {
            this.State.Deposit(amount);
            Console.WriteLine("Deposited {0:C} --- ", amount);
            Console.WriteLine(" Balance = {0:C}", this.Balance);
            Console.WriteLine(" Status = {0}\n", this.State.GetType().Name);
        }

        public void Withdraw(double amount) {
            this.State.Withdraw(amount);
            Console.WriteLine("Withdrew {0:C} --- ", amount);
            Console.WriteLine(" Balance = {0:C}", this.Balance);
            Console.WriteLine(" Status = {0}\n", this.State.GetType().Name);
        }

        public void PayInterest() {
            this.State.PayInterest();
            Console.WriteLine("Interest Paid --- ");
            Console.WriteLine(" Balance = {0:C}", this.Balance);
            Console.WriteLine(" Status = {0}\n", this.State.GetType().Name);
        }
    }
}
