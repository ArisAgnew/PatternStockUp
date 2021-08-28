using System;

namespace Proxy.MathProxy
{
    enum MathOperation { None, Add, Sub, Mul, Div }

    internal class MathImpl : IMath { }

    internal struct MathProxyProvider
    {
        internal static Func<double, double, double> Release<T>(ref T self, MathOperation mathOperation)
            where T : IMath
        {
            if (self is not null)
            {
                switch (mathOperation)
                {
                    case MathOperation.Add: return self.Add;
                    case MathOperation.Sub: return self.Substract;
                    case MathOperation.Mul: return self.Multiply;
                    case MathOperation.Div: return self.Divide;
                }
            }
            return self.NotOperable;
        }
    }
}
