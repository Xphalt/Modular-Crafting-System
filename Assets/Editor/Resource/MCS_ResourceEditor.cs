using UnityEngine;
using UnityEditor;
using System;

namespace ModularCraftingSystem
{
    public class MCS_EditorWindow : EditorWindow
    {
        public MCS_ResourceList resourceList;

        [MenuItem("Window/Modular Crafting System/Resource Editor")]
        public static void ShowWindow()
        {
            GetWindow<MCS_EditorWindow>("Modular Crafting System");
        }





        public void OnGUI()
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label("Resource Editor", EditorStyles.boldLabel);

            if (resourceList != null)
            {
                if (GUILayout.Button("Show Resource List"))
                {
                    EditorUtility.FocusProjectWindow();
                    Selection.activeObject = resourceList;
                }
            }

            if (GUILayout.Button("Open Resource List"))
            {
                OpenResourceList();
            }

            if (GUILayout.Button("New Resource List"))
            {
                EditorUtility.FocusProjectWindow();
                Selection.activeObject = resourceList;
            }

            GUILayout.EndHorizontal();
        }

        private void OpenResourceList()
        {
            throw new NotImplementedException();
        }
    }
}