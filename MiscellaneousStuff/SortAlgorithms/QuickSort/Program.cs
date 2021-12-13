global using System;
global using System.Collections.Generic;
global using System.Collections.Immutable;
global using System.Diagnostics;
global using System.Linq;
global using MiscellaneousStuff.SortAlgorithms.QuickSort;
global using static System.Console;
global using static System.Linq.Enumerable;

const char SPACE = ' ';
const int max = 20;

Stopwatch stopwatch = new();

long[] array = Range(default, max + 1)
    .Select(i => Convert.ToInt64(i))
    .OrderBy(i => new Random().Next())
    .ToArray();

static string Elapsed(in Stopwatch stopwatch) => stopwatch.Elapsed.ToString(@"hh\:mm\:ss\.fffffff");

#region Random unsorted initial array
WriteLine("Unsorted:");
array.ToImmutableList().ForEach(n => Write($"{n}{SPACE}"));
#endregion

#region Recursive sorting
WriteLine("\n\nRecursive Sorting:");

stopwatch.Start();
PrimaryQuickSort.ByUsingRecursive.SortRecursive(array)
    .ToImmutableList()
    .ForEach(n => Write($"{n}{SPACE}"));
stopwatch.Stop();

WriteLine($"\nRecursive Sorting --> {Elapsed(stopwatch)}");
#endregion

#region Iterative Sorting
WriteLine("\nIterative Sorting:");

stopwatch.Start();
EnumerableQuickSort.Sort(array)
    .ToImmutableList()
    .ForEach(n => Write($"{n}{SPACE}"));
stopwatch.Stop();

WriteLine($"\nIterative Sorting --> {Elapsed(stopwatch)}");
#endregion

#region Sorting by means of using IEnumerable LINQ methods
WriteLine("\nEnumerable Sorting:");

stopwatch.Start();
EnumerableQuickSort.Sort(array)
    .ToImmutableList()
    .ForEach(n => Write($"{n}{SPACE}"));
stopwatch.Stop();

WriteLine($"\nLookup quick sorting --> {Elapsed(stopwatch)}");
#endregion
