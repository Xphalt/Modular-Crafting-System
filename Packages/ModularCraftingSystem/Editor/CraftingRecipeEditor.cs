using UnityEditor;
using UnityEngine;


namespace ModularCraftingSystem
{
    [CustomEditor(typeof(CraftingRecipeData))]
    public class CraftingRecipeEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            CraftingRecipeData data = (CraftingRecipeData)target;

            EditorGUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            CreateHeading("OUTPUT");
            GUILayout.FlexibleSpace();
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();

            CreateItemDisplay(data, data.outputItem, "outputItem");

            GUILayout.FlexibleSpace();
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.Space();

            CreateHeading("RECIPE");
            EditorGUILayout.BeginHorizontal();
            CreateItemDisplay(data, data.item1, "item1");
            CreateItemDisplay(data, data.item2, "item2");
            CreateItemDisplay(data, data.item3, "item3");
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            CreateItemDisplay(data, data.item4, "item4");
            CreateItemDisplay(data, data.item5, "item5");
            CreateItemDisplay(data, data.item6, "item6");
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            CreateItemDisplay(data, data.item7, "item7");
            CreateItemDisplay(data, data.item8, "item8");
            CreateItemDisplay(data, data.item9, "item9");
            EditorGUILayout.EndHorizontal();

            serializedObject.ApplyModifiedProperties();
        }

        private void CreateItemDisplay(CraftingRecipeData _data, InventoryItemData _inventoryResourceData, string _name)
        {
            EditorGUILayout.BeginVertical();

            Texture texture = null;

            if (_inventoryResourceData != null)
            {
                texture = _inventoryResourceData.icon.texture;
            }
            
            GUILayout.Box(texture, GUILayout.Width(150), GUILayout.Height(150));
            EditorGUILayout.PropertyField(serializedObject.FindProperty(_name), GUIContent.none, true, GUILayout.Width(150), GUILayout.Height(25));

            EditorGUILayout.EndVertical();
        }

        private static void CreateHeading(string _headingName)
        {
            GUILayout.Label(_headingName, new GUIStyle { fontStyle = FontStyle.Bold });
        }
    }
}