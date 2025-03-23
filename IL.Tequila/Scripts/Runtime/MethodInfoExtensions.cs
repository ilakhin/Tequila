using System;
using System.Reflection;

namespace IL.Tequila
{
    public static class MethodInfoExtensions
    {
        public static TDelegate CreateDelegate<TDelegate>(this MethodInfo methodInfo)
            where TDelegate : Delegate
        {
            return (TDelegate)methodInfo.CreateDelegate(typeof(TDelegate));
        }

        public static TDelegate CreateDelegate<TDelegate>(this MethodInfo methodInfo, object target)
            where TDelegate : Delegate
        {
            return (TDelegate)methodInfo.CreateDelegate(typeof(TDelegate), target);
        }
    }
}
