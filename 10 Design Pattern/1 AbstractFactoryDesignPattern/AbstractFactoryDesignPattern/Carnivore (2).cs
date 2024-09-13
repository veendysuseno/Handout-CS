using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactoryDesignPattern
{
    public abstract class Carnivore
    {
        public abstract void Eat(Herbivore h);
    }
}
