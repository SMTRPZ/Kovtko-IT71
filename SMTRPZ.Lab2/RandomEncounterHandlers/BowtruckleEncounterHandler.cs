using System;
using System.Collections.Generic;
using System.Text;

namespace SMTRPZ.Lab2
{
    public class BowtruckleEncounterHandler : RandomEncounterHandler
    {
        public override Animal HandleEncounter(int chance)
        {
            if(chance < 4)
            {
                return new Bowtruckle(Guid.NewGuid().ToString(),5);
            }
            else
            {
                return TryNext(chance);
            }
        }
    }
}
