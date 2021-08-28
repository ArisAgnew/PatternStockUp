namespace Builder.BuilderV2
{
    internal class BuilderV2Launcher
    {
        static void Main(string[] args)
        {
            TierListBuilder tierListBuilder = default;

            #region MortalKombat9Builder
            (tierListBuilder = MortalKombat9Builder.Initialize())
                .GodTier()
                .TopTier()
                .HighTier()
                .MidTier()
                .LowTier()
                .BottomTier()
                .Build();

            tierListBuilder.Kharacter.Display();
            #endregion MortalKombat9Builder
        }
    }
}
