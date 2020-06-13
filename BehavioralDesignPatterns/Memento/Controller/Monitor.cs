﻿using Memento.Abstraction;
using Memento.Model;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Memento.Controller
{
    /// <summary>
    /// Originator
    /// </summary>
    /// <remarks>Perhaps this class ought to implement some interface in order to be with even stricter encapsulation</remarks>
    internal class Monitor
    {
        private double? _uptime;
        private double? _pollingInterval;
        private SortedSet<string> _processNames;

        public Monitor([DisallowNull] double? uptime,
                       [DisallowNull] double? pollingInterval,
                       [DisallowNull] SortedSet<string> processNames)
        {
            _uptime = uptime ?? throw new ArgumentException($"Uptime should not be less than 0.");
            _pollingInterval = pollingInterval ?? throw new ArgumentException($"PollingInterval should not be less than 0.");
            _processNames = processNames ?? throw new ArgumentException($"Process names collection should be defined.");
        }

        public void Deconstruct(out double? uptime,
                                out double? pollingInterval,
                                out SortedSet<string> processNames)
        {
            uptime = _uptime;
            pollingInterval = _pollingInterval;
            processNames = _processNames;
        }

        public IMonitorMemento Save()
        {
            Console.WriteLine($"\nSaving the values coming from console.\n" +
                $"Uptime is {_uptime} now.\n" +
                $"PolingInterval is {_pollingInterval} now.\n" +
                $"Indicated processes are {string.Join(", ", _processNames)} now.");

            return new MonitorMemento(_uptime, _pollingInterval, _processNames);
        }

        public void Restore()
        {
            (_uptime, _pollingInterval) = (default, default);
            _processNames.Clear();

            Console.WriteLine($"\nMonitor data has been reseted.\n" +
                $"Uptime is {_uptime} after reseting.\n" +
                $"PolingInterval is {_pollingInterval} after reseting.\n" +
                $"Indicated processes are {_processNames.Count} after reseting.");
        }

        public void UpdateState(MonitorMemento monitorMemento)
        {
            if (monitorMemento == default)
            {
                throw new ArgumentException(nameof(MonitorMemento));
            }

            _uptime = monitorMemento.Uptime;
            _pollingInterval = monitorMemento.PollingInterval;
            _processNames = monitorMemento.ProcessNames;

            Console.WriteLine($"\nMonitor history has been updated.\n" +
                $"Uptime is {_uptime} after reseting.\n" +
                $"PolingInterval is {_pollingInterval} after reseting.\n" +
                $"Indicated processes are {_processNames.Count} after reseting.");
        }

        public override string ToString()
        {
            return $"Monitor: " +
                $"[Uptime = {_uptime}]; " +
                $"[PollingInterval = {_pollingInterval}]; " +
                $"[ProcessNames = {_processNames}];";
        }
    }
}