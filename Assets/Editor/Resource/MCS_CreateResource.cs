using UnityEngine;
using UnityEditor;

namespace ModularCraftingSystem
{
    public class MCS_CreateResource
    {
        public static MCS_Resource CreateResource()
        {
            MCS_Resource asset = ScriptableObject.CreateInstance<MCS_Resource>();

            string filePath = AssetDatabase.GenerateUniqueAssetPath("Assets/NewResource.asset");

            AssetDatabase.CreateAsset(asset, filePath);
            AssetDatabase.SaveAssets();

            EditorUtility.FocusProjectWindow();
            Selection.activeObject = asset;

            return asset;
        }
    }
}