using System;
using System.Collections.Generic;

namespace Tequila.Extensions
{
    public static class EnumerableExtensions
    {
        public static bool AllNonAlloc<TSource, TData>(this IEnumerable<TSource> enumerable, TData data, Func<(TSource Source, TData Data), bool> predicate)
        {
            foreach (var source in enumerable)
            {
                if (!predicate((source, data)))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool AnyNonAlloc<TSource, TData>(this IEnumerable<TSource> enumerable, TData data, Func<(TSource Source, TData Data), bool> predicate)
        {
            foreach (var source in enumerable)
            {
                if (predicate((source, data)))
                {
                    return true;
                }
            }

            return false;
        }

        public static IEnumerable<TResult> SelectNonAlloc<TSource, TData, TResult>(this IEnumerable<TSource> enumerable, TData data, Func<(TSource Source, TData Data), TResult> selector)
        {
            foreach (var source in enumerable)
            {
                yield return selector((source, data));
            }
        }

        public static IEnumerable<TSource> WhereNonAlloc<TSource, TData>(this IEnumerable<TSource> enumerable, TData data, Func<(TSource Source, TData Data), bool> predicate)
        {
            foreach (var source in enumerable)
            {
                if (predicate((source, data)))
                {
                    yield return source;
                }
            }
        }
    }
}
