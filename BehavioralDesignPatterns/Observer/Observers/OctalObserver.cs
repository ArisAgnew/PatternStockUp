using System;
using UsefulStuff;

namespace BehavioralDesignPatterns.Observer.Observers
{
    internal class OctalObserver : IObserver
    {
        public virtual void Register<T>(T t) where T : ISubject
        {
            $"Registered octal\t=>\t{Convert.ToString(Subject().State, 8)}\n".Depict();

            Subject Subject()
            {
                var _subject = t as Subject;
                _subject.Attach(this);
                return _subject;
            }
        }

        public virtual void Unregister<T>(T t) where T : ISubject
        {
            $"Unregistered octal\t=>\t{Convert.ToString(Subject().State, 8)}\n".Depict();

            Subject Subject()
            {
                var _subject = t as Subject;
                _subject.Detach(this);
                return _subject;
            }
        }
    }
}
