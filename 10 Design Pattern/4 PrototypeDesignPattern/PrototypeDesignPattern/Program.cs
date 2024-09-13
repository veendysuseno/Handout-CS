using System;

namespace PrototypeDesignPattern
{
    class Program
    {
        static void Main(string[] args) {

            ColorManager colorManager = new ColorManager();
            colorManager.SetColorPrototype("red", new Color(255, 0, 0));
            colorManager.SetColorPrototype("green", new Color(0, 255, 0));
            colorManager.SetColorPrototype("blue", new Color(0, 0, 255));
            colorManager.SetColorPrototype("angry", new Color(255, 54, 0));
            colorManager.SetColorPrototype("peace", new Color(128, 211, 128));
            colorManager.SetColorPrototype("flame", new Color(211, 34, 20));

            Color cloneOfRed = (Color)(colorManager.GetColorPrototype("red").Clone());
            Color cloneOfFlame = (Color)(colorManager.GetColorPrototype("flame").Clone());

            var red = (Color)(colorManager.GetColorPrototype("red"));
            ((Color)(colorManager.GetColorPrototype("red"))).Red = 240;

            Console.WriteLine($"Dari color manager: {((Color)(colorManager.GetColorPrototype("red"))).Red}");
            Console.WriteLine($"Dari object red: { red.Red }");
            Console.WriteLine($"Dari prototype: { cloneOfRed.Red }");

            red.Red = 222;
            Console.WriteLine($"Dari color manager: {((Color)(colorManager.GetColorPrototype("red"))).Red}");
            Console.WriteLine($"Dari object red: { red.Red }");
            Console.WriteLine($"Dari prototype: { cloneOfRed.Red }");
        }
    }
}
