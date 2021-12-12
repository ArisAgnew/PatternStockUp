using System;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;

using static System.Console;
using static System.Linq.Enumerable;

namespace MiscellaneousStuff.SortAlgorithms.QuickSort
{
    class Program
    {
        private const char SPACE = ' ';
        private static Stopwatch stopwatch = new();

        static void Main(string[] args)
        {
            int max = 20;
            long[] array = Range(default, max + 1)
                .Select(i => Convert.ToInt64(i))
                .OrderBy(i => new Random().Next())
                .ToArray();

            #region Random unsorted initial array
            WriteLine("Unsorted:");
            array.ToImmutableList().ForEach(n => Write($"{n}{SPACE}"));
            #endregion

            #region Recursive sorting
            WriteLine("\n\nRecursive Sorting:");
            {
                stopwatch.Start();
                PrimaryQuickSort.ByUsingRecursive.SortRecursive(array)
                    .ToImmutableList()
                    .ForEach(n => Write($"{n}{SPACE}"));
                stopwatch.Stop();
                WriteLine($"\nRecursive Sorting --> {Elapsed(stopwatch)}");
            }
            #endregion

            #region Iterative Sorting
            WriteLine("\nIterative Sorting:");
            {
                stopwatch.Start();
                EnumerableQuickSort.Sort(array)
                    .ToImmutableList()
                    .ForEach(n => Write($"{n}{SPACE}"));
                stopwatch.Stop();
                WriteLine($"\nIterative Sorting --> {Elapsed(stopwatch)}");
            }
            #endregion

            #region Sorting by means of using IEnumerable LINQ methods
            WriteLine("\nEnumerable Sorting:");
            {
                stopwatch.Start();
                EnumerableQuickSort.Sort(array)
                    .ToImmutableList()
                    .ForEach(n => Write($"{n}{SPACE}"));
                stopwatch.Stop();
                WriteLine($"\nLookup quick sorting --> {Elapsed(stopwatch)}");
            }
            #endregion
        }

        static string Elapsed(in Stopwatch stopwatch) => stopwatch.Elapsed.ToString(@"hh\:mm\:ss\.fffffff");
    }
}
