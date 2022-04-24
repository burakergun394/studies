namespace Core.CrossCuttinnConcerns.Caching
{
    public interface ICache
    {
        object Get(string key);

        bool IsAdd(string key);

        void Add(string key, object value, int duration);

        void Remove(string key);
    }
}
