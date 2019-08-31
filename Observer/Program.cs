using System.Collections.Generic;
using System.Linq;
using Observer.Observers;
using UsefulStuff;

#nullable enable
namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            GetNums(start: 0L, howMuch: 100L, step: 25L).ToList().ForEach(n =>
                {
                    using var subject = new Subject();

                    $"I N B O U N D  N U M B E R :: {subject.State = n}".Depict(leftLine: true, rightLine: true);

                    new BinaryObserver().Update(subject);
                    new OctalObserver().Update(subject);
                    new HexObserver().Update(subject);
                });

            IEnumerable<long> GetNums(long start = default, long howMuch = default, long step = default)
            {
                for (long i = start; i <= howMuch; i += step)
                {
                    if (howMuch == default || howMuch < step)
                        yield break;
                    yield return i;
                }
            }
        }
    }
}
