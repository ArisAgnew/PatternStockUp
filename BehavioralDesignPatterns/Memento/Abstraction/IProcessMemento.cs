using System.Collections.Generic;

namespace Memento.Abstraction
{
    internal interface IProcessMemento<T> where T : notnull
    {
        /// <summary>
        /// Sorted set collection in order for process names to store
        /// </summary>
        /// <see cref="SortedSet{T}"/>
        SortedSet<T> ProcessNames { get; }
    }
}
