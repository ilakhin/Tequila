using System.Runtime.CompilerServices;
using UnityEngine;

namespace IL.Tequila
{
    public static class Color32Extensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Color32 Replace(this Color32 color32, byte? r = null, byte? g = null, byte? b = null, byte? a = null)
        {
            if (r.HasValue)
            {
                color32.r = r.Value;
            }

            if (g.HasValue)
            {
                color32.g = g.Value;
            }

            if (b.HasValue)
            {
                color32.b = b.Value;
            }

            if (a.HasValue)
            {
                color32.a = a.Value;
            }

            return color32;
        }
    }
}
