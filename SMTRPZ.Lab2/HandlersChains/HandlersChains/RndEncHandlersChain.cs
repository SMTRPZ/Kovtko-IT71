using System;
using System.Collections.Generic;
using System.Text;

namespace SMTRPZ.Lab2
{
    public class RndEncHandlersChain : HandlersChain<RandomEncounterHandler>
    {
        private Random Random { get; }

        private static readonly RandomEncounterHandler[] Handlers = {
            new BowtruckleEncounterHandler(),
            new OccamyEncounterHandler(),
            new DemiguiseEncounterHandler()
        };

        public RndEncHandlersChain() : base(Handlers)
        {
            Random = new Random();
        }

        public Animal HandleEncounter(int chance) => Handler.Handle(chance);
        public Animal HandleEncounterRandom10() => Handler.Handle(Random.Next(10));
    }
}
