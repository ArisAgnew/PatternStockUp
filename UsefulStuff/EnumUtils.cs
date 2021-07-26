using System;

using static System.Enum;

namespace UsefulStuff
{
    public class EnumUtils
    {
        private static Random _random = new();

        public static T RandomEnumValue<T>() where T : Enum
        {
            Array values = GetValues(typeof(T));
            return (T)values.GetValue(_random.Next(values.Length));
        }
    }
}
