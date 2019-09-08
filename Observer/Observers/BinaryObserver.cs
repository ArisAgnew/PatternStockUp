using System;
using UsefulStuff;

namespace Observer.Observers
{
    internal class BinaryObserver : IObserver
    {
        public virtual void Register<T>(T t) where T : ISubject
        {
            $"To binary\t=>\t{Convert.ToString(Subject().State, 2).PadLeft(8, '0')}".Depict();

            Subject Subject()
            {
                var _subject = t as Subject;
                _subject.Attach(this);
                return _subject;
            }
        }
    }
}
