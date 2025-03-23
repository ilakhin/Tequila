using System;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace IL.Tequila
{
    public static class CustomAttributeProviderExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsDefined<TAttribute>(this ICustomAttributeProvider provider, bool inherit)
            where TAttribute : Attribute
        {
            return provider.IsDefined(typeof(TAttribute), inherit);
        }
    }
}
