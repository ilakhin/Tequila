using System.Runtime.CompilerServices;

namespace IL.Tequila
{
    public static class NullableExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetValue<T>(this T? nullable, out T value)
            where T : struct
        {
            if (nullable.HasValue)
            {
                value = nullable.Value;

                return true;
            }

            value = default;

            return false;
        }
    }
}
