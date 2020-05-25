using System;

using static System.Console;
using static System.ConsoleColor;

namespace UsefulStuff
{
    public static class ConsoleUtils
    {
        public static void Depict<T>(this T type,
                                     ConsoleColor consoleColor = Gray,
                                     bool line = default,
                                     bool leftLine = default,
                                     bool rightLine = default) 
            where T : IComparable<T>
        {
            ForegroundColor = consoleColor;

            if (line) Write($"{type}; ");
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

            ForegroundColor = Gray;
        }
    }
}
