using System;

namespace CompositeDesignPattern
{
    class Program
    {
        static void Main(string[] args) {
            CompositeElement root = new CompositeElement("Picture");
            root.Add(new PrimitiveElement("Red Line"));
            root.Add(new PrimitiveElement("Blue Circle"));
            root.Add(new PrimitiveElement("Green Box"));


            CompositeElement composites = new CompositeElement("Two Circles");
            composites.Add(new PrimitiveElement("Black Circle"));
            composites.Add(new PrimitiveElement("White Circle"));
            root.Add(composites);

            PrimitiveElement primitiveElement = new PrimitiveElement("Yellow Line");
            root.Add(primitiveElement);
            root.Remove(primitiveElement);

            root.Display(1);
        }
    }
}
