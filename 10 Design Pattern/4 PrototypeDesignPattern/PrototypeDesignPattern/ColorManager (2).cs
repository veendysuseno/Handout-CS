using System;
using System.Collections.Generic;
using System.Text;

namespace PrototypeDesignPattern
{
    public class ColorManager
    {
        public Dictionary<string, ColorPrototype> Colors { get; set; }

        public ColorManager() {
            this.Colors = new Dictionary<string, ColorPrototype>();
        }

        public ColorPrototype GetColorPrototype(string key) {
            return this.Colors[key];
        }

        public void SetColorPrototype(string key, ColorPrototype value) {
            this.Colors[key] = value;
        }
    }
}
