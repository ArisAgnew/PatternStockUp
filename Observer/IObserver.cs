// you can choose what you want to go ahead, either interface or abstract class
namespace Observer
{
    internal interface IObserver
    {
        void Update(ISubject subject);
    }

    internal abstract class AObserver
    {
        #pragma warning disable
        private protected Subject subject;
        #pragma warning enable
        public abstract void Update();
    }
}
