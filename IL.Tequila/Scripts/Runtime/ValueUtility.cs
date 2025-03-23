using System;
using System.Collections.Generic;
using UnityEngine;

namespace IL.Tequila
{
    public static class ValueUtility
    {
        public static bool TrySetReference<T>(ref T sourceValue, T targetValue)
            where T : class
        {
            var equalsResult = Equals(sourceValue, targetValue);

            if (equalsResult)
            {
                return false;
            }

            sourceValue = targetValue;

            return true;
        }

        public static bool TrySetSingle(ref float sourceValue, float targetValue)
        {
            var approximatelyResult = Mathf.Approximately(sourceValue, targetValue);

            if (approximatelyResult)
            {
                return false;
            }

            sourceValue = targetValue;

            return true;
        }

        public static bool TrySetString(ref string sourceValue, string targetValue)
        {
            return TrySetString(ref sourceValue, targetValue, StringComparer.Ordinal);
        }

        public static bool TrySetString(ref string sourceValue, string targetValue, StringComparer comparer)
        {
            var equalsResult = comparer.Equals(sourceValue, targetValue);

            if (equalsResult)
            {
                return false;
            }

            sourceValue = targetValue;

            return true;
        }

        public static bool TrySetValue<T>(ref T sourceValue, T targetValue)
            where T : struct
        {
            return TrySetValue(ref sourceValue, targetValue, EqualityComparer<T>.Default);
        }

        public static bool TrySetValue<T>(ref T sourceValue, T targetValue, IEqualityComparer<T> comparer)
            where T : struct
        {
            var equalsResult = comparer.Equals(sourceValue, targetValue);

            if (equalsResult)
            {
                return false;
            }

            sourceValue = targetValue;

            return true;
        }
    }
}
