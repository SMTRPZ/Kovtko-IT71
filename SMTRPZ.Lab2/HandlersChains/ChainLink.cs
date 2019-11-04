using System;
using System.Collections.Generic;
using System.Text;

namespace SMTRPZ.Lab2
{
    public abstract class ChainLink<THandler, TParam, TReturn> : IChainLink<THandler>
        where THandler : ChainLink<THandler, TParam, TReturn>
    {
        protected abstract Exception NoHandlerException { get; }
        private THandler _nextHandler;
        protected abstract bool CanHandle(TParam param);
        protected abstract TReturn GetResult(TParam param);
        public void SetNextHandler(THandler handler)
        {
            _nextHandler = handler;
        }

        public TReturn Handle(TParam param)
        {
            return CanHandle(param) ? GetResult(param) : TryNext(param);
        }

        private TReturn TryNext(TParam param)
        {
            return _nextHandler != null ? _nextHandler.Handle(param) : throw NoHandlerException;
        }
    }
}
