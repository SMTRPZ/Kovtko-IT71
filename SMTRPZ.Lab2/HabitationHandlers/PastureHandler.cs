using System;
using System.Collections.Generic;
using System.Text;

namespace SMTRPZ.Lab2
{
    public class PastureHandler : HabitationHandler
    {
        protected override bool CanHandle(Animal animal)
        {
            return animal is Bowtruckle;
        }

        protected override Habitation GetResult(Animal animal)
        {
            return new Pasture((Bowtruckle)animal);
        }
    }
}
