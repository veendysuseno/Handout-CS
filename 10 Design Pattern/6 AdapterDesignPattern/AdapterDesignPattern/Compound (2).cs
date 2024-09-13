using System;
using System.Collections.Generic;
using System.Text;

namespace AdapterDesignPattern
{
    public class Compound
    {
        protected string Name { get; set; }
        protected float BoilingPoint { get; set; }
        protected float MeltingPoint { get; set; }
        protected double MolecularWeight { get; set; }
        protected string MolecularFormula { get; set; }

        public Compound(string name) {
            this.Name = name;
        }

        public virtual void Display() {
            Console.WriteLine("\nCompound: {0} ------ ", this.Name);
        }
    }
}
