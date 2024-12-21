using System;
using System.Collections.Generic;
using System.Linq;
using Random = UnityEngine.Random;

namespace IL.Tequila
{
    public static class EnumerableExtensions
    {
        public static bool AllExtra<TSource, TState>(this IEnumerable<TSource> enumerable, TState state, Func<TSource, TState, bool> predicate)
        {
            foreach (var source in enumerable)
            {
                if (!predicate(source, state))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool AnyExtra<TSource, TState>(this IEnumerable<TSource> enumerable, TState state, Func<TSource, TState, bool> predicate)
        {
            foreach (var source in enumerable)
            {
                if (predicate(source, state))
                {
                    return true;
                }
            }

            return false;
        }

        public static IEnumerable<TResult> SelectExtra<TSource, TState, TResult>(this IEnumerable<TSource> enumerable, TState state, Func<TSource, TState, TResult> selector)
        {
            foreach (var source in enumerable)
            {
                yield return selector(source, state);
            }
        }

        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> enumerable)
        {
            return enumerable.OrderBy(static _ => Random.value);
        }

        public static IEnumerable<TSource> WhereExtra<TSource, TState>(this IEnumerable<TSource> enumerable, TState state, Func<TSource, TState, bool> predicate)
        {
            foreach (var source in enumerable)
            {
                if (predicate(source, state))
                {
                    yield return source;
                }
            }
        }

        public static bool TryGetFirst<T>(this IEnumerable<T> enumerable, Func<T, bool> selector, out T item)
        {
            foreach (var currentItem in enumerable)
            {
                if (!selector(currentItem))
                {
                    continue;
                }

                item = currentItem;

                return true;
            }

            item = default;

            return false;
        }

        public static bool TryGetLast<T>(this IEnumerable<T> enumerable, Func<T, bool> selector, out T item)
        {
            var result = false;

            foreach (var currentItem in enumerable)
            {
                if (!selector(currentItem))
                {
                    continue;
                }

                result = true;
                item = currentItem;
            }

            item = default;

            return result;
        }
    }
}
