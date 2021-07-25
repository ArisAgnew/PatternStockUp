using System;

using Decorator.AutoCarryDecorator;

namespace StructurialDesignPatterns.Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            IAutoCarryCharacter autoCarry = new AutoCarryCharacterBase();
            autoCarry.ImbalancedCharacter();
            Console.WriteLine($"{autoCarry}\n");

            VilmarDecorator vilmarDecorator = new(autoCarry);
            vilmarDecorator.ImbalancedCharacter();
        }

        internal static class EnumHelper
        {
            private static Random _random = new Random();

            internal static T RandomEnumValue<T>() where T : Enum
            {
                Array values = Enum.GetValues(typeof(T));
                return (T)values.GetValue(_random.Next(values.Length));
            }
        }
    }
}
