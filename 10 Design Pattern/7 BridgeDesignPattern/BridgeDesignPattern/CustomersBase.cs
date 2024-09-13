using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeDesignPattern
{
    public class CustomersBase
    {
        public DataObject DataObject { get; set; }
        protected string Group { get; set; }

        public CustomersBase(string group) {
            this.Group = group;
        }

        public virtual void Next() {
            this.DataObject.NextRecord();
        }

        public virtual void Prior() {
            this.DataObject.PriorRecord();
        }

        public virtual void Add(string customer) {
            this.DataObject.AddRecord(customer);
        }

        public virtual void Delete(string customer) {
            this.DataObject.DeleteRecord(customer);
        }

        public virtual void Show() {
            this.DataObject.ShowRecord();
        }

        public virtual void ShowAll() {
            Console.WriteLine("Customer Group: " + this.Group);
            this.DataObject.ShowAllRecords();
        }
    }
}
