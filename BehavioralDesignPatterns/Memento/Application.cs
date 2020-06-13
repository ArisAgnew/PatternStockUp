using Memento.Controller;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace Memento
{
    [SuppressMessage("Style", "CS0628", Justification = "New protected property declared in the sealed class")]
    internal sealed class Application
    {
        private const string SPACE = " ";
        private const string COMMA = ",";
        private const string DOT = ".";

        private ConsoleKeyInfo keyInfo;
#nullable disable
        private string[] compoundProcesses;
        private SortedSet<string> processes;
        private protected Monitor Monitor { get; set; }
        private protected MonitorHistory History { get; } = new MonitorHistory();
#nullable restore

        public void Run()
        {
            Console.WriteLine("Welcome to the Memento pattern simulator!");

            do
            {
                try
                {
                    Console.Write($">> Enter uptime: ");
                    double uptime = double.Parse(Console.ReadLine());

                    Console.Write($">> Enter polling time: ");
                    double pollingInterval = double.Parse(Console.ReadLine());

                    Console.Write($">> Enter process names(s): ");
                    string processesAsString = Console.ReadLine();

                    if (new Regex(".*\\s.*").IsMatch(processesAsString))
                    {
                        compoundProcesses = processesAsString.Split(new string[] { SPACE, COMMA, DOT },
                            StringSplitOptions.RemoveEmptyEntries);
                    }
                    else
                    {
                        compoundProcesses = new string[] { processesAsString };
                    }

                    processes = new SortedSet<string>(compoundProcesses);

                    Monitor = new Monitor(uptime, pollingInterval, processes); //originator

                    History.Put(Monitor.Save());

                    Console.Write($">> Are you willing to peek through the history [y/n]?: ");
                    keyInfo = Console.ReadKey();

                    if (keyInfo.Key == ConsoleKey.Y)
                    {
                        History.ShowHistory();
                    }
                    else if (keyInfo.Key == ConsoleKey.N)
                    {
                        Console.Write($"\n>>\tWould you mind nullifying history [y]?: ");
                        keyInfo = Console.ReadKey();

                        if (keyInfo.Key == ConsoleKey.Y)
                        {
                            History.ResetAllData();
                            History.ShowHistory();
                        }

                        Console.WriteLine("\nKeep on working...\n");
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("\nExiting...");
                        break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nIt is considered to be a number type of double. Exiting...");
                    break;
                }

            } while (keyInfo != default && keyInfo.Key != ConsoleKey.Escape);
        }
    }
}
