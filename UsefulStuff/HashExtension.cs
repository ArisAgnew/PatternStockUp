using System;

using static System.HashCode;
using static System.Int32;

namespace UsefulStuff
{
    internal static class HashExtension
    {
        private static readonly int BASE_VALUE = new Random().Next(MinValue, MaxValue) >> 5;

        private static int GetHashCode<T>(this T arg)
            where T : notnull
            => unchecked(BASE_VALUE + arg.GetHashCode());

        #region A default set
        internal static int GetHashCode<TInitial, T1>(this TInitial initial, T1 arg1)
            where TInitial : notnull
            where T1 : notnull
            => unchecked(arg1.GetHashCode<T1>());

        internal static int GetHashCode<TInitial, T1, T2>(this TInitial initial, T1 arg1, T2 arg2)
            where TInitial : notnull
            where T1 : notnull
            where T2 : notnull
            => unchecked(arg1.GetHashCode<T1>() + arg2.GetHashCode<T2>());

        internal static int GetHashCode<TInitial, T1, T2, T3>(this TInitial initial, T1 arg1, T2 arg2, T3 arg3)
            where TInitial : notnull
            where T1 : notnull
            where T2 : notnull
            where T3 : notnull
            => unchecked(arg1.GetHashCode<T1>() +
                arg2.GetHashCode<T2>() +
                arg3.GetHashCode<T3>());

        internal static int GetHashCode<TInitial, T1, T2, T3, T4>(this TInitial initial, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
            where TInitial : notnull
            where T1 : notnull
            where T2 : notnull
            where T3 : notnull
            where T4 : notnull
            => unchecked(arg1.GetHashCode<T1>() +
                arg2.GetHashCode<T2>() +
                arg3.GetHashCode<T3>() +
                arg4.GetHashCode<T4>());

        internal static int GetHashCode<TInitial, T1, T2, T3, T4, T5>(this TInitial initial, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
            where TInitial : notnull
            where T1 : notnull
            where T2 : notnull
            where T3 : notnull
            where T4 : notnull
            where T5 : notnull
            => unchecked(arg1.GetHashCode<T1>() +
                arg2.GetHashCode<T2>() +
                arg3.GetHashCode<T3>() +
                arg4.GetHashCode<T4>() +
                arg5.GetHashCode<T5>());
        #endregion

        #region Goes with utilizing struct HashCode
        internal static int GetHashCodeCombined<TInitial, T1>(this TInitial initial, T1 arg1)
            where TInitial : notnull
            where T1 : notnull
            => Combine(arg1);

        internal static int GetHashCodeCombined<TInitial, T1, T2>(this TInitial initial, T1 arg1, T2 arg2)
            where TInitial : notnull
            where T1 : notnull
            where T2 : notnull
            => Combine(arg1, arg2);

        internal static int GetHashCodeCombined<TInitial, T1, T2, T3>(this TInitial initial, T1 arg1, T2 arg2, T3 arg3)
            where TInitial : notnull
            where T1 : notnull
            where T2 : notnull
            where T3 : notnull
            => Combine(arg1, arg2, arg3);
        #endregion
    }
}
