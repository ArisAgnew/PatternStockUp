namespace Flyweight.Specimen_1
{
    internal interface ICharacter
    {
        internal char Symbol { get => default; set { } }
        internal int Width { get => default; set { } }
        internal int Height { get => default; set { } }
        internal int Ascent { get => default; set { } }
        internal int Descent { get => default; set { } }
        internal int PointSize { get => default; set { } }
    }
}
