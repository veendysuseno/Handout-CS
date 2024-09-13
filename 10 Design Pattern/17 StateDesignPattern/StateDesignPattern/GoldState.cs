using System;
using System.Collections.Generic;
using System.Text;

namespace StateDesignPattern
{
    public class GoldState : State
    {
        public GoldState(State state) : this(state.Balance, state.Account) {

        }

        public GoldState(double balance, Account account) {
            this.Balance = balance;
            this.Account = account;
            Initialize();
        }

        private void Initialize() {
            this.Interest = 0.05;
            this.LowerLimit = 1000.0;
            this.UpperLimit = 10000000.0;
        }

        public override void Deposit(double amount) {
            this.Balance += amount;
            StateChangeCheck();
        }

        public override void Withdraw(double amount) {
            this.Balance -= amount;
            StateChangeCheck();
        }

        public override void PayInterest() {
            this.Balance += this.Interest * this.Balance;
            StateChangeCheck();
        }

        private void StateChangeCheck() {
            if (this.Balance < 0.0) {
                this.Account.State = new RedState(this);
            } else if (this.Balance < this.LowerLimit) {
                this.Account.State = new SilverState(this);
            }
        }
    }
}
