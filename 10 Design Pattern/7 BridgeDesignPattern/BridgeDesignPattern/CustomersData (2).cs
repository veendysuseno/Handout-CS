using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeDesignPattern
{
    public class CustomersData : DataObject
    {
        public List<string> Customers { get; set; }
        public int Current { get; set; }

        public CustomersData() {
            this.Customers = new List<string>();
            this.Current = 0;
            this.Customers.Add("Jim Jones");
            this.Customers.Add("Samual Jackson");
            this.Customers.Add("Allen Good");
            this.Customers.Add("Ann Stills");
            this.Customers.Add("Lisa Giolani");
        }

        public override void NextRecord() {
            if (this.Current <= this.Customers.Count - 1) {
                this.Current++;
            }
        }

        public override void PriorRecord() {
            if (this.Current > 0) {
                this.Current--;
            }
        }

        public override void AddRecord(string customer) {
            Customers.Add(customer);
        }

        public override void DeleteRecord(string customer) {
            Customers.Remove(customer);
        }

        public override void ShowRecord() {
            Console.WriteLine(Customers[Current]);
        }

        public override void ShowAllRecords() {
            foreach (string customer in this.Customers) {
                Console.WriteLine(" " + customer);
            }
        }
    }
}
