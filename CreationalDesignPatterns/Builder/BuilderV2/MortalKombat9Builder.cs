using static Builder.BuilderV2.CharacterEnum;
using static Builder.BuilderV2.TierEnum;

namespace Builder.BuilderV2
{
    internal class MortalKombat9Builder : TierListBuilder
    {
        static MortalKombat9Builder() { }

        private MortalKombat9Builder() => _kharacter = new()
        {
            Game = GetGame()
        };

        protected internal override TierListBuilder BottomTier()
        {
            _kharacter[Sheeva] = Bottom;
            return this;
        }

        protected internal override TierListBuilder GodTier()
        {
            _kharacter[Kabal] = God;
            return this;
        }

        protected internal override TierListBuilder HighTier()
        {
            _kharacter[Jax] = High;
            return this;
        }

        protected internal override TierListBuilder LowTier()
        {
            _kharacter[Stryker] = Low;
            return this;
        }

        protected internal override TierListBuilder MidTier()
        {
            _kharacter[Scorpion] = Medium;
            return this;
        }

        protected internal override TierListBuilder TopTier()
        {
            _kharacter[Sonya] = Top;
            return this;
        }

        protected internal override TierListBuilder Build()
        {
            return this;
        }

        internal static TierListBuilder Initialize() => new MortalKombat9Builder();

        protected internal override string GetGame() => "Mortal Kombat 9";
    }
}
