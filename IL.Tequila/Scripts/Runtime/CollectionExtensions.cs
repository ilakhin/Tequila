using System.Buffers;
using System.Collections.Generic;

namespace IL.Tequila
{
    public static class CollectionExtensions
    {
        public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                collection.Add(item);
            }
        }

        public static IEnumerable<T> ToCachedEnumerable<T>(this ICollection<T> collection)
        {
            var count = collection.Count;

            if (count == 0)
            {
                yield break;
            }

            var arrayPool = ArrayPool<T>.Shared;
            var cachedItems = arrayPool.Rent(count);

            try
            {
                collection.CopyTo(cachedItems, 0);

                for (var i = 0; i < count; ++i)
                {
                    yield return cachedItems[i];
                }
            }
            finally
            {
                arrayPool.Return(cachedItems, true);
            }
        }
    }
}
