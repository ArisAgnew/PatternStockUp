using System.Collections;
using System.Collections.Generic;

namespace UsefulStuff
{
    public class FibonacciBase : IEnumerable<uint>
    {
        private uint _number;

        public uint Number
        {
            get => _number;
            init
            {
                if (_number != value)
                {
                    _number = value;
                }
            }
        }

        private IEnumerable<uint> Fibonacci()
        {
            uint a = 0, b = 1;

            if (_number >= 1)
            {
                yield return 0;
                yield return 1;
            }

            for (var i = 2; i <= _number; ++i)
            {
                uint f = a + b;
                a = b;
                b = f;

                yield return f;
            }
        }

        public IEnumerator<uint> GetEnumerator() => Fibonacci().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
