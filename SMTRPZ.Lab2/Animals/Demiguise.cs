using System;
using System.Collections.Generic;
using System.Text;

namespace SMTRPZ.Lab2
{
    public class Demiguise : Animal
    {
        public Demiguise(string name, int foodWeight) : base(name, foodWeight)
        {
        }

        public override string Speak()
        {
            return "I am that weird white hairy thing, my name is " + Name + ". My food weight is " + FoodWeight + "\n";
        }
    }
}
