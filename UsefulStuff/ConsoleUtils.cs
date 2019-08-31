using System;

using static System.Console;

namespace UsefulStuff
{
    public static class ConsoleUtils
    {
        public static void Depict<T>(this T type,
                                     bool line = default,
                                     bool leftLine = default,
                                     bool rightLine = default) where T : IComparable<T>
        {
            if (line) Write(type);
            else
            {
                if (leftLine && rightLine == default)
                {
                    WriteLine($"\n{type}");
                }
                else if (rightLine && leftLine == default)
                {
                    WriteLine($"{type}\n");
                }
                else if ((leftLine && rightLine) != default)
                {
                    WriteLine($"\n{type}\n");
                }
                else WriteLine(type);
            }
        }
    }
}
