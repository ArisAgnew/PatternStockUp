using static System.Console;

namespace Flyweight.Specimen_1
{
    internal class CharacterSet
    {
        internal class CharacterDefault : Character
        {
            internal CharacterDefault()
            {
                symbol = default;
                height = default;
                width = default;
                ascent = default;
                descent = default;
            }

            internal override void Display(int pointSize)
            {
                this.pointSize = pointSize;
                WriteLine($"[{symbol}] ({nameof(pointSize)} {this.pointSize})");
            }
        }

        internal class CharacterA : Character
        {
            internal CharacterA()
            {
                symbol = 'A';
                height = 100;
                width = 120;
                ascent = 70;
                descent = 0;
            }

            internal override void Display(int pointSize)
            {
                this.pointSize = pointSize;
                WriteLine($"[{symbol}] ({nameof(pointSize)} {this.pointSize})");
            }
        }

        internal class CharacterB : Character
        {
            internal CharacterB()
            {
                symbol = 'B';
                height = 100;
                width = 140;
                ascent = 72;
                descent = 0;
            }

            internal override void Display(int pointSize)
            {
                this.pointSize = pointSize;
                WriteLine($"[{symbol}] ({nameof(pointSize)} {this.pointSize})");
            }
        }

        internal class CharacterZ : Character
        {
            internal CharacterZ()
            {
                symbol = 'Z';
                height = 100;
                width = 100;
                ascent = 68;
                descent = 0;
            }

            internal override void Display(int pointSize)
            {
                this.pointSize = pointSize;
                WriteLine($"[{symbol}] ({nameof(pointSize)} {this.pointSize})");
            }
        }
    }
}
