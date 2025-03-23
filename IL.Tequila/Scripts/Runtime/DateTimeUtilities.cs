using System;
using System.Globalization;

namespace IL.Tequila
{
    public static class DateTimeUtilities
    {
        private static readonly string[] Iso8601Formats =
        {
            @"yyyy-MM-dd\THH:mm:ss.FFFFFFF\Z",
            @"yyyy-MM-dd\THH:mm:ss\Z",
            @"yyyy-MM-dd\THH:mm:ssK"
        };

        public static string ToIso8601String(DateTime dateTime)
        {
            return dateTime.ToUniversalTime().ToString(Iso8601Formats[1], CultureInfo.InvariantCulture);
        }

        public static DateTime ParseIso8601String(string value)
        {
            return DateTime.ParseExact(value, Iso8601Formats, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeUniversal);
        }
    }
}
