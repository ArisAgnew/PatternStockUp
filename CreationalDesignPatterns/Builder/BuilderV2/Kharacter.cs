using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

using static System.Console;
using static System.Enum;
using static System.Linq.Enumerable;
using static UsefulStuff.ConsoleDecoratorExtensions;

namespace Builder.BuilderV2
{
    [DefaultValue(None)]
    internal enum TierEnum
    {
        None, God, Top, High, Medium, Low, Bottom
    }

    [DefaultValue(None)]
    internal enum CharacterEnum
    {
        None, Tanya, Shinnok, Kano, Sonya, Kabal, Sheeva, KungLao,
        ShangTsung, SubZero, Scorpion, Fujin, Cetrion, Mileena,
        KotalKahn, CassieCage, KungJin, Takeda, ErronBlack,
        Jax, Stryker, Goro, ShaoKahn
    }

    internal class Kharacter
    {
        private string _game;
        private ReadOnlyCollection<string> _names;
        private Dictionary<CharacterEnum, TierEnum> _characterTier;

        #region Properties
        internal string Game
        {
            get => _game;
            set
            {
                if (_game is null or default(string))
                {
                    _game = value;
                }
            }
        }

        internal ReadOnlyCollection<string> Names
        {
            get => _names ?? Empty<string>().ToList().AsReadOnly();
            init
            {
                if (_names is null or default(ReadOnlyCollection<string>))
                {
                    _names = value;
                }
            }
        }

        #endregion Properties

        // Indexer
        internal TierEnum this[CharacterEnum key]
        {
            get => _characterTier[key];
            set
            {
                if (_characterTier is null or default(Dictionary<CharacterEnum, TierEnum>))
                {
                    _characterTier = new();
                }
                _characterTier[key] = value;
            }
        }

        internal void Display()
        {
            WriteLine("---------------------------");
            WriteLine($"{nameof(Game)}\t{Game}\n");
            _characterTier.Keys.ToImmutableList()
                .ForEach(khar =>
                {
                    GetValues(typeof(CharacterEnum))
                    .OfType<CharacterEnum>()
                    .ToImmutableList()
                    .ForEach(characterEnum =>
                    {
                        if (khar == characterEnum)
                        {
                            $"{_characterTier[khar]} Tier\t{khar}".Depict();
                        }
                    });
                });
            WriteLine("---------------------------");
        }
    }
}
