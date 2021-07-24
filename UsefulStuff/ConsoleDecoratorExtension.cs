using System;

using static System.Console;
using static System.ConsoleColor;

namespace UsefulStuff
{
    public static class ConsoleDecoratorExtension
    {
        public static void Depict<T>(this T type,
                                     ConsoleColor consoleColor = Gray,
                                     bool line = default,
                                     bool leftLine = default,
                                     bool rightLine = default)
            where T : IComparable<T>
        {
            ForegroundColor = consoleColor;

            switch ((line, leftLine, rightLine))
            {
                case (true, false, false): Write($"{type}; "); break;
                case (false, true, false): WriteLine($"\n{type}"); break;
                case (false, false, true): WriteLine($"{type}\n"); break;
                case (false, true, true): WriteLine($"\n{type}\n"); break;
                default: WriteLine(type); break;
            }

            ResetColor();
        }
    }
}
