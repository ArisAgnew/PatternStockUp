using System;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;

using static System.Console;

namespace BehavioralDesignPatterns.Observer.ObservableCollection
{
    internal class OCollection<T> where T : class, new()
    {
        public ObservableCollection<T> Collection { get; private set; }

        public OCollection() => Collection = new ObservableCollection<T>();

        public OCollection<T> Allocate(T item) =>
            new Func<OCollection<T>>(() => { Collection.Add(item); return this; })();

        public OCollection<T> Remove(T item) => WrapUp(() => { Collection.Remove(item); return this; });

        public OCollection<T> RemoveAt(int index) => WrapUp(() => { Collection.RemoveAt(index); return this; });

        public OCollection<T> Insert(int index, T item) => WrapUp(() => { Collection.Insert(index, item); return this; });

        private OCollection<T> WrapUp(Func<OCollection<T>> supplier) =>
            Collection.Count > 0
                ? supplier?.Invoke()
                : new Func<OCollection<T>>(() => this)();

        public static void CollectionChanged_ToAdd(object o, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                T _new = e.NewItems[0] as T;

                Write($"New index when added: {e.NewStartingIndex};");

                _new?.GetType()
                    .GetProperties()
                    .Select(p => p.GetValue(_new))
                    .ToImmutableList()
                    .ForEach(v => Write($"\tNew object added: <{v}>\n"));
            }
        }

        public static void CollectionChanged_ToRemove(object o, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                T _old = e.OldItems[0] as T;

                Write($"Index when removed: {e.OldStartingIndex};");

                _old?.GetType()
                    .GetProperties()
                    .Select(p => p.GetValue(_old))
                    .ToImmutableList()
                    .ForEach(v => Write($"\tObject removed: <{v}>\n"));
            }
        }

        public static void CollectionChanged_ToReplace(object o, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Replace)
            {
                T replaced = e.OldItems[0] as T;
                T replacing = e.NewItems[0] as T;

                replaced.GetType()
                    .GetProperties()
                    .Zip(replacing.GetType().GetProperties(), (r_d, r_ing) => new { r_d, r_ing })
                    .ToDictionary(x => x.r_d, y => y.r_ing)
                    .ToImmutableDictionary(x => x.Key.GetValue(replaced), y => y.Value.GetValue(replacing))
                    //.ToLookup(x => x.Key, x => x.Key) no need to keep on using
                    .DictionaryForEach(pair => WriteLine($"Object <{pair.Key}> has been substituted <{pair.Value}>"));
            }
        }
    }
}
