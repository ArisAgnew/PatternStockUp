using System;
using System.Text;
using Unity;
using UsefulStuff;

namespace Adapter.Adapter1
{
    internal enum SimpleBeep
    {
        Default,
        Perls,
        Upper,

        Set = Default | Perls | Upper
    }

    internal enum MusicBeep
    {
        MissionImpossible,
        StarWars,
        HappyBirthday,

        Set = MissionImpossible | StarWars | HappyBirthday
    }

    internal class BeepAdapter : IBeepGenerator
    {
        private SimpleBeepGenerator _simpleBeepGenerator = default;
        private MusicBeepGenerator _musicBeepGenerator = default;

        public Enum BeepType { get; set; }

        [InjectionConstructor]
        internal BeepAdapter(SimpleBeepGenerator simpleBeepGenerator) =>
            _simpleBeepGenerator = simpleBeepGenerator
                ?? throw new ArgumentNullException(
                    $"The instance of {nameof(SimpleBeepGenerator)} has not been specified");

        [InjectionConstructor]
        internal BeepAdapter(MusicBeepGenerator musicBeepGenerator) =>
            _musicBeepGenerator = musicBeepGenerator
                ?? throw new ArgumentNullException(
                    $"The instance of {nameof(MusicBeepGenerator)} has not been specified");

        public void EnhancedBeep(in double duration)
        {
            switch (BeepType)
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

                case SimpleBeep.Set:
                    "|> Beep ?".Depict(consoleColor: ConsoleColor.Green);
                    break; //todo

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

                case MusicBeep.Set:
                    "|> Beep ?".Depict(consoleColor: ConsoleColor.Green);
                    break; //todo

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
