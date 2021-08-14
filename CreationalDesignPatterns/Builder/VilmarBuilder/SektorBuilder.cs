using System;

namespace Builder.VilmarBuilder
{
    //todo 7/31/21: Chances are, this class potentially ought to be omitted;
    internal abstract class SektorBuilder
    {
        protected static Sektor sektorObject;

        internal Sektor Build
        {
            get => sektorObject
                ?? throw new Exception($"{nameof(Sektor)} has null value");
            private init { }
        }

        internal abstract SektorBuilder InitAutoCarry();
        internal abstract SektorBuilder InitTreacherousSlide();
        internal abstract SektorBuilder InitAgility();
        internal abstract SektorBuilder InitReward();
        internal abstract SektorBuilder InitHighDamageOutput();        
    }
}
