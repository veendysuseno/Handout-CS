using System;
using System.Collections.Generic;
using System.Text;

namespace ChainOfResponsibilityDesignPattern
{
    public abstract class Approver
    {
        protected Approver Successor { get; set; }

        public void SetSuccessor(Approver successor) {
            this.Successor = successor;
        }

        public abstract void ProcessRequest(Purchase purchase);
    }
}
