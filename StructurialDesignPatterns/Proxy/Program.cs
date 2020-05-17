using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StructurialDesignPatterns.Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = Singleton.GetInstance();
            Console.WriteLine(s.Name);
        }
    }
    public class Singleton
    {
        private static readonly Lazy<Singleton> lazy =
            new Lazy<Singleton>(() => new Singleton());

        public string Name { get; private set; }

        private Singleton()
        {
            Name = Guid.NewGuid().ToString();
        }

        public static Singleton GetInstance()
        {
            return lazy.Value;
        }
    }
}
