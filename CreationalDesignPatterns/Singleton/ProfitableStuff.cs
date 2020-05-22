using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Singleton
{
    internal static class ProfitableStuff
    {
        public static string DoStringReversed(this string str, bool uppercase = false)
        {
            string result = default;

            return str.OfType<char>()
                .Select(c => result = c + result)
                .Aggregate(default(string),
                           (start, end) => end,
                           end =>
                           {
                               if (uppercase) 
                                   return end.ToUpper();
                               return end;
                           });
        }
    }
}
