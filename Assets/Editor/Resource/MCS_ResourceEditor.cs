using UnityEngine;
using UnityEditor;
using System;

namespace ModularCraftingSystem
{
    public class MCS_EditorWindow : EditorWindow
    {
        public MCS_Resource resource;

        [MenuItem("Window/Modular Crafting System/Resource Editor")]
        public static void ShowWindow()
        {
            GetWindow<MCS_EditorWindow>("Modular Crafting System");
        }


        private string resourceFolderPath;
        private bool showGroup = false;


        public void OnGUI()
        {
            GUILayout.Label("Resource Editor", EditorStyles.boldLabel);
            GUILayout.Space(5);

            GUILayout.BeginHorizontal();
            resourceFolderPath = GUILayout.TextField(resourceFolderPath);

            if(GUILayout.Button("Change Resource Folder"))
            {
            }

            GUILayout.EndHorizontal();

            //foreach (MCS_Resource item in AssetDatabase.)
            //{

            //}

            HeaderGroup();
        }

        private void HeaderGroup()
        {
            showGroup = EditorGUILayout.BeginFoldoutHeaderGroup(showGroup, "Test");
            if (showGroup)
            {
                GUILayout.BeginHorizontal();

                if (resource == null)
                {
                    if (GUILayout.Button("Edit Resource"))
                    {
                        EditResource();
                    }

                    if (GUILayout.Button("New Resource"))
                    {
                        MCS_CreateResource.CreateResource();
                    }
                }

                else
                {
                    if (GUILayout.Button("Show Resources"))
                    {
                        EditorUtility.FocusProjectWindow();
                        Selection.activeObject = resource;
                    }
                }


                GUILayout.EndHorizontal();
            }
        }

        private void EditResource()
        {
            throw new NotImplementedException();
        }
    }
}