using System;
using System.Linq;
using System.Reflection;

namespace SMTRPZ.Lab2
{
    public abstract class HandlersChain<THandler> where THandler : IChainLink<THandler>
    {
        protected readonly THandler Handler;

        public HandlersChain(THandler[] handlers)
        {
            Handler = CreateHandlers(handlers);
        }

        private THandler CreateHandlers(THandler[] handlers)
        {
            SetChainLinks(handlers);
            return handlers[0];
        }
        protected void SetChainLinks<TChainLink>(TChainLink[] handlers)
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

        protected TChainLink CreateHandlers<TChainLink>() where TChainLink : IChainLink<TChainLink>
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
