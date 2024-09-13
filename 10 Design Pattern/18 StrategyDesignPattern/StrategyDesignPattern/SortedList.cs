using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyDesignPattern
{
    public class SortedList
    {
        private List<string> List { get; set; }
        private SortStrategy SortStrategy { get; set; }

        public void SetSortStrategy(SortStrategy sortstrategy) {
            this.SortStrategy = sortstrategy;
            this.List = new List<string>();
        }

        public void Add(string name) {
            this.List.Add(name);
        }

        public void Sort() {
            this.SortStrategy.Sort(this.List);
            foreach (string name in this.List) {
                Console.WriteLine(" " + name);
            }
            Console.WriteLine();
        }
    }
}
