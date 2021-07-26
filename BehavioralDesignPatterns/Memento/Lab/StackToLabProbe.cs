using System;
using System.Collections.Generic;
using System.IO;

using Memento.Controller;

using static UsefulStuff.ConsoleDecoratorExtension;

namespace Memento.Lab
{
    internal static class StackToLabProbe
    {
        private const int THRESHOLD = 100_000;

        private static string RandomString => Path.GetRandomFileName().Replace(".", string.Empty);

        private static string[,,] RandomIELTSPart
        {
            get
            {
                return new string[2, 2, 1]
                {
                    {
                        { "Listening" }, { "Reading" }
                    },
                    {
                        { "Writing" }, { "Speaking" }
                    }
                };
            }
        }

        private static MonitorHistory History { get; } = new MonitorHistory();

        internal static void StackToRiseUp()
        {
            var rnd = new Random();

            for (int i = 0; i < THRESHOLD; i++)
            {
                Monitor monitor = Monitor.Empty
                        .SetUptime(rnd.Next(default, int.MaxValue))
                        .SetPollingInterval(rnd.Next(default, int.MaxValue / 4))
                        .SetProcessNames(new SortedSet<string>(new string[]
                            { RandomIELTSPart[rnd.Next(2), rnd.Next(2), 0] }))
                        .Build();

                History.Put(monitor.Save());

                $"Iteration: {i}".Depict(ConsoleColor.DarkCyan);
            }

            History.ShowHistory();
        }
    }
}
