using System;
using UsefulStuff;

namespace Observer.Observers
{
    internal class HexObserver : IObserver
    {
        public void Update(ISubject subject)
        {
            $"To hexadecimal\t=>\t0x{Convert.ToString(Subject().State, 16)}".Depict();

            Subject Subject()
            {
                var _subject = subject as Subject ?? new Subject();
                _subject.Attach(this);
                return _subject;
            }
        }
    }
}
