using System;
using System.Collections.Generic;
using System.Text;

namespace SMTRPZ.Lab2
{
    public class DemiguiseEncounterHandler : RandomEncounterHandler
    {
        public override Animal HandleEncounter(int chance)
        {
            if (chance > 3 && chance < 8)
            {
                return new Demiguise(Guid.NewGuid().ToString(), 50);
            }
            else
            {
                return TryNext(chance);
            }
        }
    }
}
