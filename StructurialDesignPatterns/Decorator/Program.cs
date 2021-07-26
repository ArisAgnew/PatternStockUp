using System;

using Decorator.AutoCarryDecorator;

namespace StructurialDesignPatterns.Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args is null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            IAutoCarryCharacter autoCarry = new AutoCarryCharacterBase();
            autoCarry.ImbalancedCharacter("Sektor");
            Console.WriteLine($"{autoCarry}\n");

            VilmarDecorator vilmarDecorator = new(autoCarry);
            vilmarDecorator.ImbalancedCharacter();
        }
    }
}
