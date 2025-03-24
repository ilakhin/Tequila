#if IL_TEQUILA_ADDRESSABLES_SUPPORT
using UnityEngine.AddressableAssets;
#if IL_TEQUILA_ZSTRING_SUPPORT
using Cysharp.Text;
#endif

namespace IL.Tequila
{
    public static class AssetReferenceExtensions
    {
        public static string GetAssetKey(this AssetReference assetReference)
        {
            if (assetReference.AssetGUID == null)
            {
                return string.Empty;
            }

            if (string.IsNullOrEmpty(assetReference.SubObjectName))
            {
                return assetReference.AssetGUID;
            }

#if IL_TEQUILA_ZSTRING_SUPPORT
            var assetKey = ZString.Concat(assetReference.AssetGUID, '[', assetReference.SubObjectName, ']');

            return assetKey;
#else
            var assetKey = $"{assetReference.AssetGUID}[{assetReference.SubObjectName}]";

            return assetKey;
#endif
        }
    }
}
#endif
