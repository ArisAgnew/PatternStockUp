using System;
using System.Threading.Tasks;

using Singleton.TSafeDoubleCheckLocking;

using static UsefulStuff.ConsoleDecoratorExtensions;

namespace CreationalDesignPatterns.Singleton
{
    class Program
    {
        private static void ThreadSafeDoubleCheckLockingSingletonTest()
        {
            Task[] tasks = new Task[3]
            {
                new Task(v => CreateSinglton(v), "Interface"),
                new Task(v => CreateSinglton(v), "Abstract Class"),
                new Task(v => CreateSinglton(v), "Custom Type")
            };

            foreach (var task in tasks)
            {
                if (task.Status == TaskStatus.Created)
                {
                    task.Start();
                }
            }

            Task.WaitAll(tasks);

            void CreateSinglton(in object obj)
            {
                SingletonDoubleCheckLocking singleton = SingletonDoubleCheckLocking.GetAmplifiedInstance(obj as string);
                singleton.SomeBusinessLogic(singleton.Value, out string resultString);

                $"Initial value: {singleton.Value}".Depict(consoleColor: ConsoleColor.DarkYellow);
                $"Reversed value: {resultString}".Depict(consoleColor: ConsoleColor.DarkCyan);
            }
        }

        static void Main(string[] args)
        {
            #region type safe double check locking
            ThreadSafeDoubleCheckLockingSingletonTest();
            #endregion type safe double check locking

            /*int iteration = default;

            for(var frequency = 37; frequency <= 32500; frequency += 500)
            {
                var duration = 1_000; //ms                
                WriteLine($"Frequency: {frequency}; Step: {iteration}");
                Beep(frequency, duration);
                iteration++;
            }*/
        }
    }
}
