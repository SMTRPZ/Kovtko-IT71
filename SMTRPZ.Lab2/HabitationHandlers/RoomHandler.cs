using System;
using System.Collections.Generic;
using System.Text;

namespace SMTRPZ.Lab2
{
    public class RoomHandler : HabitationHandler
    {
        public override Habitation PickHabitation(Animal a)
        {
            if(a is Demiguise)
            {
                return new Room(a as Demiguise);
            }
            else
            {
                return TryNext(a);
            }
        }
    }
}
