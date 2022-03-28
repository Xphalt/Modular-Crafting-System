using UnityEngine;
using UnityEditor;

namespace ModularCraftingSystem
{
    public class MCS_CreateResource
    {
        public static MCS_Resource CreateResource()
        {
            MCS_Resource asset = ScriptableObject.CreateInstance<MCS_Resource>();

            if (!AssetDatabase.IsValidFolder("Assets/Resources"))
            {
                AssetDatabase.CreateFolder("Assets", "Resources");
            }

            string filePath = AssetDatabase.GenerateUniqueAssetPath("Assets/Resources/NewResource.asset");

            AssetDatabase.CreateAsset(asset, filePath);
            AssetDatabase.SaveAssets();

            EditorUtility.FocusProjectWindow();
            Selection.activeObject = asset;

            return asset;
        }
    }
}