using static MiscellaneousStuff.ProgressBar.Solution_1.ConsoleUtility;
using static System.Console;
using static System.Threading.Thread;

namespace MiscellaneousStuff.ProgressBar.Solution_1
{
    internal class ProgressBarLauncher1
    {
        public static void Main(string[] args)
        {
            for (var i = 0; i <= 100; ++i)
            {
                WriteProgressBar(i, true);
                Sleep(50);
            }
        }
    }

    internal static class ConsoleUtility
    {
        private const char _block = (char)0x23;
        private const string _back = "\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b";
        private const string _twirl = "-\\|/";

        public static void WriteProgressBar(int percent, bool update = false)
        {
            if (update)
            {
                Write(_back);
            }
            Write("[");
            var p = (int)((percent / 10f) + .5f);
            for (var i = 0; i < 10; ++i)
            {
                if (i >= p) Write(' ');
                else Write(_block);
            }
            Write("] {0,3:##0}%", percent);
        }

        public static void WriteProgress(int progress, bool update = false)
        {
            if (update)
            {
                Write("\b");
            }
            Write(_twirl[progress % _twirl.Length]);
        }
    }
}
