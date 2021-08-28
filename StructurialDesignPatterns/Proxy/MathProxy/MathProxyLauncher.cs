#define WITH_ARGS
#define WITH_NO_ARGS

using static System.Console;
using static Proxy.MathProxy.MathOperation;
using static Proxy.MathProxy.MathProxyProvider;

namespace Proxy.MathProxy
{
    internal class MathProxyLauncher
    {
        static void Main(string[] args)
        {
            MathImpl mathImpl = new();
#if WITH_NO_ARGS
            WriteLine(Release(ref mathImpl, Add)(7, 5)); // 12
            WriteLine(Release(ref mathImpl, Sub)(7, 5)); // 2
            WriteLine(Release(ref mathImpl, Mul)(7, 5)); // 35
            WriteLine(Release(ref mathImpl, Div)(7, 5)); // 1.4
            WriteLine(Release(ref mathImpl, None)(7, 7)); // NaN
#elif WITH_ARGS
            var data =
            (
                first: double.Parse(args[0]),
                second: double.Parse(args[1]),
                operation: new Func<MathOperation>(() =>
                {
                    MathOperation mathOperation = default;
                    try
                    {
                        mathOperation = (MathOperation)Enum
                            .Parse(typeof(MathOperation), args[2], ignoreCase: true);
                    }
                    catch (Exception e)
                    {
                        WriteLine("Something went wrong;");
                        WriteLine(e.Message + "\n" + e.StackTrace);
                    }
                    return mathOperation;
                })()
            );

            WriteLine(Release(ref mathImpl, data.operation)(data.first, data.second));
#endif
        }
    }
}
