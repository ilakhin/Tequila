using System.Runtime.CompilerServices;
using UnityEngine;

namespace IL.Tequila
{
    public static class Vector2Extensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 Replace(this Vector2 vector2, float? x = null, float? y = null)
        {
            if (x.HasValue)
            {
                vector2.x = x.Value;
            }

            if (y.HasValue)
            {
                vector2.y = y.Value;
            }

            return vector2;
        }
    }
}
