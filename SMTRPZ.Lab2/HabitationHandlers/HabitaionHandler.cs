using System;
using System.Collections.Generic;
using System.Text;

namespace SMTRPZ.Lab2
{
    public abstract class HabitationHandler
    {
        protected HabitationHandler nextHandler;
        
        public void SetNextHandler(HabitationHandler habitation)
        {
            nextHandler = habitation;
        }
        public abstract Habitation PickHabitation(Animal a);

        protected Habitation TryNext(Animal a)
        {
            if (nextHandler != null)
            {
                return nextHandler.PickHabitation(a);
            }
            throw new NoSuitableHabitationHandlerException();
        }

        public static HabitationHandler CreateHandlers()
        {
            HabitationHandler handler = new AviaryHandler();
            handler.SetNextHandler(new PastureHandler());
            handler.nextHandler.SetNextHandler(new RoomHandler());
            return handler;
        }
    }
}
