namespace Virm.Core.Interfaces
{
    public interface IVirmStack
    {
        void Push(IVirmUnit value);
        IVirmUnit Pop();
        IVirmUnit Peek();

        int Count { get; }
        int Capacity { get; }
    }
}
