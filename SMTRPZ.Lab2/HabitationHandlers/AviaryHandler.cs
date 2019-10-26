using System;
using System.Collections.Generic;
using System.Text;

namespace SMTRPZ.Lab2
{
    public class AviaryHandler : HabitationHandler
    {
        public override Habitation PickHabitation(Animal a)
        {
            if(a is Occamy)
            {
                return new Aviary(a as Occamy);
            }
            else
            {
                return TryNext(a);
            }
        }
    }
}
