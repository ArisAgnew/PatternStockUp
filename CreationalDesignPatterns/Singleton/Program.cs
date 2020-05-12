using System;
using System.Threading.Tasks;
using Singleton.FullyLazyInit;
using Singleton.TSafeDoubleCheckLocking;

using static System.Console;

namespace CreationalDesignPatterns.Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            #region type safe double check locking

            Task task1 = new Task(() =>
            {
                const string VALUE = "Function";
                SingletonDoubleCheckLocking singleton = SingletonDoubleCheckLocking.GetAmplifiedInstance(VALUE);
                WriteLine(singleton.Value);
                WriteLine(singleton.SomeBusinessLogic(singleton.Value));
            });

            Task task2 = new Task(() =>
            {
                const string VALUE = "Method";
                SingletonDoubleCheckLocking singleton = SingletonDoubleCheckLocking.GetAmplifiedInstance(VALUE);
                WriteLine(singleton.Value);
                WriteLine(singleton.SomeBusinessLogic(singleton.Value));
            });

            task1.Start();
            task2.Start();

            task1.Wait();            
            task2.Wait();

            #endregion type safe double check locking
        }
    }
}
