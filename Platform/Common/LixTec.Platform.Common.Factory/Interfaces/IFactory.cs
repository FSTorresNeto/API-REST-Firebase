namespace LixTec.Platform.Common.Factory.Interfaces
{
    public interface IFactory<T> where T : class
    {
        T Create();
    }
}