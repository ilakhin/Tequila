using UnityEngine;
using UnityEngine.Pool;
#if IL_TEQUILA_ZSTRING_SUPPORT
using Cysharp.Text;
#else
using System.Text;
#endif

namespace IL.Tequila
{
    public static class TransformExtensions
    {
        public static string GetHierarchyPath(this Transform transform)
        {
#if IL_TEQUILA_ZSTRING_SUPPORT
            using var stringBuilder = ZString.CreateStringBuilder();
#else
            var stringBuilder = new StringBuilder();
#endif

            using (ListPool<string>.Get(out var names))
            {
                for (var currentTransform = transform; currentTransform != null; currentTransform = currentTransform.parent)
                {
                    names.Add(currentTransform.name);
                }

                stringBuilder.Append(names[^1]);

                for (var i = names.Count - 2; i >= 0; i--)
                {
                    stringBuilder.Append('/');
                    stringBuilder.Append(names[i]);
                }
            }

            var path = stringBuilder.ToString();

            return path;
        }
    }
}
