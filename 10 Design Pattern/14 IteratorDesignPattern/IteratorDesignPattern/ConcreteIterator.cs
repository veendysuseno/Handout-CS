using System;
using System.Collections.Generic;
using System.Text;

namespace IteratorDesignPattern
{
    public class ConcreteIterator : Iterator
    {
        private ConcreteAggregate Aggregate { get; set; }
        private int Current { get; set; }

        public ConcreteIterator(ConcreteAggregate aggregate) {
            this.Aggregate = aggregate;
            this.Current = 0;
        }

        public override string First() {
            return this.Aggregate.GetItem(0);
        }

        public override string Next() {
            string value = null;
            if (this.Current < this.Aggregate.Count - 1) {
                value = this.Aggregate.GetItem(++this.Current);
            }
            return value;
        }

        public override string CurrentItem() {
            return this.Aggregate.GetItem(this.Current);
        }

        public override bool IsDone() {
            return this.Current >= this.Aggregate.Count;
        }
    }
}
