using System;

using static System.Console;
using static System.Diagnostics.Stopwatch;

namespace Memoization
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int> FibonacciFunc = default;
            FibonacciFunc = n => n >= 2 ? FibonacciFunc(n - 1) + FibonacciFunc(n - 2) : n;

            // Without memoization
            var sw = StartNew();
            for (int i = 0; i < 10_000; ++i)
            {
                FibonacciFunc(10);
            }
            WriteLine(sw.ElapsedTicks);

            // Memoize function
            FibonacciFunc = FibonacciFunc.Memoize();

            // With memoization
            sw = StartNew();
            for (int i = 0; i < 10_000; ++i)
            {
                FibonacciFunc(10);
            }
            WriteLine(sw.ElapsedTicks);
        }
    }
}
