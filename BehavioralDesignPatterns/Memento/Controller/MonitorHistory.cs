using Memento.Abstraction;
using Memento.Model;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Memento.Controller
{
    /// <summary>
    /// Caretaker
    /// </summary>
    internal class MonitorHistory : IEnumerable<IMonitorMemento>
    {
        private readonly Stack<IMonitorMemento> _history = new Stack<IMonitorMemento>();

        public MonitorHistory() { }

        private Stack<IMonitorMemento> CheckUponDefaultHistory() =>
            _history ?? throw new HistoryException("Failed to obtain any kind of Monitor history.");

        private Stack<IMonitorMemento> CheckUponEmptyHistory() =>
            CheckUponDefaultHistory().Count == 0
                ? throw new InvalidOperationException("There is no way to look through the history due to it is empty.")
                : _history;

        public virtual MonitorHistory Put([DisallowNull] IMonitorMemento monitorMemento)
        {
            if (!(monitorMemento is MonitorMemento))
            {
                throw new TypeLoadException("Unknown memento class.");
            }

            CheckUponDefaultHistory().Push(monitorMemento);
            return this;
        }

        public virtual IMonitorMemento Pull() => CheckUponEmptyHistory().Pop();

        public virtual IMonitorMemento LookThrough() => CheckUponEmptyHistory().Peek();

        protected virtual void Clear() => CheckUponDefaultHistory().Clear();

        public MonitorHistory ResetAllData()
        {
            if (CheckUponDefaultHistory().Count == 0)
            {
                Console.WriteLine($"\nMonitor history has not been reseted due to the history is empty.");
                return this;
            }

            Clear();
            Console.WriteLine($"\n\nMonitor history has been reseted.");
            return this;
        }

        public MonitorHistory ShowHistory()
        {
            if (CheckUponDefaultHistory().Count == 0)
            {
                Console.WriteLine($"\nMonitor history is empty. There is nothing to exhibit.");
                return this;
            }

            Console.WriteLine($"\n[There is the history of the {nameof(MonitorMemento)}].");

            using IEnumerator<IMonitorMemento> enumerator = GetEnumerator();

            try
            {
                uint j = default;

                while (enumerator.MoveNext())
                {
                    ++j;

                    IMonitorMemento historyItem = enumerator.Current;

                    Console.WriteLine($"\n\tUptime [{j}]: {historyItem.Uptime}\n" +
                        $"\tPollingInterval [{j}]: {historyItem.PollingInterval}\n" +
                        $"\tProcesses [{j}]: {string.Join(", ", historyItem.ProcessNames)}\n");
                }
            }
            finally
            {
                enumerator?.Dispose();
            }

            return this;
        }

        public IEnumerator<IMonitorMemento> GetEnumerator()
        {
            if (CheckUponDefaultHistory().Count > 0)
            {
                foreach (IMonitorMemento monitorMemento in _history)
                {
                    yield return monitorMemento;
                }
            }
            else yield break;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
