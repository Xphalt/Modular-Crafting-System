using UnityEngine;
using UnityEditor;
using System;

namespace ModularCraftingSystem
{
    public class MCS_EditorWindow : EditorWindow
    {
        public ResourceList resourceList;

        [MenuItem("Window/Modular Crafting System/Resource Editor")]
        public static void ShowWindow()
        {
            GetWindow<MCS_EditorWindow>("Modular Crafting System");
        }





        public void OnGUI()
        {
            GUILayout.Label("Create resource", EditorStyles.boldLabel);
            GUILayout.BeginHorizontal();
            //GUILayout.BeginVertical();

            if (GUILayout.Button("Create new resource")) { CreateResource(); }
            if (GUILayout.Button("Edit resource")) { EditResource(); }



        }



        private void CreateResource()
        {
            throw new NotImplementedException();
        }



        private void EditResource()
        {
            throw new NotImplementedException();
        }
    }
}