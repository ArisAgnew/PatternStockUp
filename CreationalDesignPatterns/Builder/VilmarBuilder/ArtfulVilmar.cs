namespace Builder.VilmarBuilder
{
    internal class ArtfulVilmar : SektorBuilder
    {
        internal override SektorBuilder InitAgility()
        {
            sektorObject.Agility = "High agility";
            return this;
        }

        internal override SektorBuilder InitAutoCarry()
        {
            sektorObject.AutoCarry = "Top autocarry character";
            return this;
        }

        internal override SektorBuilder InitHighDamageOutput()
        {
            sektorObject.HighDamageOutput = 60D;
            return this;
        }

        internal override SektorBuilder InitReward()
        {
            sektorObject.Reward = "High reward character";
            return this;
        }

        internal override SektorBuilder InitTreacherousSlide()
        {
            sektorObject.TreacherousSlide = -13 & -7;
            return this;
        }

        internal static SektorBuilder Create()
        {
            sektorObject = new();
            return new ArtfulVilmar();
        }
    }
}
