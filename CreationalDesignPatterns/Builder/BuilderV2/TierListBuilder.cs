using System;

namespace Builder.BuilderV2
{
    internal abstract class TierListBuilder
    {
        protected internal Kharacter _kharacter;

        internal Kharacter Kharacter
        {
            get => _kharacter ?? throw new ArgumentException();
            private init { }
        }

        internal virtual string Game
        {
            get => GetGame();
            protected private init { }
        }

        protected internal abstract string GetGame();

        protected internal abstract TierListBuilder GodTier();
        protected internal abstract TierListBuilder TopTier();
        protected internal abstract TierListBuilder HighTier();
        protected internal abstract TierListBuilder MidTier();
        protected internal abstract TierListBuilder LowTier();
        protected internal abstract TierListBuilder BottomTier();
        protected internal abstract TierListBuilder Build();
    }
}
