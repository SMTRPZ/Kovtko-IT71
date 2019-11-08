﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SMTRPZ.Lab2
{
    public class HabitationHandlersChain : HandlersChain<HabitationHandler>
    {
        private static readonly HabitationHandler[] Handlers = {
            new AviaryHandler(),
            new PastureHandler(),
            new RoomHandler()
        };

        public HabitationHandlersChain() : base(Handlers)
        { }

        public Habitation PickHabitation(Animal animal) => Handler.Handle(animal);
    }
}
