using Memento;
using Memento.Lab;

using System;
using System.Diagnostics.CodeAnalysis;

namespace BehavioralDesignPatterns.Memento
{
    internal class Program
    {
        [SuppressMessage("Style", "IDE0060")]
        static void Main(string[] args)
        {
            try
            {
                new Application().Run();

                //StackToLabProbe.StackToRiseUp();
            }
            catch (Exception e)
            {
                Console.WriteLine("Some errors have been occured, please endeavour to deal with them afterwards.");
                Console.WriteLine($"Cause: {e.Message}\n");
                Console.WriteLine($"StackTrace:\n{e.StackTrace}\n");
                Console.WriteLine($"Exception type: {e.GetType().FullName}\n");
                Console.WriteLine($"TargetSite: {e.TargetSite}\n");
            }
        }
    }
}
