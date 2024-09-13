using System;
using System.Collections.Generic;
using System.Text;

namespace DecoratorDesignPattern
{
    public class Borrowable : Decorator
    {
        public List<string> Borrowers { get; set; }

        public Borrowable(LibraryItem item) : base(item) {
            this.Borrowers = new List<string>();
        }

        public void BorrowItem(string name) {
            this.Borrowers.Add(name);
            this.Item.NumberOfCopies--;
        }

        public void ReturnItem(string name) {
            this.Borrowers.Remove(name);
            this.Item.NumberOfCopies++;
        }

        public override void Display() {
            base.Display();

            foreach (string borrower in this.Borrowers) {
                Console.WriteLine(" borrower: " + borrower);
            }
        }
    }
}
