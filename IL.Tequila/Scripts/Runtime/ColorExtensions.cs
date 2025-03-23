using System.Runtime.CompilerServices;
using UnityEngine;

namespace IL.Tequila
{
    public static class ColorExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Color Replace(this Color color, float? r = null, float? g = null, float? b = null, float? a = null)
        {
            if (r.HasValue)
            {
                color.r = r.Value;
            }

            if (g.HasValue)
            {
                color.g = g.Value;
            }

            if (b.HasValue)
            {
                color.b = b.Value;
            }

            if (a.HasValue)
            {
                color.a = a.Value;
            }

            return color;
        }
    }
}
