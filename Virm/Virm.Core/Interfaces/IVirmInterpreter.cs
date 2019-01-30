namespace Virm.Core.Interfaces
{
    public interface IVirmInterpreter
    {
        IVirmUnit InterpretLine(string data);
        bool TryInterpretLine(string data, out IVirmUnit unit);

    }
}
