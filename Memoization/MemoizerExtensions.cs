using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Memoization
{
    internal static class MemoizerExtensions
    {
        internal static Func<Output> Memoize<Output>(this Func<Output> func) => Memoizer.Memoize(func);
        internal static Func<Input, Output> Memoize<Input, Output>(this Func<Input, Output> func) => Memoizer.Memoize(func);
        internal static Func<Input, Output> ConcurrentMemoize<Input, Output>(this Func<Input, Output> func) => Memoizer.ConcurrentMemoize(func);

        private class Memoizer
        {
            internal static Func<Output> Memoize<Output>(Func<Output> func)
            {
                Output cache = default;
                return () =>
                {
                    if (cache is default(Func<Output>))
                    {
                        cache ??= func();
                    }
                    return cache;
                };
            }

            internal static Func<Input, Output> Memoize<Input, Output>(Func<Input, Output> func)
            {
                Dictionary<Input, Output> cache = new();
                return _in =>
                {
                    if (cache.TryGetValue(_in, out Output value))
                    {
                        value ??= func(_in);
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
    }
}
