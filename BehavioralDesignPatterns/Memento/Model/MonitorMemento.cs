using Memento.Abstraction;

using System;
using System.Collections.Generic;

namespace Memento.Model
{
    /// <summary>
    /// Concrete Memento
    /// </summary>
    internal class MonitorMemento : IMonitorMemento
    {
        public double? Uptime { get; private set; }

        public double? PollingInterval { get; private set; }

        public SortedSet<string> ProcessNames { get; private set; }

        public MonitorMemento(double? uptime,
                              double? pollingInterval,
                              SortedSet<string>? processNames)
        {
            Uptime = uptime ?? throw new ArgumentException($"{nameof(Uptime)} should not be less than 0.");
            PollingInterval = pollingInterval ?? throw new ArgumentException($"{nameof(PollingInterval)} should not be less than 0.");
            ProcessNames = processNames ?? throw new ArgumentException($"Process names collection should be defined.");
        }

        public override string ToString()
        {
            return $"Monitor memento: " +
                $"[{nameof(Uptime)} = {Uptime}]; " +
                $"[{nameof(PollingInterval)} = {PollingInterval}]; " +
                $"[{nameof(ProcessNames)} = {ProcessNames}];";
        }
    }
}
