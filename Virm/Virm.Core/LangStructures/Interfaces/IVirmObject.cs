namespace Virm.Core.LangStructures.Interfaces
{
    public interface IVirmObject
    {
        IVirmObject Create(object obj);
        object Data { get; set; }
    }
}
