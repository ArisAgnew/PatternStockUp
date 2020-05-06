using System;

namespace Singleton.ThreadSafe
{
    /*
     * This implementation attempts to be thread-safe without the necessity of taking out a lock every time. 
     * Unfortunately, there are four downsides to the pattern:

     * 1. It doesn't work in Java. This may seem an odd thing to comment on, but it's worth knowing if you ever need the singleton pattern in Java, 
     * and C# programmers may well also be Java programmers. 
     * The Java memory model doesn't ensure that the constructor completes before the reference to the new object is assigned to instance. 
     * The Java memory model underwent a reworking for version 1.5, but double-check locking is still broken after this without a volatile variable (as in C#).
     * 
     * 2. Without any memory barriers, it's broken in the ECMA CLI specification too. 
     * It's possible that under the .NET 2.0 memory model (which is stronger than the ECMA spec) it's safe, 
     * but I'd rather not rely on those stronger semantics, especially if there's any doubt as to the safety. 
     * Making the instance variable volatile can make it work, as would explicit memory barrier calls, 
     * although in the latter case even experts can't agree exactly which barriers are required. 
     * It tends to try to avoid situations where experts don't agree what's right and what's wrong!
     * 
     * 3. It's easy to get wrong. The pattern needs to be pretty much exactly as above - 
     * any significant changes are likely to impact either performance or correctness.
     * 4. It still doesn't perform as well as the later implementations.
     */
    internal sealed class Singleton
    {
        private static readonly object synchronized = new object();

        private static Singleton _instance;

        private Singleton() { }

        public string Value { get; private set; }

        public static Singleton GetAmplifiedInstance(string value)
        {
            return _instance ??= new Func<Singleton>(() =>
            {
                lock (synchronized)
                {
                    (_instance ??= new Singleton()).Value = value;
                }

                return _instance;
            })();
        }

        [Obsolete(message: "It appears to be removed")]
        public static Singleton Instance
        {
            get
            {
                return _instance ??= new Func<Singleton>(() =>
                {
                    lock (synchronized)
                    {
                        return _instance ??= new Singleton();
                    }
                })();
            }
            private set { }
        }

        public void SomeBusinessLogic() { }
    }
}
