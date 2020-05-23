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
                    "|> Beep Default 37".Depict(consoleColor: ConsoleColor.Green);
                    _simpleBeepGenerator.BeepDefault(duration); 
                    break;

                case SimpleBeep.Perls:
                    "|> Beep Perls".Depict(consoleColor: ConsoleColor.Green);
                    _simpleBeepGenerator.BeepPerls(duration);
                    break;

                case SimpleBeep.Upper:
                    "|> Beep Upper 32737".Depict(consoleColor: ConsoleColor.Green);
                    _simpleBeepGenerator.BeepUpper(duration);
                    break;

                case MusicBeep.MissionImpossible:
                    "|> Mission Imposible".Depict(consoleColor: ConsoleColor.Green);
                    _musicBeepGenerator.MissionImpossible();
                    break;

                case MusicBeep.StarWars:
                    "|> Star Wars".Depict(consoleColor: ConsoleColor.Green);
                    _musicBeepGenerator.StarWars();
                    break;

                case MusicBeep.HappyBirthday:
                    "|> Happy Birthday".Depict(consoleColor: ConsoleColor.Green);
                    _musicBeepGenerator.HappyBirthday();
                    break;

                default:
                    var sb = new StringBuilder();

                    sb.AppendLine("There is no any other Beepers!");
                    sb.AppendLine();
                    sb.AppendLine("Choose only as follows:");
                    sb.AppendLine($"\t{SimpleBeep.Default.ToString()},");
                    sb.AppendLine($"\t{SimpleBeep.Upper.ToString()},");
                    sb.AppendLine($"\t{SimpleBeep.Perls.ToString()},");
                    sb.AppendLine($"\t{MusicBeep.MissionImpossible.ToString()},");
                    sb.AppendLine($"\t{MusicBeep.StarWars.ToString()},");
                    sb.AppendLine($"\t{MusicBeep.HappyBirthday.ToString()}");

                    sb.ToString()
                        .Depict(consoleColor: ConsoleColor.Red, leftLine: true);
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
