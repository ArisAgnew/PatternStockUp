using static Decorator.AutoCarryDecorator.FundamentalMoves;
using static Decorator.AutoCarryDecorator.SektorSpecialMoves;
using static Decorator.AutoCarryDecorator.TierList;

namespace Decorator.AutoCarryDecorator
{
    internal enum FundamentalMoves
    {
        D3,
        Standing_1,
        String_1_1_1_4,
        String_2_1,
        Forward_2_1_2,
        Forward_3
    }

    internal enum SektorSpecialMoves
    {
        FlameBlower,
        StraightMissile,
        VerticalSissile,
        Teleport,
        AirDashPusher
    }

    internal enum TierList
    {
        God, Top, High, Medium, Low, Bottom
    }

    internal class AutoCarryCharacterBase : IAutoCarryCharacter
    {
        private const string CHARACTER_NAME = "Sektor";

        public SektorSpecialMoves SektorSpecialMoves { get; private set; }
        public FundamentalMoves FundamentalMoves { get; private set; }
        public TierList TierList { get; private set; }
        public string CharName { get; internal set; }
        public string Begetter { get; internal set; }
        public string Symbol { get; internal set; }

        public IAutoCarryCharacter ImbalancedCharacter(string charName = default)
        {
            (
                TierList,
                Begetter,
                Symbol
            ) = (Medium, "NetherRealmStudios", "Balanced");
            return this;
        }

        public override string ToString() =>
            $"AutoCarryCharacter " +
                $"[{nameof(SektorSpecialMoves)} => {SektorSpecialMoves}, " +
                $"{nameof(FundamentalMoves)} => {FundamentalMoves}, " +
                $"{nameof(TierList)} => {TierList}, " +
                $"{nameof(Begetter)} => {Begetter}, " +
                $"{nameof(Symbol)} => {Symbol}]\n";

        public override int GetHashCode()
        {
            return base.GetHashCode() * 31 << 3;
        }
    }
}
