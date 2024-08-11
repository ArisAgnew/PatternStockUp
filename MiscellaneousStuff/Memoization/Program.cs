global using Microsoft.Extensions.Caching.Memory;
global using System;
global using System.Collections.Concurrent;
global using System.Collections.Generic;
global using UsefulStuff;
global using static System.TimeSpan;
using MiscellaneousStuff.Memoization;
using static System.Console;
using static System.Diagnostics.Stopwatch;

#region Arrange
Func<uint, uint> FibonacciFunc = default;
Func<uint, IEnumerable<uint>> FibonacciEnumerableFunc = default;
FibonacciBase fibonacci = default;
#endregion

#region Functions and instance initialization
FibonacciFunc = n => n >= 2 ? FibonacciFunc(n - 1) + FibonacciFunc(n - 2) : n;

FibonacciEnumerableFunc = n =>
{
    fibonacci = new() { Number = n };
    return fibonacci;
};
#endregion

#region Without memoization
var sw = StartNew();
for (int i = default; i <= 10_000; ++i)
{
    FibonacciFunc(9);
}
WriteLine($"With no memoization: {sw.ElapsedTicks} elapsed ticks.");
sw.Stop();
#endregion

// Memoize function
FibonacciFunc = FibonacciFunc.Memoize();
//FibonacciFunc = FibonacciFunc.MemoizeWithPolicy();

#region With memoization
sw = StartNew();
for (int i = default; i <= 10; ++i)
{
    WriteLine($"Fibonacci({9}) = {FibonacciFunc(9)}");
}
WriteLine($"With memoization: {sw.ElapsedTicks} elapsed ticks.");
sw.Stop();
WriteLine("=====================================");
#endregion

#region Additional implementation if Fibonacci as of December 26th
Dictionary<uint, uint> _memoizationDict = new()
{
    { 0, 0 },
    { 1, 1 }
};

uint Fibonacci(uint n)
{
    if (_memoizationDict.ContainsKey(n))
    {
        return _memoizationDict[n];
    }

    return Fibonacci(n - 1) + Fibonacci(n - 2);
}

for (uint i = default; i <= 16; ++i)
{
    WriteLine($"Fibonacci({i}) = {Fibonacci(i)}");
}
#endregion
