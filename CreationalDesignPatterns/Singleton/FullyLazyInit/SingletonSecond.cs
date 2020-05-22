namespace Singleton.FullyLazyInit
{
    internal sealed class SingletonSecond
    {
        private SingletonSecond() { }

        public static SingletonSecond Instance { get; } = Nested.instance;

        private class Nested
        {
            static Nested() { }

            internal static readonly SingletonSecond instance = new SingletonSecond();
        }

        public void SomeBusinessLogic() { }
    }
}
