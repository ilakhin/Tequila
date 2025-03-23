using System;
using System.Runtime.CompilerServices;

namespace IL.Tequila
{
    public static class RandomUtility
    {
        private static readonly Random Random = new();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetRandomInt32(int min, int max)
        {
            return Random.Next(min, max + 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float GetRandomSingle(float min, float max)
        {
            return (float)Random.NextDouble() * (max - min) + min;
        }
    }
}
