using Microsoft.Extensions.Caching.Memory;

namespace Core.CrossCuttinnConcerns.Caching.Microsoft
{
    public class MicrosoftMemoryCache : ICache
    {
        private readonly IMemoryCache _memoryCache;

        public MicrosoftMemoryCache(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public void Add(string key, object value, int duration)
        {
            _memoryCache.Set(key, value, TimeSpan.FromMinutes(duration));
        }

        public object Get(string key)
        {
            return _memoryCache.Get(key);
        }

        public void Remove(string key)
        {
            _memoryCache.Remove(key);
        }

        public bool IsAdd(string key)
        {
            return _memoryCache.TryGetValue(key, out _);
        }
    }
}
