using System;
using System.Reflection;

namespace IL.Tequila
{
    public static class MemberInfoExtensions
    {
        public static bool TryGetCustomAttribute<TAttribute>(this MemberInfo memberInfo, out TAttribute attribute)
            where TAttribute : Attribute
        {
            if (!Attribute.IsDefined(memberInfo, typeof(TAttribute)))
            {
                attribute = null;

                return false;
            }

            attribute = Attribute.GetCustomAttribute(memberInfo, typeof(TAttribute)) as TAttribute;

            return true;
        }

        public static bool TryGetCustomAttribute<TAttribute>(this MemberInfo memberInfo, bool inherit, out TAttribute attribute)
            where TAttribute : Attribute
        {
            if (!Attribute.IsDefined(memberInfo, typeof(TAttribute), inherit))
            {
                attribute = null;

                return false;
            }

            attribute = Attribute.GetCustomAttribute(memberInfo, typeof(TAttribute), inherit) as TAttribute;

            return true;
        }
    }
}
