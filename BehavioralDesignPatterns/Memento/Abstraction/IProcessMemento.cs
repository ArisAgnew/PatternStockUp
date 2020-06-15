using System.Collections.Generic;

namespace Memento.Abstraction
{
    internal interface IProcessMemento<T> where T : notnull
    {
        /// <summary>
        /// Sorted set collection in order for process names to store
        /// </summary>
        /// <see cref="IReadOnlyCollection{T}"/>
        IReadOnlyCollection<T> ProcessNames { get; }
    }
}
