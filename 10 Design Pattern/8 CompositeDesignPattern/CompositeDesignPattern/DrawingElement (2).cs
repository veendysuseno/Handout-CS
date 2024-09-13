using System;
using System.Collections.Generic;
using System.Text;

namespace CompositeDesignPattern
{
    public abstract class DrawingElement
    {
        protected string Name { get; set; }

        public DrawingElement(string name) {
            this.Name = name;
        }

        public abstract void Add(DrawingElement drawingElement);
        public abstract void Remove(DrawingElement drawingElement);
        public abstract void Display(int indent);
    }
}
