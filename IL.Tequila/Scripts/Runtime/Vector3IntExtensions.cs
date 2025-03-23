using System.Runtime.CompilerServices;
using UnityEngine;

namespace IL.Tequila
{
    public static class Vector3IntExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3Int Replace(this Vector3Int vector3Int, int? x = null, int? y = null, int? z = null)
        {
            if (x.HasValue)
            {
                vector3Int.x = x.Value;
            }

            if (y.HasValue)
            {
                vector3Int.y = y.Value;
            }

            if (z.HasValue)
            {
                vector3Int.z = z.Value;
            }

            return vector3Int;
        }
    }
}
