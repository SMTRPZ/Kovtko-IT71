using System;
using System.Collections.Generic;
using System.Text;

namespace SMTRPZ.Lab2
{
    public abstract class RandomEncounterHandler
    {
        RandomEncounterHandler nextHandler;

        public void SetNextHandler(RandomEncounterHandler handler)
        {
            nextHandler = handler;
        }

        protected Animal TryNext(int chance)
        {
            if(nextHandler != null)
            {
                return nextHandler.HandleEncounter(chance);
            }
            throw new NoSuitableEncounterHandlerException();
        }

        public abstract Animal HandleEncounter(int chance);

        public static RandomEncounterHandler CreateHandlers()
        {
            BowtruckleEncounterHandler handler = new BowtruckleEncounterHandler();
            handler.SetNextHandler(new DemiguiseEncounterHandler());
            handler.nextHandler.SetNextHandler(new OccamyEncounterHandler());
            return handler;
        }
    }
}
