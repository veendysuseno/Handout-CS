using System;
using System.Collections.Generic;
using System.Text;

namespace PrototypeDesignPattern
{
    public class Color : ColorPrototype
    {
        public int Red { get; set; }
        public int Green { get; set; }
        public int Blue { get; set; }

        public Color(int red, int green, int blue) {
            this.Red = red;
            this.Green = green;
            this.Blue = blue;
        }

        public override ColorPrototype Clone() {
            Console.WriteLine("Cloning color RGB: {0,3},{1,3},{2,3}", this.Red, this.Green, this.Blue);
            ColorPrototype prototype = (ColorPrototype)(this.MemberwiseClone());
            return prototype;
        }

    }
}
