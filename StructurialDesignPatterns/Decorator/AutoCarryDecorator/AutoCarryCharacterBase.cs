using System.ComponentModel;

using static Decorator.AutoCarryDecorator.FundamentalMoves;
using static Decorator.AutoCarryDecorator.SektorSpecialMoves;
using static Decorator.AutoCarryDecorator.TierList;

namespace Decorator.AutoCarryDecorator
{
    [DefaultValue(None)]
    internal enum FundamentalMoves
    {
        None,
        D3,
        Standing_1,
        String_1_1_1_4,
        String_2_1,
        Forward_2_1_2,
        Forward_3
    }

    [DefaultValue(None)]
    internal enum SektorSpecialMoves
    {
        None,
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
        public SektorSpecialMoves SektorSpecialMoves { get; internal set; }
        public FundamentalMoves FundamentalMoves { get; internal set; }
        public TierList TierList { get; internal set; }
        public string CharName { get; internal set; }
        public string Begetter { get; internal set; }

        public string Symbol { get; internal set; }

        public IAutoCarryCharacter ImbalancedCharacter(string charName = default)
        {
            (
                SektorSpecialMoves,
                FundamentalMoves,
                TierList,
                Begetter,
                Symbol
            ) =
            (
                Medium,
                "NetherRealmStudios",
                "Balanced"
            );
            return this;
        }

        public override string ToString() =>
            $"AutoCarryCharacter " +
                $"\n[{nameof(SektorSpecialMoves)} => {SektorSpecialMoves};\n" +
                $"{nameof(FundamentalMoves)} => {FundamentalMoves};\n" +
                $"{nameof(TierList)} => {TierList};\n" +
                $"{nameof(Begetter)} => {Begetter};\n" +
                $"{nameof(Symbol)} => {Symbol}]\n";

        public override int GetHashCode()
        {
            return base.GetHashCode() * 31 << 3;
        }
    }
}
