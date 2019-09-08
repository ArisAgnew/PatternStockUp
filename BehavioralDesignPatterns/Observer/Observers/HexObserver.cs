using System;
using UsefulStuff;

namespace BehavioralDesignPatterns.Observer.Observers
{
    internal class HexObserver : IObserver
    {        
        public virtual void Register<T>(T t) where T : ISubject
        {
            $"To hexadecimal\t=>\t0x{Convert.ToString(Subject().State, 16)}".Depict();

            Subject Subject()
            {
                var _subject = t as Subject;
                _subject.Attach(this);
                return _subject;
            }
        }
    }
}
