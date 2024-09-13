using System;
using System.Collections.Generic;
using System.Text;

namespace IteratorDesignPattern
{
    public abstract class Aggregate
    {
        public abstract Iterator CreateIterator();
    }
}
