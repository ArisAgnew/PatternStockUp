namespace Builder
{
    internal interface ICharacter
    {
        TierList TierList { get; init; }

        void DisplayAbilities();
    }
}
