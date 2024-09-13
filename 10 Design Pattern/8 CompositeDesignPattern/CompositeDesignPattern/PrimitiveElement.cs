using System;
using System.Collections.Generic;
using System.Text;

namespace CompositeDesignPattern
{
    public class PrimitiveElement : DrawingElement
    {
        public PrimitiveElement(string name) : base(name) {
        }

        public override void Add(DrawingElement drawingElement) {
            Console.WriteLine("Cannot add to a PrimitiveElement");
        }

        public override void Remove(DrawingElement drawingElement) {
            Console.WriteLine("Cannot remove from a PrimitiveElement");
        }

        public override void Display(int indent) {
            Console.WriteLine(new String('-', indent) + " " + this.Name);
        }
    }
}
