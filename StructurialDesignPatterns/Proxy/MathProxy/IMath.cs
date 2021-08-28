using System;

using static System.Console;

namespace Proxy.MathProxy
{
    internal interface IMath
    {
        Func<double, double, double> NotOperable
        {
            get => (a, b) => double.NaN;
            protected set { }
        }

        Func<double, double, double> Add
        {
            get => (a, b) => a + b;
            protected set { }
        }

        Func<double, double, double> Substract
        {
            get => (a, b) => a - b;
            protected set { }
        }

        Func<double, double, double> Multiply
        {
            get => (a, b) => a * b;
            protected set { }
        }

        Func<double, double, double> Divide
        {
            get
            {
                var result = default(Func<double, double, double>);
                try
                {
                    result = (a, b) => a / b;
                }
                catch (DivideByZeroException)
                {
                    WriteLine($"Division by zero detected.");
                }
                return result;
            }
            protected set { }
        }
    }
}
