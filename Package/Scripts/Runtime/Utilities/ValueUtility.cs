using System;
using System.Collections.Generic;
using UnityEngine;

namespace Tequila.Utilities
{
    public static class ValueUtility
    {
        public static bool TrySetEnum<T>(ref T sourceValue, in T targetValue)
            where T : struct, Enum
        {
            var equalityComparer = EqualityComparer<T>.Default;
            var equalsResult = equalityComparer.Equals(sourceValue, targetValue);

            if (equalsResult)
            {
                return false;
            }

            sourceValue = targetValue;

            return true;
        }

        public static bool TrySetNullable<T>(ref T? sourceValue, in T targetValue)
            where T : struct
        {
            var equalsResult = Nullable.Equals(sourceValue, targetValue);

            if (equalsResult)
            {
                return false;
            }

            sourceValue = targetValue;

            return true;
        }

        public static bool TrySetReference<T>(ref T sourceValue, in T targetValue)
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

        public static bool TrySetSingle(ref float sourceValue, in float targetValue)
        {
            var approximatelyResult = Mathf.Approximately(sourceValue, targetValue);

            if (approximatelyResult)
            {
                return false;
            }

            sourceValue = targetValue;

            return true;
        }

        public static bool TrySetString(ref string sourceValue, in string targetValue)
        {
            var equalsResult = string.Equals(sourceValue, targetValue, StringComparison.Ordinal);

            if (equalsResult)
            {
                return false;
            }

            sourceValue = targetValue;

            return true;
        }
    }
}
