using System.Runtime.CompilerServices;
using UnityEngine;

namespace IL.Tequila
{
    public static class Vector2IntExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2Int Replace(this Vector2Int vector2Int, int? x = null, int? y = null)
        {
            if (x.HasValue)
            {
                vector2Int.x = x.Value;
            }

            if (y.HasValue)
            {
                vector2Int.y = y.Value;
            }

            return vector2Int;
        }
    }
}
