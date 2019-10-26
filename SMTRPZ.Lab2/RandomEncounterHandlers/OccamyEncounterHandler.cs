using System;
using System.Collections.Generic;
using System.Text;

namespace SMTRPZ.Lab2
{
    public class OccamyEncounterHandler : RandomEncounterHandler
    {
        public override Animal HandleEncounter(int chance)
        {
            if (chance > 7)
            {
                return new Occamy(Guid.NewGuid().ToString(), 12);
            }
            else
            {
                return TryNext(chance);
            }
        }
    }
}
