using System;
using System.Collections.Generic;
using System.Text;

namespace SMTRPZ.Lab2
{
    public class Occamy : Animal
    {
        public Occamy(string name, int foodWeight) : base(name, foodWeight)
        {
        }

        public override string Speak()
        {
            return "I am that tiny dragon thing, my name is " + Name + ". My food weight is " + FoodWeight + "\n";
        }
    }
}
