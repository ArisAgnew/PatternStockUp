using System;
using System.Collections.Generic;

namespace BehavioralDesignPatterns.Observer.ObservableCollection
{
    public static class ExtentionLinq
    {
        public static void DictionaryForEach<K, V>(this IEnumerable<KeyValuePair<K, V>> source,
                                                        Action<KeyValuePair<K, V>> action)
        {
            foreach (KeyValuePair<K, V> item in source)
            {
                action.Invoke(item);
            }
        }
    }
}
