using static System.Console;
using static System.TimeSpan;

namespace Adapter.Adapter1
{
    internal class SimpleBeepGenerator
    {
        internal SimpleBeepGenerator() => WriteLine("Simple Beep Generator is established");

        internal protected void BeepDefault(in double duration) => 
            Beep(frequency: 37, duration: (int)FromSeconds(duration).TotalMilliseconds);

        internal protected void BeepUpper(in double duration) =>
            Beep(frequency: 32767, duration: (int)FromSeconds(duration).TotalMilliseconds);

        internal protected void BeepPerls(in double duration)
        {
            var initialBound = 37;
            var endBound = 32767;

            for (int i = initialBound; i <= endBound; i += 200)
            {
                Beep(frequency: i, duration: (int)FromSeconds(duration).TotalMilliseconds);
            }
        }
    }
}
