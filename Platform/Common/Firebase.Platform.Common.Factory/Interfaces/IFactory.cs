namespace Firebase.Platform.Common.Factory.Interfaces
{
    public interface IFactory<T> where T : class
    {
        T Create();
    }
}