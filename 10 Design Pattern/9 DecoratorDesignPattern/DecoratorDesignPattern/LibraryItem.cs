using System;
using System.Collections.Generic;
using System.Text;

namespace DecoratorDesignPattern
{
    public abstract class LibraryItem
    {
        public int NumberOfCopies { get; set; }

        public abstract void Display();
    }
}
