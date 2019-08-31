using System;
using UsefulStuff;

namespace Observer.Observers
{
    internal class BinaryObserver : IObserver
    {
        public void Update(ISubject subject)
        {
            $"To binary\t=>\t{Convert.ToString(Subject().State, 2).PadLeft(8, '0')}".Depict();

            Subject Subject()
            {
                var _subject = subject as Subject ?? new Subject();
                _subject.Attach(this);
                return _subject;
            }
        }
    }
}
