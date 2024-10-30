using System.Runtime.CompilerServices;
using UnityEngine;

namespace IL.Tequila
{
    // ReSharper disable once InconsistentNaming
    public static class Matrix4x4Extensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rect MultiplyRect(this Matrix4x4 matrix, Rect rect)
        {
            var min = matrix.MultiplyPoint(rect.min);
            var max = matrix.MultiplyPoint(rect.max);

            return Rect.MinMaxRect(min.x, min.y, max.x, max.y);
        }
    }
}
