﻿using System;

namespace AbstractFactoryDesignPattern
{
    class Program
    {
        static void Main(string[] args) {
            ContinentFactory africa = new AfricaFactory();
            AnimalWorld world = new AnimalWorld(africa);
            world.RunFoodChain();

            ContinentFactory america = new AmericaFactory();
            world = new AnimalWorld(america);
            world.RunFoodChain();
        }
    }
}
