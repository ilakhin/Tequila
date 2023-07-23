using JetBrains.Annotations;
using System.Collections.Generic;
using Tequila.Utilities;
using UnityEditor;

namespace Tequila.Extensions
{
    public static class SerializedObjectExtensions
    {
        public static IEnumerable<SerializedProperty> GetSerializedProperties([NotNull] this SerializedObject serializedObject, bool enterChildren, bool onlyVisible)
        {
            ExceptionUtility.ThrowArgumentNullException_IfNull(serializedObject, nameof(serializedObject));

            using var iterator = serializedObject.GetIterator();

            if (onlyVisible)
            {
                while (iterator.NextVisible(enterChildren))
                {
                    yield return iterator;
                }
            }
            else
            {
                while (iterator.Next(enterChildren))
                {
                    yield return iterator;
                }
            }
        }
    }
}
