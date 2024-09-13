using System;
using System.Collections.Generic;
using System.Text;

namespace StateDesignPattern
{
    public class RedState : State
    {
        private double ServiceFee { get; set; }

        public RedState(State state) {
            this.Balance = state.Balance;
            this.Account = state.Account;
            Initialize();
        }

        private void Initialize() {
            this.Interest = 0.0;
            this.LowerLimit = -100.0;
            this.UpperLimit = 0.0;
            this.ServiceFee = 15.00;
        }

        public override void Deposit(double amount) {
            this.Balance += amount;
            StateChangeCheck();
        }

        public override void Withdraw(double amount) {
            amount = amount - this.ServiceFee;
            Console.WriteLine("No funds available for withdrawal!");
        }

        public override void PayInterest() {

        }

        private void StateChangeCheck() {
            if (this.Balance > this.UpperLimit) {
                this.Account.State = new SilverState(this);
            }
        }
    }
}
