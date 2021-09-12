using System;

using static UsefulStuff.ConsoleDecoratorExtensions;

namespace BehavioralDesignPatterns.Observer.Observers
{
    internal class HexObserver : IObserver
    {
        public virtual void Register<T>(T t) where T : ISubject
        {
            $"Registered hexadecimal\t=>\t0x{Convert.ToString(Subject().State, 16)}\n".Depict();

            Subject Subject()
            {
                var _subject = t as Subject;
                _subject.Attach(this);
                return _subject;
            }
        }

        public virtual void Unregister<T>(T t) where T : ISubject
        {
            $"Unregistered hexadecimal\t=>\t0x{Convert.ToString(Subject().State, 16)}\n".Depict();

            Subject Subject()
            {
                var _subject = t as Subject;
                _subject.Detach(this);
                return _subject;
            }
        }
    }
}
