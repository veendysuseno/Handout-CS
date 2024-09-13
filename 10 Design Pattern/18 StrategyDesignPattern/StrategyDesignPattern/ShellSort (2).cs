using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyDesignPattern
{
    public class ShellSort : SortStrategy
    {
        public override void Sort(List<string> list) {
            //list.ShellSort(); not-implemented
            Console.WriteLine("ShellSorted list ");
        }
    }
}
