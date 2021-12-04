using System;
using System.Collections.Immutable;
using System.Linq;

using static System.Console;
using static System.Linq.Enumerable;

namespace MiscellaneousStuff.SortAlgorithms.QuickSort
{
    class Program
    {
        private const char SPACE = ' ';

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
            WriteLine("\nRecursive Sorting:");
            PrimaryQuickSort.ByUsingRecursive.SortRecursive(array).ToImmutableList().ForEach(n => Write($"{n}{SPACE}"));
            #endregion

            #region Iterative Sorting
            WriteLine("\nIterative Sorting:");
            PrimaryQuickSort.SortIterative(array).ToImmutableList().ForEach(n => Write($"{n}{SPACE}"));
            #endregion

            #region Sorting by means of using IEnumerable LINQ methods
            WriteLine("\nEnumerable Sorting:");
            EnumerableQuickSort.Sort(array).ToImmutableList().ForEach(n => Write($"{n}{SPACE}"));
            #endregion
        }
    }
}
