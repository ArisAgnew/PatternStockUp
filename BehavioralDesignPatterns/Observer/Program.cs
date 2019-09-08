using System;
using System.Collections.Generic;
using System.Linq;
using BehavioralDesignPatterns.Observer.Observers;
using UsefulStuff;

namespace BehavioralDesignPatterns.Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            GetNums(start: 0L, howMuch: 100L, step: 50L).ToList().ForEach(n => {
                    using var subject = new Subject() { State = n };

                    subject.AffirmUpOnProperties<Subject, string>().Depict(consoleColor: ConsoleColor.Green, leftLine: true);

                    $"I N B O U N D  N U M B E R :: {n}".Depict(leftLine: true, rightLine: true);

                    new BinaryObserver().Register(subject);
                    new OctalObserver().Register(subject);
                    new HexObserver().Register(subject);
                });

            IEnumerable<long> GetNums(long start = default, long howMuch = default, long step = default)
            {
                for (long i = start; i <= howMuch; i += step)
                {
                    if (howMuch == default || howMuch < step)
                        yield break;
                    yield return i;
                }
            }
        }
    }
}
