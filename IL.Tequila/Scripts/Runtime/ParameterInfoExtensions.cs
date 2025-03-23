using System;
using System.Reflection;

namespace IL.Tequila
{
    public static class ParameterInfoExtensions
    {
        public static bool TryGetCustomAttribute<TAttribute>(this ParameterInfo parameterInfo, out TAttribute attribute)
            where TAttribute : Attribute
        {
            if (!Attribute.IsDefined(parameterInfo, typeof(TAttribute)))
            {
                attribute = null;

                return false;
            }

            attribute = Attribute.GetCustomAttribute(parameterInfo, typeof(TAttribute)) as TAttribute;

            return true;
        }

        public static bool TryGetCustomAttribute<TAttribute>(this ParameterInfo parameterInfo, bool inherit, out TAttribute attribute)
            where TAttribute : Attribute
        {
            if (!Attribute.IsDefined(parameterInfo, typeof(TAttribute), inherit))
            {
                attribute = null;

                return false;
            }

            attribute = Attribute.GetCustomAttribute(parameterInfo, typeof(TAttribute), inherit) as TAttribute;

            return true;
        }
    }
}
