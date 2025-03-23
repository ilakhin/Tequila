using System.Collections.Generic;

namespace IL.Tequila
{
    public static class NullableUtility
    {
        public static bool TrySetValue<T>(ref T? nullable, T value)
            where T : struct
        {
            return TrySetValue(ref nullable, value, EqualityComparer<T>.Default);
        }

        public static bool TrySetValue<T>(ref T? nullable, T value, IEqualityComparer<T> comparer)
            where T : struct
        {
            if (nullable.HasValue)
            {
                var equalsResult = comparer.Equals(nullable.Value, value);

                if (equalsResult)
                {
                    return false;
                }
            }

            nullable = value;

            return true;
        }

        public static bool TrySetValueOnce<T>(ref T? nullable, T value)
            where T : struct
        {
            if (nullable.HasValue)
            {
                return false;
            }

            nullable = value;

            return true;
        }
    }
}
