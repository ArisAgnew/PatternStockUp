using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;

using System.Runtime.InteropServices;

namespace SporadicBitmap
{
    internal class Program
    {
        private static readonly byte[] _imageBuffer = new byte[4 * 256 * 100];

        static void Main(string[] args)
        {
            //var bitmap = new Bitmap(640, 480);

            ColourBase colourBase = default;

            for (uint y = default; y < 101; ++y)
            {
                for (uint x = default; x < 256; ++x)
                {
                    byte byteValue = (byte)x;
                    colourBase = new ColourBase(x, y)
                    {
                        Red = byteValue,
                        Green = byteValue,
                        Blue = byteValue,
                    };

                    colourBase.PlotPixel();
                    colourBase.SaveImageAs(ImageFormat.Png, y);

                    /*Console.WriteLine($"{y} & {x} |> " +
                        $"{colourBase.Red} & {colourBase.Green} & {colourBase.Blue}");*/
                }
            }

            //Console.ReadLine();
        }
    }

    internal sealed class ColourBase
    {
        private static readonly byte[] _imageBuffer = new byte[4 * 256 * 256];

        private const byte UPPERBOUND = 0xFF;
        private const byte LOWERBOUND = 0x00;

        private readonly byte[] _blackPixel = new byte[3] { default, default, default };
        private readonly byte[] _redPixel = new byte[3] { UPPERBOUND, default, default };
        private readonly byte[] _greenPixel = new byte[3] { default, UPPERBOUND, default };
        private readonly byte[] _bluePixel = new byte[3] { default, default, UPPERBOUND };
        private readonly byte[] _whitePixel = new byte[3] { UPPERBOUND, UPPERBOUND, UPPERBOUND };

        private readonly uint _x = default;
        private readonly uint _y = default;

        private byte _red = default;
        private byte _green = default;
        private byte _blue = default;

        internal ColourBase(uint x, uint y) => (_x, _y) = (x, y);

        internal byte[] BlackPixel { get => _blackPixel; }
        internal byte[] RedPixel { get => _redPixel; }
        internal byte[] GreenPixel { get => _greenPixel; }
        internal byte[] BluePixel { get => _bluePixel; }
        internal byte[] WhitePixel { get => _whitePixel; }

        internal byte Red { get => _red; set => _red = value; }
        internal byte Green { get => _green; set => _green = value; }
        internal byte Blue { get => _blue; set => _blue = value; }

        internal void PlotPixel()
        {
            uint offset = ((4 * 256) * _y) + (_x * 4);

            _imageBuffer[offset] = _red; //RedPixel[0];
            _imageBuffer[offset + 1] = _green;
            _imageBuffer[offset + 2] = _blue;
            _imageBuffer[offset + 3] = UPPERBOUND; // No transparency            
        }

        internal unsafe void SaveImageAs(in ImageFormat imageFormat, in uint counter)
        {
            const string fileName = "probe";

            ImageFormat[] rasterFormats = new ImageFormat[]
            {
                ImageFormat.Bmp, ImageFormat.Emf, ImageFormat.Wmf,
                ImageFormat.Gif, ImageFormat.Jpeg, ImageFormat.Png,
                ImageFormat.Tiff, ImageFormat.Exif, ImageFormat.Icon
            };

            var loweredFormatValue = imageFormat.ToString().ToLower();

            if (!rasterFormats.Contains(imageFormat))
            {
                return;
            }

            using (var image = new Bitmap(512, 512, PixelFormat.Format32bppRgb))
            {
                try
                {
                    image.Save($@"{fileName}{counter}.{loweredFormatValue}", imageFormat);
                }
                catch (ExternalException externalExp)
                {
                    Console.WriteLine($"No need to open up the image file while programm is running");
                    Console.WriteLine(externalExp.Message);
                }
            }
        }
    }
}
