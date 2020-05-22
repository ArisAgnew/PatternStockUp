namespace Singleton.NoThreadSafe
{
    /*
     * Explanation of the following code:
     * 
     * 1. The following code is not thread-safe.
     * 
     * 2. Two different threads could both have evaluated the test (if instance == null) and found it to be true, 
     * then both create instances, which violates the singleton pattern.
     * 
     * 3. Note that in fact the instance may already have been created before the expression is evaluated, 
     * but the memory model doesn't guarantee that the new value of instance will be seen 
     * by other threads unless suitable memory barriers have been passed.
     */
     // It is the bad code, this is not allowed to use anywhere in your projects.
    internal sealed class SingletonNoThreadSafe
    {
        private static SingletonNoThreadSafe _instance;

        private SingletonNoThreadSafe() { }

        public static SingletonNoThreadSafe Instance
        {
            get
            {
                return _instance ??= new SingletonNoThreadSafe();
            }
            private set { }
        }

        public void SomeBusinessLogic() { }
    }
}
