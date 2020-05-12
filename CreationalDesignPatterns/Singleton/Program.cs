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

            string value1 = "Function";
            string value2 = "Method";

            Task task1 = new Task(v =>
            {
                SingletonDoubleCheckLocking singleton = SingletonDoubleCheckLocking.GetAmplifiedInstance(v as string);
                WriteLine(singleton.Value);
                WriteLine(singleton.SomeBusinessLogic(singleton.Value));
            }, value1);

            Task task2 = new Task(v =>
            {
                SingletonDoubleCheckLocking singleton = SingletonDoubleCheckLocking.GetAmplifiedInstance(v as string);
                WriteLine(singleton.Value);
                WriteLine(singleton.SomeBusinessLogic(singleton.Value));
            }, value2);

            task1.Start();
            task2.Start();

            task1.Wait();            
            task2.Wait();

            #endregion type safe double check locking
        }
    }
}
