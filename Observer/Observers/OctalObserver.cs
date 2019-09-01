using System;
using UsefulStuff;

namespace Observer.Observers
{
    internal class OctalObserver : IObserver
    {
        public void Register<T>(T t) where T : ISubject
        {
            $"To octal\t=>\t{Convert.ToString(Subject().State, 8)}".Depict();

            Subject Subject()
            {
                var _subject = t as Subject;
                _subject.Attach(this);
                return _subject;
            }
        }
    }
}
