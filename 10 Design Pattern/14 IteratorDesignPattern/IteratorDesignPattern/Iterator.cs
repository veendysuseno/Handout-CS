using System;
using System.Collections.Generic;
using System.Text;

namespace IteratorDesignPattern
{
    public abstract class Iterator
    {
        public abstract string First();
        public abstract string Next();
        public abstract bool IsDone();
        public abstract string CurrentItem();
    }
}
