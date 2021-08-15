using System.ComponentModel;

using static System.Console;

namespace Builder.VilmarBuilder
{
    [DefaultValue(None)]
    internal enum TierList
    {
        None, God, Top, High, Medium, Low, Bottom
    }

    internal class Sektor : ICharacter
    {
        private TierList _tierList = default;

        public Sektor() { }

        public object AutoCarry { get; set; }
        public object TreacherousSlide { get; set; }
        public object Agility { get; set; }
        public object Reward { get; set; }
        public object HighDamageOutput { get; set; }
        public TierList TierList
        {
            get => _tierList;
            init
            {
                if (value is default(TierList))
                {
                    _tierList = value;
                }
            }
        }

        public void DisplayAbilities()
        {
            WriteLine($"{nameof(AutoCarry)} : {AutoCarry}");
            WriteLine($"{nameof(TreacherousSlide)} : {TreacherousSlide}");
            WriteLine($"{nameof(Agility)} : {Agility}");
            WriteLine($"{nameof(Reward)} : {Reward}");
            WriteLine($"{nameof(HighDamageOutput)} : {HighDamageOutput}");
            WriteLine($"{nameof(TierList)} : {TierList}");
        }
    }
}
