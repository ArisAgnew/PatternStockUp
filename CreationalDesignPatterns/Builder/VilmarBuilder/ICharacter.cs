namespace Builder.VilmarBuilder
{
    internal interface ICharacter
    {
        TierList TierList { get; init; }

        void DisplayAbilities();
    }
}
