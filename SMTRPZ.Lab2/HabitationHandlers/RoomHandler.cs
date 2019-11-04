using System;
using System.Collections.Generic;
using System.Text;

namespace SMTRPZ.Lab2
{
    public class RoomHandler : HabitationHandler
    {
        protected override bool CanHandle(Animal animal)
        {
            return animal is Demiguise;
        }

        protected override Habitation GetResult(Animal animal)
        {
            return new Room((Demiguise)animal);
        }
    }
}
