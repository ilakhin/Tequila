using System.Runtime.CompilerServices;
using UnityEngine;

namespace IL.Tequila
{
    public static class Vector4Extensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 Replace(this Vector4 vector4, float? x = null, float? y = null, float? z = null, float? w = null)
        {
            if (x.HasValue)
            {
                vector4.x = x.Value;
            }

            if (y.HasValue)
            {
                vector4.y = y.Value;
            }

            if (z.HasValue)
            {
                vector4.z = z.Value;
            }

            if (w.HasValue)
            {
                vector4.w = w.Value;
            }

            return vector4;
        }
    }
}
