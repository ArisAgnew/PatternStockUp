namespace Decorator.AutoCarryDecorator
{
    public interface IAutoCarryCharacter : IGame
    {
        IAutoCarryCharacter ImbalancedCharacter(string charName = default);
    }
}
