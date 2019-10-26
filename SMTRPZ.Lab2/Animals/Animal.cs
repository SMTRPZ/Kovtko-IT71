using System;
using System.Collections.Generic;
using System.Text;

namespace SMTRPZ.Lab2
{
    public abstract class Animal
    {
        public Animal(string name, int foodWeight)
        {
            Name = name;
            FoodWeight = foodWeight;
        }
        public string Name { get; private set; }
        public int FoodWeight { get; private set; }
        public abstract string Speak();
    }
}
