using UnityEngine;
using UnityEditor;

namespace ModularCraftingSystem
{
    public class CreateResource
    {
        public static MCS_ResourceList CreateResourceList()
        {
            MCS_ResourceList asset = ScriptableObject.CreateInstance<MCS_ResourceList>();
            AssetDatabase.CreateAsset(asset, "Test/ResourceList.asset");
            AssetDatabase.SaveAssets();

            return asset;
        }
    }
}