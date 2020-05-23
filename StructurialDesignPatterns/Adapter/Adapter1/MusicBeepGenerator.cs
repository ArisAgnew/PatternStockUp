using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

using static System.Console;

namespace Adapter.Adapter1
{
    //todo: enhance methods, make away with clumsy code 05/23/2020
    internal class MusicBeepGenerator
    {
        internal MusicBeepGenerator() => WriteLine("Music Beep Generator is established");

        internal void MissionImpossible()
        {
            Beep(784, 150);
            Thread.Sleep(300);
            Beep(784, 150);
            Thread.Sleep(300);
            Beep(932, 150);
            Thread.Sleep(150);
            Beep(1047, 150);
            Thread.Sleep(150);
            Beep(784, 150);
            Thread.Sleep(300);
            Beep(784, 150);
            Thread.Sleep(300);
            Beep(699, 150);
            Thread.Sleep(150);
            Beep(740, 150);
            Thread.Sleep(150);
            Beep(784, 150);
            Thread.Sleep(300);
            Beep(784, 150);
            Thread.Sleep(300);
            Beep(932, 150);
            Thread.Sleep(150);
            Beep(1047, 150);
            Thread.Sleep(150);
            Beep(784, 150);
            Thread.Sleep(300);
            Beep(784, 150);
            Thread.Sleep(300);
            Beep(699, 150);
            Thread.Sleep(150);
            Beep(740, 150);
            Thread.Sleep(150);
            Beep(932, 150);
            Beep(784, 150);
            Beep(587, 1200);
            Thread.Sleep(75);
            Beep(932, 150);
            Beep(784, 150);
            Beep(554, 1200);
            Thread.Sleep(75);
            Beep(932, 150);
            Beep(784, 150);
            Beep(523, 1200);
            Thread.Sleep(150);
            Beep(466, 150);
            Beep(523, 150);
        }

        internal void StarWars()
        {
            Beep(300, 500);
            Thread.Sleep(50);
            Beep(300, 500);
            Thread.Sleep(50);
            Beep(300, 500);
            Thread.Sleep(50);
            Beep(250, 500);
            Thread.Sleep(50);
            Beep(350, 250);
            Beep(300, 500);
            Thread.Sleep(50);
            Beep(250, 500);
            Thread.Sleep(50);
            Beep(350, 250);
            Beep(300, 500);
            Thread.Sleep(50);
        }

        internal void HappyBirthday()
        {
            Thread.Sleep(2000);
            Beep(264, 125);
            Thread.Sleep(250);
            Beep(264, 125);
            Thread.Sleep(125);
            Beep(297, 500);
            Thread.Sleep(125);
            Beep(264, 500);
            Thread.Sleep(125);
            Beep(352, 500);
            Thread.Sleep(125);
            Beep(330, 1000);
            Thread.Sleep(250);
            Beep(264, 125);
            Thread.Sleep(250);
            Beep(264, 125);
            Thread.Sleep(125);
            Beep(297, 500);
            Thread.Sleep(125);
            Beep(264, 500);
            Thread.Sleep(125);
            Beep(396, 500);
            Thread.Sleep(125);
            Beep(352, 1000);
            Thread.Sleep(250);
            Beep(264, 125);
            Thread.Sleep(250);
            Beep(264, 125);
            Thread.Sleep(125);
            Beep(2642, 500);
            Thread.Sleep(125);
            Beep(440, 500);
            Thread.Sleep(125);
            Beep(352, 250);
            Thread.Sleep(125);
            Beep(352, 125);
            Thread.Sleep(125);
            Beep(330, 500);
            Thread.Sleep(125);
            Beep(297, 1000);
            Thread.Sleep(250);
            Beep(466, 125);
            Thread.Sleep(250);
            Beep(466, 125);
            Thread.Sleep(125);
            Beep(440, 500);
            Thread.Sleep(125);
            Beep(352, 500);
            Thread.Sleep(125);
            Beep(396, 500);
            Thread.Sleep(125);
            Beep(352, 1000);
        }
    }
}
