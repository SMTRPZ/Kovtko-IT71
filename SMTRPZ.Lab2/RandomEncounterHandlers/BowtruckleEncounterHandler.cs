using System;
using System.Collections.Generic;
using System.Text;

namespace SMTRPZ.Lab2
{
    public class BowtruckleEncounterHandler : RandomEncounterHandler
    {
        protected override bool CanHandle(int chance)
        {
            return chance < 4;
        }

        protected override Animal GetResult(int chance)
        {
            return new Bowtruckle(Guid.NewGuid().ToString(), 5);
        }
    }
}
