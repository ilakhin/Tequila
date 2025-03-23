#if IL_TEQUILA_ZSTRING_SUPPORT
using Cysharp.Text;
#endif
using UnityEngine;

namespace IL.Tequila
{
    public static class TransformExtensions
    {
        public static string GetHierarchyPath(this Transform transform)
        {
            var path = transform.name;

            for (var currentTransform = transform.parent; currentTransform != null; currentTransform = currentTransform.parent)
            {
#if IL_TEQUILA_ZSTRING_SUPPORT
                path = ZString.Concat(currentTransform.name, "/", path);
#else
                path = $"{currentTransform.name}/{path}";
#endif
            }

            return path;
        }
    }
}
