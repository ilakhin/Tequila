using System.Collections.Generic;
using UnityEditor;

namespace IL.Tequila
{
    public static class SerializedObjectExtensions
    {
        public static IEnumerable<SerializedProperty> GetSerializedProperties(this SerializedObject serializedObject, bool enterChildren, bool onlyVisible)
        {
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
