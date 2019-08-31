using System;
using UsefulStuff;

namespace Observer.Observers
{
    internal class OctalObserver : IObserver
    {
        public void Update(ISubject subject)
        {
            $"To octal\t=>\t{Convert.ToString(Subject().State, 8)}".Depict();

            Subject Subject()
            {
                var _subject = subject as Subject ?? new Subject();
                _subject.Attach(this);
                return _subject;
            }
        }
    }
}
