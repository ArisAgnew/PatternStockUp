using System;

namespace Decorator.AutoCarryDecorator
{
    public class VilmarDecorator : CharacterDecorator
    {
        public VilmarDecorator(IAutoCarryCharacter autoCarryCharacter) : base(autoCarryCharacter)
        {
        }

        public override IAutoCarryCharacter ImbalancedSektor()
        {
            _autoCarryCharacter.ImbalancedSektor();
            AddProperties(_autoCarryCharacter);
            return _autoCarryCharacter;
        }

        public void AddProperties(IAutoCarryCharacter autoCarryCharacter)
        {
            switch (autoCarryCharacter)
            {
                case IAutoCarryCharacter autoCarry when autoCarry is AutoCarryCharacterBase:
                    new Action(() =>
                    {
                        AutoCarryCharacterBase auto = autoCarryCharacter as AutoCarryCharacterBase;
                        auto.Begetter = "Vilmar";
                        auto.Symbol = "AUTOCARRY";
                        Console.WriteLine($"{nameof(VilmarDecorator)} " +
                            $"added additional information to the {_autoCarryCharacter}");
                    })(); break;
                default: Console.WriteLine("An unexpected error occurred."); break; //as a default solution
            }
        }

        //todo: some methods are of optional matter. 7/25/21
    }
}
