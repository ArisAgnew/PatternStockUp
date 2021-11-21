using System.Collections.Generic;

namespace Flyweight.Specimen_1
{
    internal class EssentialCharacter : ICharacter { }

    internal class CharacterFactory
    {
        private readonly Dictionary<char, Character> _characters = new();
        private Character _character;

        internal Character GetCharacter(char key)
        {
            if (_characters.ContainsKey(key))
            {
                _character ??= _characters[key];
            }
            else
            {
                CharacterEstablishment(key);
                _characters.Add(key, _character);
            }
            return _character;
        }

        private void CharacterEstablishment(char key)
        {
            _character = key switch
            {
                'A' => new CharacterSet.CharacterA(),
                'B' => new CharacterSet.CharacterB(),
                'Z' => new CharacterSet.CharacterZ(),
                _ => new CharacterSet.CharacterZ(),
            };
        }
    }
}
