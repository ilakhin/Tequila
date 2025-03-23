using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace IL.Tequila
{
    public static class ReadOnlyCollectionExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T GetRandomOrDefault<T>(this IReadOnlyCollection<T> readOnlyCollection, GetWeightInt32<T> getWeight)
        {
            return TryGetRandom(readOnlyCollection, out var item, getWeight, static (min, max) => RandomUtility.GetRandomInt32(min, max)) ? item : default;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T GetRandomOrDefault<T>(this IReadOnlyCollection<T> readOnlyCollection, GetWeightSingle<T> getWeight)
        {
            return TryGetRandom(readOnlyCollection, out var item, getWeight, static (min, max) => RandomUtility.GetRandomSingle(min, max)) ? item : default;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T GetRandomOrDefault<T>(this IReadOnlyCollection<T> readOnlyCollection, GetWeightInt32<T> getWeight, GetRandomInt32 getRandom)
        {
            return TryGetRandom(readOnlyCollection, out var item, getWeight, getRandom) ? item : default;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T GetRandomOrDefault<T>(this IReadOnlyCollection<T> readOnlyCollection, GetWeightSingle<T> getWeight, GetRandomSingle getRandom)
        {
            return TryGetRandom(readOnlyCollection, out var item, getWeight, getRandom) ? item : default;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T GetRandomOrFallback<T>(this IReadOnlyCollection<T> readOnlyCollection, T fallback, GetWeightInt32<T> getWeight)
        {
            return TryGetRandom(readOnlyCollection, out var item, getWeight, static (min, max) => RandomUtility.GetRandomInt32(min, max)) ? item : fallback;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T GetRandomOrFallback<T>(this IReadOnlyCollection<T> readOnlyCollection, T fallback, GetWeightSingle<T> getWeight)
        {
            return TryGetRandom(readOnlyCollection, out var item, getWeight, static (min, max) => RandomUtility.GetRandomSingle(min, max)) ? item : fallback;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T GetRandomOrFallback<T>(this IReadOnlyCollection<T> readOnlyCollection, T fallback, GetWeightInt32<T> getWeight, GetRandomInt32 getRandom)
        {
            return TryGetRandom(readOnlyCollection, out var item, getWeight, getRandom) ? item : fallback;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T GetRandomOrFallback<T>(this IReadOnlyCollection<T> readOnlyCollection, T fallback, GetWeightSingle<T> getWeight, GetRandomSingle getRandom)
        {
            return TryGetRandom(readOnlyCollection, out var item, getWeight, getRandom) ? item : fallback;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetRandom<T>(this IReadOnlyCollection<T> readOnlyCollection, out T item, GetWeightInt32<T> getWeight)
        {
            return TryGetRandom(readOnlyCollection, out item, getWeight, static (min, max) => RandomUtility.GetRandomInt32(min, max));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetRandom<T>(this IReadOnlyCollection<T> readOnlyCollection, out T item, GetWeightSingle<T> getWeight)
        {
            return TryGetRandom(readOnlyCollection, out item, getWeight, static (min, max) => RandomUtility.GetRandomSingle(min, max));
        }

        public static bool TryGetRandom<T>(this IReadOnlyCollection<T> readOnlyCollection, out T item, GetWeightInt32<T> getWeight, GetRandomInt32 getRandom)
        {
            var arrayPool = ArrayPool<(T Item, int Weight)>.Shared;
            var cachedItems = arrayPool.Rent(readOnlyCollection.Count);

            try
            {
                var index = 0;

                foreach (var currentItem in readOnlyCollection)
                {
                    var weight = getWeight(currentItem);

                    cachedItems[index] = (currentItem, weight);
                    index++;
                }

                return TryGetRandom(cachedItems, out item, getRandom);
            }
            finally
            {
                arrayPool.Return(cachedItems, true);
            }
        }

        public static bool TryGetRandom<T>(this IReadOnlyCollection<T> readOnlyCollection, out T item, GetWeightSingle<T> getWeight, GetRandomSingle getRandom)
        {
            var arrayPool = ArrayPool<(T Item, float Weight)>.Shared;
            var cachedItems = arrayPool.Rent(readOnlyCollection.Count);

            try
            {
                var index = 0;

                foreach (var currentItem in readOnlyCollection)
                {
                    var weight = getWeight(currentItem);

                    cachedItems[index] = (currentItem, weight);
                    index++;
                }

                return TryGetRandom(cachedItems, out item, getRandom);
            }
            finally
            {
                arrayPool.Return(cachedItems, true);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T GetRandomOrDefault<T>(this IReadOnlyCollection<(T Item, int Weight)> readOnlyCollection)
        {
            return TryGetRandom(readOnlyCollection, out var item, static (min, max) => RandomUtility.GetRandomInt32(min, max)) ? item : default;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T GetRandomOrDefault<T>(this IReadOnlyCollection<(T Item, float Weight)> readOnlyCollection)
        {
            return TryGetRandom(readOnlyCollection, out var item, static (min, max) => RandomUtility.GetRandomSingle(min, max)) ? item : default;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T GetRandomOrDefault<T>(this IReadOnlyCollection<(T Item, int Weight)> readOnlyCollection, GetRandomInt32 getRandom)
        {
            return TryGetRandom(readOnlyCollection, out var item, getRandom) ? item : default;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T GetRandomOrDefault<T>(this IReadOnlyCollection<(T Item, float Weight)> readOnlyCollection, GetRandomSingle getRandom)
        {
            return TryGetRandom(readOnlyCollection, out var item, getRandom) ? item : default;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T GetRandomOrFallback<T>(this IReadOnlyCollection<(T Item, int Weight)> readOnlyCollection, T fallback)
        {
            return TryGetRandom(readOnlyCollection, out var item, static (min, max) => RandomUtility.GetRandomInt32(min, max)) ? item : fallback;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T GetRandomOrFallback<T>(this IReadOnlyCollection<(T Item, float Weight)> readOnlyCollection, T fallback)
        {
            return TryGetRandom(readOnlyCollection, out var item, static (min, max) => RandomUtility.GetRandomSingle(min, max)) ? item : fallback;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T GetRandomOrFallback<T>(this IReadOnlyCollection<(T Item, int Weight)> readOnlyCollection, T fallback, GetRandomInt32 getRandom)
        {
            return TryGetRandom(readOnlyCollection, out var item, getRandom) ? item : fallback;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T GetRandomOrFallback<T>(this IReadOnlyCollection<(T Item, float Weight)> readOnlyCollection, T fallback, GetRandomSingle getRandom)
        {
            return TryGetRandom(readOnlyCollection, out var item, getRandom) ? item : fallback;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetRandom<T>(this IReadOnlyCollection<(T Item, int Weight)> readOnlyCollection, out T item)
        {
            return TryGetRandom(readOnlyCollection, out item, static (min, max) => RandomUtility.GetRandomInt32(min, max));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetRandom<T>(this IReadOnlyCollection<(T Item, float Weight)> readOnlyCollection, out T item)
        {
            return TryGetRandom(readOnlyCollection, out item, static (min, max) => RandomUtility.GetRandomSingle(min, max));
        }

        public static bool TryGetRandom<T>(this IReadOnlyCollection<(T Item, int Weight)> readOnlyCollection, out T item, GetRandomInt32 getRandom)
        {
            var totalWeight = readOnlyCollection.Sum(static tuple => tuple.Weight);
            var targetWeight = getRandom(0, totalWeight);

            foreach (var (currentItem, weight) in readOnlyCollection)
            {
                if (targetWeight > weight)
                {
                    targetWeight -= weight;

                    continue;
                }

                item = currentItem;

                return true;
            }

            item = default;

            return false;
        }

        public static bool TryGetRandom<T>(this IReadOnlyCollection<(T Item, float Weight)> readOnlyCollection, out T item, GetRandomSingle getRandom)
        {
            var totalWeight = readOnlyCollection.Sum(static tuple => tuple.Weight);
            var targetWeight = getRandom(0f, totalWeight);

            foreach (var (currentItem, weight) in readOnlyCollection)
            {
                if (targetWeight > weight)
                {
                    targetWeight -= weight;

                    continue;
                }

                item = currentItem;

                return true;
            }

            item = default;

            return false;
        }
    }
}
