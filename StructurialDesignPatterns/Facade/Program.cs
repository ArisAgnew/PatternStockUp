using System;

namespace StructurialDesignPatterns.Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            (Func<string, string> result, _) = EvaluateJavaScript<string, string>(a => a + "3");

            Console.WriteLine(result.Invoke("2"));
        }

        public static (SomeThingFunc<A, B>, Func<A, B>) EvaluateJavaScript<A, B>(Func<A, B> func) =>
            (new SomeThingFunc<A, B>(func), func);
    }

    public class SomeThingFunc<In, Out>
    {
        private Func<In, Out> _func;
        private In _in;
        private Out _out;

        public SomeThingFunc(Func<In, Out> func) => _func = func;
        public SomeThingFunc(In @in, Out @out)
        {
            _in = @in;
            _out = @out;
        }
        public Out Apply(In type) => _func.Invoke(type);

        public static implicit operator Func<In, Out>(SomeThingFunc<In, Out> v)
        {
            return v._func;
        }
    }
}
