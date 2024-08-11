namespace MiscellaneousStuff.Memoization
{
    internal static class MemoizerExtensions
    {
        internal static Func<Output> Memoize<Output>(this Func<Output> func) => Memoizer.Memoize(func);
        internal static Func<Input, Output> Memoize<Input, Output>(this Func<Input, Output> func) => Memoizer.Memoize(func);
        internal static Func<Input, Output> ConcurrentMemoize<Input, Output>(this Func<Input, Output> func) => Memoizer.ConcurrentMemoize(func);
        internal static Func<Input, Output> MemoizeWithPolicy<Input, Output>(this Func<Input, Output> func) => MemoryCacheWithPolicy<Input, Output>.GetOrCreate(func);

        private class Memoizer
        {
            internal static Func<Output> Memoize<Output>(Func<Output> func)
            {
                Output cache = default;
                return () =>
                {
                    if (cache is default(Func<Output>))
                    {
                        cache = func();
                    }
                    return cache;
                };
            }

            internal static Func<Input, Output> Memoize<Input, Output>(Func<Input, Output> func)
            {
                Dictionary<Input, Output> cache = [];

                return _in =>
                {
                    if (!cache.TryGetValue(_in, out Output value))
                    {
                        value = func(_in);
                        cache.Add(_in, value);
                    }
                    return value;
                };
            }

            internal static Func<Input, Output> ConcurrentMemoize<Input, Output>(Func<Input, Output> func)
            {
                ConcurrentDictionary<Input, Output> cache = new();
                return _in => cache.GetOrAdd(_in, func);
            }
        }

        private class MemoryCacheWithPolicy<Input, Output>
        {
            private static readonly MemoryCache _cache = new(new MemoryCacheOptions() { SizeLimit = 4096 });

            internal static Func<Input, Output> GetOrCreate(Func<Input, Output> func)
            {
                return _in =>
                {
                    if (!_cache.TryGetValue(_in, out Output cacheEntry)) // Look for cache key.
                    {
                        // Key not in cache, so get data.
                        cacheEntry = func(_in);

                        var cacheEntryOptions = new MemoryCacheEntryOptions()
                            .SetSize(1) // Size amount
                                        // Priority on removing when reaching size limit (memory pressure)
                            .SetPriority(CacheItemPriority.High)
                            // Keep in cache for this time, reset time if accessed.
                            .SetSlidingExpiration(FromSeconds(2))
                            // Remove from cache after this time, regardless of sliding expiration
                            .SetAbsoluteExpiration(FromSeconds(10));

                        // Save data in cache.
                        _cache.Set(_in, func(_in), cacheEntryOptions);
                    }
                    return cacheEntry;
                };
            }
        }
    }
}
