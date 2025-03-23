using System.Runtime.CompilerServices;

namespace IL.Tequila
{
    public static class ObjectExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T As<T>(this object instance)
            where T : class
        {
            return instance as T;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T To<T>(this object instance)
        {
            return (T)instance;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T? ToNullable<T>(this T instance)
            where T : struct
        {
            return instance;
        }
    }
}
