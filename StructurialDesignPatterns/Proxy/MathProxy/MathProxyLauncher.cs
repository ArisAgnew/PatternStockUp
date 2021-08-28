#define WITH_ARGS
#define WITH_NO_ARGS

using static System.Console;
using static Proxy.MathProxy.MathOperation;
using static Proxy.MathProxy.MathProxyProvider;

namespace Proxy.MathProxy
{
    /// <summary>
    /*  
        The Proxy design pattern provides a surrogate or
        placeholder for another object to control access to it.
        maintains a reference that lets the proxy access the real subject. Proxy may refer to a Subject 
        if the RealSubject and Subject interfaces are the same.
        provides an interface identical to Subject's so that a proxy can be substituted for for the real subject.
        controls access to the real subject and may be responsible for creating and deleting it.
        other responsibilites depend on the kind of proxy:
        1. remote proxies are responsible for encoding a request and 
            its arguments and for sending the encoded request to the real subject in a different address space.
        2. virtual proxies may cache additional information about the real subject 
            so that they can postpone accessing it. 
            For example, the ImageProxy from the Motivation caches the real images's extent.
        3. protection proxies check that the caller has the access permissions required to perform a request.
    */
    /// </summary>
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
