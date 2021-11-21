namespace Flyweight.Specimen_1
{
    internal abstract class Character
    {
        protected char symbol;
        protected int width;
        protected int height;
        protected int ascent;
        protected int descent;
        protected int pointSize;

        internal abstract void Display(int pointSize);
    }
}
