// you can choose what you want to go ahead, either interface or abstract class
namespace BehavioralDesignPatterns.Observer
{
    internal interface IObserver
    {
        void Register<T>(T t) where T : ISubject;
        void Unregister<T>(T t) where T : ISubject;
    }

    internal abstract class AObserver
    {
#pragma warning disable
        private protected Subject subject;
#pragma warning enable
        public abstract void Update();
    }
}
