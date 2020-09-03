using Memento.Controller;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

using static System.Console;
using static System.ConsoleKey;
using static System.Double;
using static System.StringSplitOptions;
using static System.Text.RegularExpressions.Regex;

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
            WriteLine("Welcome to the Memento pattern simulator!");

            do
            {
                try
                {
                    Write($"\n>> Enter uptime: ");
                    double uptime = Parse(ReadLine());

                    Write($">> Enter polling time: ");
                    double pollingInterval = Parse(ReadLine());

                    Write($">> Enter process names(s): ");
                    string processesAsString = ReadLine();

                    if (IsMatch(processesAsString, ".*\\s.*"))
                    {
                        compoundProcesses = processesAsString
                            .Split(new string[] { SPACE, COMMA, DOT }, RemoveEmptyEntries);
                    }
                    else
                    {
                        compoundProcesses = new string[] { processesAsString };
                    }

                    processes = new SortedSet<string>(compoundProcesses);

                    Monitor = Monitor.Empty
                        .SetUptime(uptime)
                        .SetPollingInterval(pollingInterval)
                        .SetProcessNames(processes)
                        .Build();

                    History.Put(Monitor.Save());

                    Write($">> Are you willing to peek through the history?: [y/n]\t");
                    keyInfo = ReadKey();

                    if (keyInfo.Key == Y)
                    {
                        History.ShowHistory();

                        Write($"\n>> Would you like to keep on working in the programme or to exit? [y/n]\t");
                        keyInfo = ReadKey();

                        if (keyInfo.Key == Y) continue;
                        else if (keyInfo.Key == N)
                        {
                            WriteLine("\nExiting...");
                            break;
                        }
                    }
                    else if (keyInfo.Key == N)
                    {
                        Write($"\n>>\tWould you mind nullifying history?: [y/any key]\t");
                        keyInfo = ReadKey();

                        if (keyInfo.Key == Y)
                        {
                            History.ResetAllData().ShowHistory();
                        }

                        WriteLine("\nKeep on working...\n");
                        continue;
                    }
                    else
                    {
                        WriteLine("\nExiting...");
                        break;
                    }
                }
                catch (FormatException)
                {
                    WriteLine("\nIt is considered to be a number type of double. Exiting...");
                    break;
                }

            } while (keyInfo != default && keyInfo.Key != ConsoleKey.Escape);
        }
    }
}
