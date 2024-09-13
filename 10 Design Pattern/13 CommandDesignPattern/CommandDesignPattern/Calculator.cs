using System;
using System.Collections.Generic;
using System.Text;

namespace CommandDesignPattern
{
    public class Calculator
    {
        private int Current { get; set; }

        public Calculator() {
            this.Current = 0;
        }

        public void Operation(char operatorCharacter, int operand) {
            switch (operatorCharacter) {
                case '+': 
                    this.Current += operand; 
                    break;
                case '-':
                    this.Current -= operand; 
                    break;
                case '*':
                    this.Current *= operand; 
                    break;
                case '/':
                    this.Current /= operand; 
                    break;
            }
            Console.WriteLine("Current value = {0,3} (following {1} {2})", this.Current, operatorCharacter, operand);
        }
    }
}
