using System;
using System.Collections.Generic;
using System.Text;

namespace DecoratorDesignPattern
{
    public abstract class Decorator : LibraryItem
    {
        protected LibraryItem Item { get; set; }

        public Decorator(LibraryItem item) {
            this.Item = item;
        }

        public override void Display() {
            this.Item.Display();
        }
    }
}
