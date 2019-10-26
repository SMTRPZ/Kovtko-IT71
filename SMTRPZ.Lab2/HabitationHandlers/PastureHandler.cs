using System;
using System.Collections.Generic;
using System.Text;

namespace SMTRPZ.Lab2
{
    public class PastureHandler : HabitationHandler
    {
        public override Habitation PickHabitation(Animal a)
        {
            if(a is Bowtruckle)
            {
                return new Pasture(a as Bowtruckle);
            }
            else
            {
                return TryNext(a);
            }
        }
    }
}
