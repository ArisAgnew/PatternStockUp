﻿using System;
using System.Collections.Generic;
using System.Linq;

using BehavioralDesignPatterns.Observer.Observers;

using static UsefulStuff.ConsoleDecoratorExtensions;
using static UsefulStuff.ValidationUtils;

namespace BehavioralDesignPatterns.Observer
{
    class Program
    {
        static IObserver binaryObserver = new BinaryObserver();
        static IObserver octalObserver = new OctalObserver();
        static IObserver hexObserver = new HexObserver();

        static void Main(string[] args)
        {
            GetNums(start: 0L, howMuch: 100L, step: 50L).ToList().ForEach(n =>
            {
                using var subject = new Subject() { State = n };

                subject.AffirmUpOnProperties<Subject, string>()
                    .Depict(consoleColor: ConsoleColor.Green, leftLine: true);

                binaryObserver.Register(subject);
                octalObserver.Register(subject);
                hexObserver.Register(subject);

                "Frontier between being already registered & unregistered"
                    .Depict(consoleColor: ConsoleColor.Yellow, rightLine: true);

                binaryObserver.Unregister(subject);
                octalObserver.Unregister(subject);
                hexObserver.Unregister(subject);
            });

            IEnumerable<long> GetNums(long start = default,
                                      long howMuch = default,
                                      long step = default)
            {
                for (long i = start; i <= howMuch; i += step)
                {
                    if (howMuch == default && howMuch < step)
                        yield break;
                    yield return i;
                }
            }
        }
    }
}
