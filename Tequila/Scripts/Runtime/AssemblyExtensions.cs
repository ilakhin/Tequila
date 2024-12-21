using System;
using System.Reflection;

namespace IL.Tequila
{
    public static class AssemblyExtensions
    {
        public static bool TryGetCustomAttribute<TAttribute>(this Assembly assembly, out TAttribute attribute)
            where TAttribute : Attribute
        {
            if (!Attribute.IsDefined(assembly, typeof(TAttribute)))
            {
                attribute = null;

                return false;
            }

            attribute = Attribute.GetCustomAttribute(assembly, typeof(TAttribute)) as TAttribute;

            return true;
        }

        public static bool TryGetCustomAttribute<TAttribute>(this Assembly assembly, bool inherit, out TAttribute attribute)
            where TAttribute : Attribute
        {
            if (!Attribute.IsDefined(assembly, typeof(TAttribute), inherit))
            {
                attribute = null;

                return false;
            }

            attribute = Attribute.GetCustomAttribute(assembly, typeof(TAttribute), inherit) as TAttribute;

            return true;
        }
    }
}
