using System.Runtime.CompilerServices;
using UnityEngine;

namespace IL.Tequila
{
    public static class Vector3Extensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Replace(this Vector3 vector3, float? x = null, float? y = null, float? z = null)
        {
            if (x.HasValue)
            {
                vector3.x = x.Value;
            }

            if (y.HasValue)
            {
                vector3.y = y.Value;
            }

            if (z.HasValue)
            {
                vector3.z = z.Value;
            }

            return vector3;
        }
    }
}
