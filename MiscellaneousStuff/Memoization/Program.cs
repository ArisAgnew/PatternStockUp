using System;
using System.Collections.Generic;

using UsefulStuff;

using static System.Console;
using static System.Diagnostics.Stopwatch;

namespace MiscellaneousStuff.Memoization
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<uint, uint> FibonacciFunc = default;
            Func<uint, IEnumerable<uint>> FibonacciEnumerableFunc = default;
            FibonacciBase fibonacci = default;

            FibonacciFunc = n => n >= 2 ? FibonacciFunc(n - 1) + FibonacciFunc(n - 2) : n;

            FibonacciEnumerableFunc = n =>
            {
                fibonacci = new() { Number = n };
                return fibonacci;
            };

            /*foreach (var item in FibonacciFunc(10))
            {
                WriteLine(item);
            }*/

            // Without memoization
            var sw = StartNew();
            for (int i = 0; i < 10_000; ++i)
            {
                FibonacciFunc(15);
            }
            WriteLine(sw.ElapsedTicks);

            // Memoize function
            FibonacciFunc = FibonacciFunc.Memoize();
            //FibonacciFunc = FibonacciFunc.MemoizeWithPolicy();

            // With memoization
            sw = StartNew();
            for (int i = 0; i < 10_000; ++i)
            {
                FibonacciFunc(15);
            }
            WriteLine(sw.ElapsedTicks);
        }
    }
}
