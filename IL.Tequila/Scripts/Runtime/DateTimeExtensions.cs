using System;
using System.Runtime.CompilerServices;

namespace IL.Tequila
{
    public static class DateTimeExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long ToUnixTimeMilliseconds(this DateTime dateTime)
        {
            var unixTimeMilliseconds = new DateTimeOffset(dateTime).ToUnixTimeMilliseconds();

            return unixTimeMilliseconds;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long ToUnixTimeSeconds(this DateTime dateTime)
        {
            var unixTimeSeconds = new DateTimeOffset(dateTime).ToUnixTimeSeconds();

            return unixTimeSeconds;
        }
    }
}
