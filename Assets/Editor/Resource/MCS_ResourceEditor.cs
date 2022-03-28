using UnityEngine;
using UnityEditor;
using System;

namespace ModularCraftingSystem
{
    public class MCS_EditorWindow : EditorWindow
    {
        #region Create Window

        public MCS_Resource resource;

        [MenuItem("Window/Modular Crafting System/Resource Editor")]
        public static void ShowWindow()
        {
            GetWindow<MCS_EditorWindow>("Modular Crafting System");
        }

        #endregion

        private string resourceFolderPath;
        private bool showSettings = false;

        public void OnGUI()
        {
            GUILayout.Label("Resource Editor", EditorStyles.boldLabel);
            GUILayout.Space(5);

            HeaderGroup("Settings", ResourceSettings);
            HeaderGroup("Edit", ResourceEdit);
        }

        private void HeaderGroup(string _headerName, Action _callback)
        {
            showSettings = EditorGUILayout.BeginFoldoutHeaderGroup(showSettings, _headerName);

            if (showSettings)
            {
                _callback?.Invoke();
            }

            EditorGUILayout.EndFoldoutHeaderGroup();
        }

        private void ResourceSettings()
        {
            GUILayout.BeginHorizontal();

            resourceFolderPath = GUILayout.TextField(resourceFolderPath, GUILayout.Width(200));

            if (GUILayout.Button("Change Resource Folder"))
            {
                resourceFolderPath = EditorUtility.OpenFolderPanel(string.Empty, "Assets", string.Empty);
            }

            GUILayout.EndHorizontal();
        }

        private void ResourceEdit()
        {
            if (GUILayout.Button("Edit Resource"))
            {
                EditResource();
            }

            if (GUILayout.Button("New Resource"))
            {
                MCS_CreateResource.CreateResource();
            }

            if (GUILayout.Button("Show Resources"))
            {
                EditorUtility.FocusProjectWindow();
                Selection.activeObject = resource;
            }
        }

        private void EditResource()
        {
            throw new NotImplementedException();
        }
    }
}