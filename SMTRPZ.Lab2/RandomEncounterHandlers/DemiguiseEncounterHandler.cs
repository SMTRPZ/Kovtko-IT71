using System;
using System.Collections.Generic;
using System.Text;

namespace SMTRPZ.Lab2
{
    public class DemiguiseEncounterHandler : RandomEncounterHandler
    {
        protected override bool CanHandle(int chance)
        {
            return chance > 3 && chance < 8;
        }

        protected override Animal GetResult(int chance)
        {
            return new Demiguise(Guid.NewGuid().ToString(), 50);
        }
    }
}
