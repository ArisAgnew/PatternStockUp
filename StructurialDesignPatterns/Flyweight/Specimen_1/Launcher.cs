using System.Collections.Immutable;

namespace Flyweight.Specimen_1
{
    class Launcher
    {
        static void Main(string[] args)
        {
            int pointSize = 0xA; //10

            string probe = "AAZZBBZBA";
            char[] chars = probe.ToCharArray();

            CharacterFactory characterFactory = new();

            chars.ToImmutableList().ForEach(c =>
            {
                ++pointSize;
                Character character = characterFactory.GetCharacter(c);
                character.Display(pointSize);
            });
        }
    }
}
