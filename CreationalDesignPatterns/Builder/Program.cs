using Builder;

namespace CreationalDesignPatterns.Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            ArtfulVilmar.Create()
                .InitAgility()
                .InitAutoCarry()
                .InitHighDamageOutput()
                .InitReward()
                .InitTrecherousSlide()
                .Build
                .DisplayAbilities();
            //it worked off; either way, it's not optimal way of implementing the builder
            //pattern that way. 7/31/21
        }
    }
}
