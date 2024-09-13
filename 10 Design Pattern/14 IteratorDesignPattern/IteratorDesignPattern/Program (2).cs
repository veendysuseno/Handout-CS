using System;

namespace IteratorDesignPattern
{
    class Program
    {
        static void Main(string[] args) {
            ConcreteAggregate aggregator = new ConcreteAggregate();
            aggregator.SetItem(0, "Item A");
            aggregator.SetItem(1, "Item B");
            aggregator.SetItem(2, "Item C");
            aggregator.SetItem(3, "Item D");

            Iterator iterator = aggregator.CreateIterator();

            Console.WriteLine("Iterating over collection:");
            string item = iterator.First();
            while (item != null) {
                Console.WriteLine(item);
                item = iterator.Next();
            }
        }
    }
}
