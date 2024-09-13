using System;
using System.Collections.Generic;
using System.Text;

namespace AdapterDesignPattern
{
    public class RichCompound : Compound
    {
        private ChemicalDatabank Bank { get; set; }

        public RichCompound(string name) : base(name) {
        }

        public void Set() {
            this.Bank = new ChemicalDatabank();
            this.BoilingPoint = this.Bank.GetCriticalPoint(this.Name, "B");
            this.MeltingPoint = this.Bank.GetCriticalPoint(this.Name, "M");
            this.MolecularWeight = this.Bank.GetMolecularWeight(this.Name);
            this.MolecularFormula = this.Bank.GetMolecularStructure(this.Name);
        }

        public override void Display() {
            Set();
            base.Display();
            Console.WriteLine(" Formula: {0}", this.MolecularFormula);
            Console.WriteLine(" Weight : {0}", this.MolecularWeight);
            Console.WriteLine(" Melting Pt: {0}", this.MeltingPoint);
            Console.WriteLine(" Boiling Pt: {0}", this.BoilingPoint);
        }
    }
}
