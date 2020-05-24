using System;
using System.Media;
using System.Threading.Tasks;

using Adapter.Adapter1;
using Unity;
using UsefulStuff;

namespace StructurialDesignPatterns.Adapter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region make use of unity container

            /*var container = new UnityContainer();

            container
                .RegisterType<MusicBeepGenerator>()
                .RegisterType<SimpleBeepGenerator>();

            var sg = container.Resolve<BeepAdapter>();
            ((BeepAdapter)sg).BeepType = SimpleBeep.Set;
            sg.EnhancedBeep(0.1);

            var mg = container.Resolve<BeepAdapter>();
            ((BeepAdapter)mg).BeepType = MusicBeep.StarWars;
            mg.EnhancedBeep(5);*/

            #endregion make use of unity container

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
            "...And following up with...".Depict();
            musicGen.EnhancedBeep(5);
            #endregion some music adapter showcasing
        }
    }
}
