using System;
using System.Collections.Generic;
using System.Text;

namespace SMTRPZ.Lab2
{
    public abstract class RandomEncounterHandler : ChainLink<RandomEncounterHandler, int, Animal>
    {
        protected override Exception NoHandlerException => new NoSuitableEncounterHandlerException();
    }
}
