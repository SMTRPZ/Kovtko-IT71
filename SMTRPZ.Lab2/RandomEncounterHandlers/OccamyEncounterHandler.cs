using System;
using System.Collections.Generic;
using System.Text;

namespace SMTRPZ.Lab2
{
    public class OccamyEncounterHandler : RandomEncounterHandler
    {
        protected override bool CanHandle(int chance)
        {
            return chance > 7;
        }

        protected override Animal GetResult(int chance)
        {
            return new Occamy(Guid.NewGuid().ToString(), 12);
        }
    }
}
