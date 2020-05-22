namespace Singleton.FullyLazyInit
{
    /*
     * Explanation of the following code:
     * 
     * 1. Here, instantiation is triggered by the first reference to the static member of the nested class, that only occurs in Instance.
     * 
     * 2. This means the implementation is fully lazy, but has all the performance benefits of the previous ones.
     * 
     * 3. Note that although nested classes have access to the enclosing class's private members, 
     * the reverse is not true, hence the need for instance to be internal here.
     * 
     * 4. That doesn't raise any other problems, though, as the class itself is private.
     * 
     * 5. The code is more complicated in order to make the instantiation lazy.
     */
    internal sealed class SingletonFirst
    {
        private static readonly SingletonFirst _instance = new SingletonFirst();

        /*
        Explicit static constructor to get message over to C# compiler  
        not to mark type as before_field_init
         */
        static SingletonFirst() { }

        private SingletonFirst() { }

        public static SingletonFirst Instance { get; } = _instance;

        public static void SomeBusinessLogic() { }
    }
}
