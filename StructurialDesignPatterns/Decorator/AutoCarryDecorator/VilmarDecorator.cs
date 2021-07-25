using System;

using static System.Console;
using static UsefulStuff.EnumUtils;

namespace Decorator.AutoCarryDecorator
{
    public class VilmarDecorator : CharacterDecorator
    {
        private const string PLAYER = "Vilmar";

        public VilmarDecorator(IAutoCarryCharacter autoCarryCharacter)
            : base(autoCarryCharacter) { }

        public override IAutoCarryCharacter ImbalancedCharacter(string charName = default)
        {
            _autoCarryCharacter.ImbalancedCharacter(charName);
            AddProperties(_autoCarryCharacter, charName);
            return _autoCarryCharacter;
        }

        public void AddProperties(IAutoCarryCharacter autoCarryCharacter, string charName)
        {
            switch (autoCarryCharacter)
            {
                case IAutoCarryCharacter autoCarry when autoCarry is AutoCarryCharacterBase:
                    new Action(() =>
                    {
                        AutoCarryCharacterBase auto = autoCarryCharacter as AutoCarryCharacterBase;
                        auto.SektorSpecialMoves = RandomEnumValue<SektorSpecialMoves>();
                        auto.FundamentalMoves = RandomEnumValue<FundamentalMoves>();
                        auto.TierList = TierList.Top;
                        auto.CharName = charName;
                        auto.Begetter = PLAYER;
                        auto.Symbol = "AUTOCARRY";
                        WriteLine($"{nameof(VilmarDecorator)} " +
                            $"added additional information to the {_autoCarryCharacter}");
                    })(); break;
                default: WriteLine("An unexpected error occurred."); break; //as a default solution
            }
        }

        //todo: some methods are of optional matter. 7/25/21
    }
}
