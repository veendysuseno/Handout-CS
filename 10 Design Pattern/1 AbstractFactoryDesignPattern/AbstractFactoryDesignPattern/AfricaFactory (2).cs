using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactoryDesignPattern
{
    public class AfricaFactory : ContinentFactory
    {
        public override Carnivore CreateCarnivore() {
            return new Lion();
        }

        public override Herbivore CreateHerbivore() {
            return new Wildebeest();
        }
    }
}
