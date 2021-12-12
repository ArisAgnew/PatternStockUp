using System.Collections.Generic;
using System.Linq;

namespace MiscellaneousStuff.SortAlgorithms.QuickSort
{
    internal sealed class EnumerableQuickSort
    {
        internal static IEnumerable<long> Sort(IEnumerable<long> sequence)
        {
            if (!sequence.Any() || !sequence.Skip(1).Any())
            {
                return sequence;
            }

            long firstElement = sequence.FirstOrDefault();
            ILookup<int, long> lookUp = sequence.ToLookup(q => q.CompareTo(firstElement));

            return Sort(lookUp[-1]).Concat(lookUp[0]).Concat(lookUp[1]);
        }
    }

    internal sealed class PrimaryQuickSort
    {
        private static void Swap(ref long[] array, ref long left, ref long right)
        {
            var temporary = array[left];
            array[left] = array[right];
            array[right] = temporary;
        }

        static long Partition(long[] array, long low, long high)
        {
            long pivot = array[high];

            // index of smaller element
            long smallerElement = (low - 1);
            for (var j = low; j <= high - 1; j++)
            {
                // If current element is smaller
                // than or equal to pivot
                if (array[j] <= pivot)
                {
                    smallerElement++;

                    // swap arr[i] and arr[j]
                    Swap(ref array, ref smallerElement, ref j);
                }
            }

            // swap arr[i+1] and arr[high]
            // (or pivot)
            ++smallerElement;
            Swap(ref array, ref smallerElement, ref high);

            return smallerElement;
        }

        /* A[] --> Array to be sorted,
        l --> Starting index,
        h --> Ending index */
        internal static long[] SortIterative(long[] array, long low, long high)
        {
            // Create an auxiliary stack
            long[] stack = new long[high - low + 1];

            // initialize top of stack
            long top = -1;

            // push initial values of l and h to
            // stack
            stack[++top] = low;
            stack[++top] = high;

            // Keep popping from stack while
            // is not empty
            while (top >= 0)
            {
                // Pop h and l
                high = stack[top--];
                low = stack[top--];

                // Set pivot element at its
                // correct position in
                // sorted array
                long pivot = Partition(array, low, high);

                // If there are elements on
                // left side of pivot, then
                // push left side to stack
                if (pivot - 1 > low)
                {
                    stack[++top] = low;
                    stack[++top] = pivot - 1;
                }

                // If there are elements on
                // right side of pivot, then
                // push right side to stack
                if (pivot + 1 < high)
                {
                    stack[++top] = pivot + 1;
                    stack[++top] = high;
                }
            }

            return array;
        }

        internal static long[] SortIterative(in long[] array) => SortIterative(array, default, array.Length - 1);

        internal static class ByUsingRecursive
        {
            private static void Swap(ref long left, ref long right)
            {
                var temporary = left;
                left = right;
                right = temporary;
            }

            private static long GetPivotIndex(long[] array, long minIndex, long maxIndex)
            {
                var pivot = minIndex - 1;

                for (long i = minIndex; i < maxIndex; ++i)
                {
                    if (array[i] < array[maxIndex])
                    {
                        ++pivot;
                        Swap(ref array[pivot], ref array[i]);
                    }
                }

                ++pivot;
                Swap(ref array[pivot], ref array[maxIndex]);

                return pivot;
            }

            internal static long[] SortRecursive(long[] array, long low, long high)
            {
                if (low >= high)
                {
                    return array;
                }

                var pivot = GetPivotIndex(array, low, high);

                SortRecursive(array, low, pivot - 1);
                SortRecursive(array, pivot + 1, high);

                return array;
            }

            internal static long[] SortRecursive(in long[] array) => SortRecursive(array, default, array.Length - 1);
        }
    }
}
