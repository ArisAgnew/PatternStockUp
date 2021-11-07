using System;
using System.Collections.Generic;

using static System.Console;
using static System.Runtime.InteropServices.Marshal;

namespace WeakReferenceConcept
{
    internal class IndexerCache : IIndexerCache<ByteData>
    {
        // Dictionary to contain the cache.
        private static Dictionary<int, WeakReference> _cache;
        private static Guid _guid;

        // Track the number of times an object is regenerated.
        private uint _regenerationCount = default;

        public IndexerCache() { }

        public IndexerCache(int count)
        {
            if (count is default(int))
            {
                WriteLine($"{nameof(count)} has not been established");
                return;
            }

            _guid = GenerateGuidForType(typeof(IndexerCache));
            _cache = new();

            // Add objects with a short weak reference to the cache.
            for (int size = 0; size < count; ++size)
            {
                _cache.Add(size, new WeakReference(new ByteData(size), false));
            }
        }

        // Number of times an object needs to be regenerated.
        public uint RegenerationCount => _regenerationCount;

        // Number of items in the cache.
        public int Count => _cache.Count;

        public Guid GetGuid
        {
            get => _guid switch
            {
                Guid value when value != default => _guid,
                _ => new Func<Guid>(() =>
                {
                    WriteLine($"{nameof(Guid)}'s not been initialized, " +
                        $"so default value now.");
                    return Guid.Empty;
                })()
            };
            protected set { }
        }

        public ByteData this[int index]
        {
            get
            {
                if (_cache[index].Target is not ByteData byteData)
                {
                    WriteLine($"Regenerate object at {index}: Yes");
                    // If the object was reclaimed, generate a new one.
                    byteData = new(index);
                    _cache[index].Target = byteData;
                    ++_regenerationCount;
                }
                else
                {
                    // Object was obtained with the weak reference.
                    WriteLine($"Regenerate object at {index}: No");
                }

                return byteData;
            }
            protected set { }
        }
    }
}
