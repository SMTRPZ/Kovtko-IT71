using System;
using System.Collections.Generic;
using System.Text;

namespace SMTRPZ.Lab2
{
    public class AviaryHandler : HabitationHandler
    {
        protected override bool CanHandle(Animal animal)
        {
            return animal is Occamy;
        }

        protected override Habitation GetResult(Animal animal)
        {
            return new Aviary((Occamy)animal);
        }
    }
}
