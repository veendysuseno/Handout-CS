using System;
using System.Collections.Generic;
using System.Text;

namespace CompositeDesignPattern
{
    public class CompositeElement : DrawingElement
    {
        public List<DrawingElement> Elements { get; set; }

        public CompositeElement(string name) : base(name) {
            this.Elements = new List<DrawingElement>();
        }

        public override void Add(DrawingElement drawingElement) {
            this.Elements.Add(drawingElement);
        }

        public override void Remove(DrawingElement drawingElement) {
            this.Elements.Remove(drawingElement);
        }

        public override void Display(int indent) {
            Console.WriteLine(new String('-', indent) + "+ " + this.Name);

            foreach (DrawingElement element in this.Elements) {
                element.Display(indent + 2);
            }
        }
    }
}
