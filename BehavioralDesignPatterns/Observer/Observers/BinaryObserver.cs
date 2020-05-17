using System;
using UsefulStuff;

namespace BehavioralDesignPatterns.Observer.Observers
{
    internal class BinaryObserver : IObserver
    {
        public virtual void Register<T>(T t) where T : ISubject
        {
            $"Registered binary\t=>\t{Convert.ToString(Subject().State, 2).PadLeft(8, '0')}\n".Depict();

            Subject Subject()
            {
                var _subject = t as Subject;
                _subject.Attach(this);
                return _subject;
            }
        }

        public virtual void Unregister<T>(T t) where T : ISubject
        {
            $"Unregistered binary\t=>\t{Convert.ToString(Subject().State, 2).PadLeft(8, '0')}\n".Depict();

            Subject Subject()
            {
                var _subject = t as Subject;
                _subject.Detach(this);
                return _subject;
            }
        }
    }
}
