namespace Tequila.Extensions
{
    public static class NullableExtensions
    {
        public static bool TryGetValue<T>(ref T? nullable, out T value)
            where T : struct
        {
            if (!nullable.HasValue)
            {
                value = default;

                return false;
            }

            value = nullable.Value;

            return true;
        }
    }
}
