﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ChainOfResponsibilityDesignPattern
{
    public class Director : Approver
    {
        public override void ProcessRequest(Purchase purchase) {
            if (purchase.Amount < 10000.0) {
                Console.WriteLine("{0} approved request# {1}", this.GetType().Name, purchase.Number);
            } else if (this.Successor != null) {
                this.Successor.ProcessRequest(purchase);
            }
        }
    }
}
