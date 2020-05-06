using System;

namespace Singleton.DotNetLazy
{
    internal sealed class Singleton
    {
        private static readonly object synchronized = new object();

        // By default, Lazy objects are thread-safe.
        private static readonly Lazy<Singleton> _instance =
            new Lazy<Singleton>(() => new Singleton());

        public string Name { get; private set; }

        private Singleton()
        {
            Name = Guid.NewGuid().ToString();
        }

        public static Singleton Instance
        {
            get => _instance?.Value;
            private set { }
        }

        public void SomeBusinessLogic() { }
    }
}
