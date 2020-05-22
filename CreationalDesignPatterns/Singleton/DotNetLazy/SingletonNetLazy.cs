using System;

namespace Singleton.DotNetLazy
{
    internal sealed class SingletonNetLazy
    {
        private static readonly object synchronized = new object();

        // By default, Lazy objects are thread-safe.
        private static readonly Lazy<SingletonNetLazy> _instance =
            new Lazy<SingletonNetLazy>(() => new SingletonNetLazy());

        public string Name { get; private set; }

        private SingletonNetLazy()
        {
            Name = Guid.NewGuid().ToString();
        }

        public static SingletonNetLazy Instance
        {
            get => _instance?.Value;
            private set { }
        }

        public void SomeBusinessLogic() { }
    }
}
