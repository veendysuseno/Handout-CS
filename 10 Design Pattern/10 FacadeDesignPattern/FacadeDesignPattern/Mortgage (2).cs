using System;
using System.Collections.Generic;
using System.Text;

namespace FacadeDesignPattern
{
    public class Mortgage
    {
        private Bank Bank { get; set; }
        private Loan Loan { get; set; }
        private Credit Credit { get; set; }

        public Mortgage() {
            this.Bank = new Bank();
            this.Loan = new Loan();
            this.Credit = new Credit();
        }

        public bool IsEligible(Customer customer, int amount) {
            Console.WriteLine("{0} applies for {1:C} loan\n", customer.Name, amount);

            bool eligible = true;
            if (!this.Bank.HasSufficientSavings(customer, amount)) {
                eligible = false;
            } else if (!this.Loan.HasNoBadLoans(customer)) {
                eligible = false;
            } else if (!this.Credit.HasGoodCredit(customer)) {
                eligible = false;
            }

            return eligible;
        }
    }
}
