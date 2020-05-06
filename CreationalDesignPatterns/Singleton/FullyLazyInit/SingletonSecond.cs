namespace Singleton.FullyLazyInit
{
    internal sealed class SingletonSecond
    {
        private SingletonSecond() { }

        public static SingletonSecond Instance { get; } = SingletonNested.INSTANCE;

        private class SingletonNested
        {
            static SingletonNested() { }

            internal static readonly SingletonSecond INSTANCE = new SingletonSecond();
        }

        public void SomeBusinessLogic() { }
    }
}
