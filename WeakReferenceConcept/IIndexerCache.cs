using System;

namespace WeakReferenceConcept
{
    internal interface IIndexerCache<T> where T : notnull
    {
        T this[int index] { get; }

        Guid GetGuid { get; }
    }
}
