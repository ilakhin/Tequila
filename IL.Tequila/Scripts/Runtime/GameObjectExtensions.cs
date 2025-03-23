using UnityEngine;

namespace IL.Tequila
{
    public static class GameObjectExtensions
    {
        public static bool TryGetComponentInParent<T>(this GameObject gameObject, out T component)
        {
            component = gameObject.GetComponentInParent<T>();

            return component != null;
        }
    }
}
