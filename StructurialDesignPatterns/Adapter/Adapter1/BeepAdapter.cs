using System;
using System.Text;

using UsefulStuff;

namespace Adapter.Adapter1
{
    internal enum SimpleBeep { Default, Perls, Upper }

    internal enum MusicBeep { MissionImpossible, StarWars, HappyBirthday }

    internal class BeepAdapter : IBeepGenerator
    {
        private SimpleBeepGenerator _simpleBeepGenerator;
        private MusicBeepGenerator _musicBeepGenerator;

        public Enum BeepType { get; set; }

        internal BeepAdapter(SimpleBeepGenerator simpleBeepGenerator) =>
            _simpleBeepGenerator = simpleBeepGenerator
                ?? throw new ArgumentNullException(
                    $"The instance of {nameof(SimpleBeepGenerator)} has not been specified");

        internal BeepAdapter(MusicBeepGenerator musicBeepGenerator) =>
            _musicBeepGenerator = musicBeepGenerator
                ?? throw new ArgumentNullException(
                    $"The instance of {nameof(MusicBeepGenerator)} has not been specified");
        
        public void EnhancedBeep(in double duration)
        {
            switch(BeepType)
            {
                case SimpleBeep.Default: 
                    _simpleBeepGenerator.BeepDefault(duration); 
                    break;

                case SimpleBeep.Perls:
                    _simpleBeepGenerator.BeepPerls(duration);
                    break;

                case SimpleBeep.Upper:
                    _simpleBeepGenerator.BeepUpper(duration);
                    break;

                case MusicBeep.MissionImpossible:
                    _musicBeepGenerator.MissionImpossible();
                    break;

                case MusicBeep.StarWars:
                    _musicBeepGenerator.StarWars();
                    break;

                case MusicBeep.HappyBirthday:
                    _musicBeepGenerator.HappyBirthday();
                    break;

                default:
                    var sb = new StringBuilder();
                    sb.AppendLine("There is no any other Beepers!");
                    sb.AppendLine();
                    sb.Append($"Choose only as follows: " +
                        $"{SimpleBeep.Default.ToString()}, " +
                        $"{SimpleBeep.Upper.ToString()}, " +
                        $"{MusicBeep.MissionImpossible.ToString()}, " +
                        $"{MusicBeep.StarWars.ToString()}, " +
                        $"{MusicBeep.HappyBirthday.ToString()}");

                    sb.ToString().Depict(consoleColor: ConsoleColor.Red, leftLine: true);
                    break;
            }
        }

        public override string ToString()
        {
            return $"The Beep Adapter is some sort of a bridge to " +
                $"{nameof(SimpleBeepGenerator)} & {nameof(MusicBeepGenerator)}";
        }
    }
}
