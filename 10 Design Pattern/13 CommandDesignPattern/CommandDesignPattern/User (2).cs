using System;
using System.Collections.Generic;
using System.Text;

namespace CommandDesignPattern
{
    public class User
    {
        private Calculator Calculator { get; set; }
        private List<Command> Commands { get; set; }
        private int Current { get; set; }

        public User() {
            this.Calculator = new Calculator();
            this.Commands = new List<Command>();
            this.Current = 0;
        }

        public void Redo(int levels) {
            Console.WriteLine("\n---- Redo {0} levels ", levels);
            for (int i = 0; i < levels; i++) {
                if (this.Current < this.Commands.Count - 1) {
                    Command command = this.Commands[this.Current++];
                    command.Execute();
                }
            }
        }

        public void Undo(int levels) {
            Console.WriteLine("\n---- Undo {0} levels ", levels);
            for (int i = 0; i < levels; i++) {
                if (this.Current > 0) {
                    Command command = this.Commands[--this.Current];
                    command.UnExecute();
                }
            }
        }

        public void Compute(char operatorCharacter, int operand) {
            Command command = new CalculatorCommand(this.Calculator, operatorCharacter, operand);
            command.Execute();
            this.Commands.Add(command);
            this.Current++;
        }
    }
}
