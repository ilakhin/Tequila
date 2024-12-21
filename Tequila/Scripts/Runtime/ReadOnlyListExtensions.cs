using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace IL.Tequila
{
    public static class ReadOnlyListExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T GetRandomOrDefault<T>(this IReadOnlyList<T> readOnlyList)
        {
            return TryGetRandom(readOnlyList, out var item, static (min, max) => RandomUtility.GetRandomInt32(min, max)) ? item : default;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T GetRandomOrDefault<T>(this IReadOnlyList<T> readOnlyList, GetRandomInt32 getRandom)
        {
            return TryGetRandom(readOnlyList, out var item, getRandom) ? item : default;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T GetRandomOrFallback<T>(this IReadOnlyList<T> readOnlyList, T fallback)
        {
            return TryGetRandom(readOnlyList, out var item, static (min, max) => RandomUtility.GetRandomInt32(min, max)) ? item : fallback;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T GetRandomOrFallback<T>(this IReadOnlyList<T> readOnlyList, T fallback, GetRandomInt32 getRandom)
        {
            return TryGetRandom(readOnlyList, out var item, getRandom) ? item : fallback;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetRandom<T>(this IReadOnlyList<T> readOnlyList, out T item)
        {
            return TryGetRandom(readOnlyList, out item, static (min, max) => RandomUtility.GetRandomInt32(min, max));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetRandom<T>(this IReadOnlyList<T> readOnlyList, out T item, GetRandomInt32 getRandom)
        {
            if (readOnlyList.Count > 0)
            {
                var index = getRandom(0, readOnlyList.Count - 1);

                item = readOnlyList[index];

                return true;
            }

            item = default;

            return false;
        }

        public static bool TryGetFirst<T>(this IReadOnlyList<T> readOnlyList, Func<T, bool> selector, out T item)
        {
            for (int i = 0, count = readOnlyList.Count; i < count; i++)
            {
                if (!selector(readOnlyList[i]))
                {
                    continue;
                }

                item = readOnlyList[i];

                return true;
            }

            item = default;

            return false;
        }

        public static bool TryGetFirstIndexOf<T>(this IReadOnlyList<T> readOnlyList, Func<T, bool> selector, out int index)
        {
            for (int i = 0, count = readOnlyList.Count; i < count; i++)
            {
                if (!selector(readOnlyList[i]))
                {
                    continue;
                }

                index = i;

                return true;
            }

            index = -1;

            return false;
        }

        public static bool TryGetLast<T>(this IReadOnlyList<T> readOnlyList, Func<T, bool> selector, out T item)
        {
            for (var i = readOnlyList.Count - 1; i >= 0; i--)
            {
                if (!selector(readOnlyList[i]))
                {
                    continue;
                }

                item = readOnlyList[i];

                return true;
            }

            item = default;

            return false;
        }

        public static bool TryGetLastIndexOf<T>(this IReadOnlyList<T> readOnlyList, Func<T, bool> selector, out int index)
        {
            for (var i = readOnlyList.Count - 1; i >= 0; i--)
            {
                if (!selector(readOnlyList[i]))
                {
                    continue;
                }

                index = i;

                return true;
            }

            index = -1;

            return false;
        }
    }
}
