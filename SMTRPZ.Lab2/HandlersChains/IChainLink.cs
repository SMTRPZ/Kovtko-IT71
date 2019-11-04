namespace SMTRPZ.Lab2
{
    public interface IChainLink<in THandler> where THandler : IChainLink<THandler>
    {
        void SetNextHandler(THandler handler);
    }
}
