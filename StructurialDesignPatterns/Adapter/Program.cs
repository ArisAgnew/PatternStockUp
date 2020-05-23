using System;
using System.Media;
using System.Threading.Tasks;

using Adapter.Adapter1;

using static System.Console;

namespace StructurialDesignPatterns.Adapter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region some music adapter showcasing
            var simpleBeep = new SimpleBeepGenerator();
            var musicBeep = new MusicBeepGenerator();

            IBeepGenerator simpleGen = new BeepAdapter(simpleBeep)
            {
                BeepType = SimpleBeep.Perls
            };

            IBeepGenerator musicGen = new BeepAdapter(musicBeep)
            {
                BeepType = MusicBeep.MissionImpossible
            };

            simpleGen.EnhancedBeep(0.1);
            WriteLine("...And following up with...");
            musicGen.EnhancedBeep(5);
            #endregion some music adapter showcasing
        }
    }
}
