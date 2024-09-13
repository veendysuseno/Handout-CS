using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IteratorDesignPattern
{
    public class ConcreteAggregate : Aggregate
    {
        private List<string> Items { get; set; }

        public ConcreteAggregate() {
            this.Items = new List<string>();
        }

        public override Iterator CreateIterator() {
            return new ConcreteIterator(this);
        }

        public int Count {
            get { return this.Items.Count; }
        }

        public string GetItem(int index) {
            return this.Items[index];
        }

        public void SetItem(int index, string value) {
            this.Items.Insert(index, value);
        }
    }
}
