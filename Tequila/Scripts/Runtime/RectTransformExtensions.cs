using System.Runtime.CompilerServices;
using UnityEngine;

namespace IL.Tequila
{
    public static class RectTransformExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rect GetWorldRect(this RectTransform rectTransform)
        {
            return rectTransform.localToWorldMatrix.MultiplyRect(rectTransform.rect);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Resize(this RectTransform rectTransform, Vector2 size)
        {
            rectTransform.sizeDelta = size - rectTransform.rect.size + rectTransform.sizeDelta;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void StretchToParent(this RectTransform rectTransform)
        {
            rectTransform.localPosition = Vector3.zero;
            rectTransform.localRotation = Quaternion.identity;
            rectTransform.localScale = Vector3.one;

            rectTransform.anchorMin = Vector2.zero;
            rectTransform.anchorMax = Vector2.one;

            rectTransform.sizeDelta = Vector2.zero;
        }
    }
}
