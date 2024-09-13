using System;
using System.Collections.Generic;
using System.Text;

namespace CommandDesignPattern
{
    public class CalculatorCommand : Command
    {
        private char Operator { get; set; }
        private int Operand { get; set; }
        private Calculator Calculator { get; set; }

        public CalculatorCommand(Calculator calculator, char operatorCharacter, int operand) {
            this.Calculator = calculator;
            this.Operator = operatorCharacter;
            this.Operand = operand;
        }

        public override void Execute() {
            this.Calculator.Operation(this.Operator, this.Operand);
        }

        public override void UnExecute() {
            this.Calculator.Operation(Undo(this.Operator), this.Operand);
        }

        private char Undo(char operatorCharacter) {
            switch (operatorCharacter) {
                case '+': 
                    return '-';
                case '-': 
                    return '+';
                case '*': 
                    return '/';
                case '/': 
                    return '*';
                default:
                    throw new ArgumentException("@operator");
            }
        }
    }
}
