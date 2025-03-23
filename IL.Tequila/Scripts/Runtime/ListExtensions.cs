using System.Collections.Generic;

namespace IL.Tequila
{
    public static class ListExtensions
    {
        public static bool TryRemoveAt<T>(this IList<T> list, int index, out T item)
        {
            if (index >= list.Count)
            {
                item = default;

                return false;
            }

            item = list[index];
            list.RemoveAt(index);

            return true;
        }
    }
}
