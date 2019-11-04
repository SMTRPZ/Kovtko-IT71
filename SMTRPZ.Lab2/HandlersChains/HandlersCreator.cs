using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SMTRPZ.Lab2
{
    [SuppressMessage("ReSharper", "PossibleMultipleEnumeration")]
    [SuppressMessage("ReSharper", "SuggestVarOrType_BuiltInTypes")]
    [SuppressMessage("ReSharper", "SuggestBaseTypeForParameter")]
    public static class HandlersCreator
    {
        private static void SetChainLinks<TChainLink>(TChainLink[] handlers)
            where TChainLink : IChainLink<TChainLink>
        {
            var currentHandler = handlers[0];
            for (int i = 1; i < handlers.Length; i++)
            {
                var nextHandler = handlers[i];
                currentHandler.SetNextHandler(nextHandler);
                currentHandler = nextHandler;
            }
        }

        public static HabitationHandler CreateHabitationHandlers()
        {
            var handlers = new HabitationHandler[]
            {
                new AviaryHandler(),
                new PastureHandler(),
                new RoomHandler()
            };

            SetChainLinks(handlers);

            return handlers[0];
        }

        public static RandomEncounterHandler CreateRandomEncounterHandlers()
        {
            var handlers = new RandomEncounterHandler[]
            {
                new BowtruckleEncounterHandler(), 
                new OccamyEncounterHandler(), 
                new DemiguiseEncounterHandler()
            };

            SetChainLinks(handlers);

            return handlers[0];
        }

        private static TChainLink CreateHandlers<TChainLink>() where TChainLink : IChainLink<TChainLink>
        {
            var handlers = Assembly.GetAssembly(typeof(TChainLink)).GetTypes()
                .Where(type => type.IsClass && !type.IsAbstract && type.IsSubclassOf(typeof(TChainLink)))
                .Select(type => (TChainLink)Activator.CreateInstance(type));

            var firstHandler = handlers.First();
            var currentHandler = firstHandler;
            var handlersExceptFirst = handlers.Skip(1);
            foreach (var chainLink in handlersExceptFirst)
            {
                currentHandler.SetNextHandler(chainLink);
                currentHandler = chainLink;
            }

            return firstHandler;
        }
    }
}
