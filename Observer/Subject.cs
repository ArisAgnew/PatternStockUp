using System;
using System.Collections.Generic;
using UsefulStuff;

namespace Observer
{
    internal class Subject : ISubject, IDisposable
    {
        private const string SUBJECT = nameof(Subject);
        private readonly List<IObserver> observers = new List<IObserver>();

        private long _state = default;        
        public long State
        {
            get => _state;
            set
            {
                if (_state != value)
                    _state = value;
                Notify();
            }
        }
        public void Attach(IObserver observer)
        {
            $"{SUBJECT}: Attached an observer.".Depict();
            observers.Add(observer);
        }
        public void Detach(IObserver observer)
        {
            observers.Remove(observer);
            $"{SUBJECT}: Detached an observer.".Depict();
        }
        public void Notify()
        {
            $"\n\t{SUBJECT}: Notifying observers...".Depict();

            observers.ForEach(observer => observer.Update(this));
        }
        public void Dispose()
        {
            _state = default;
        }
    }
}