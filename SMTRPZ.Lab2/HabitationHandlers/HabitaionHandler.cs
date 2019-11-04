using System;
using System.Collections.Generic;
using System.Text;

namespace SMTRPZ.Lab2
{
    public abstract class HabitationHandler : ChainLink<HabitationHandler, Animal, Habitation>
    {
        protected override Exception NoHandlerException => new NoSuitableHabitationHandlerException();
    }
}
