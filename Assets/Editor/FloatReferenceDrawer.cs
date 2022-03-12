using UnityEngine;
using UnityEditor;

namespace ModularCraftingSystem
{
    [CustomPropertyDrawer(typeof(FloatReference))]
    [CustomPropertyDrawer(typeof(StringReference))]
    public class FloatReferenceDrawer : PropertyDrawer
    {
        private readonly string[] popupMenuOptions = { "Use Default", "Override" };
        private GUIStyle popupStyle;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            #region Draw popup region
            if (popupStyle == null)
            {
                popupStyle = new GUIStyle(GUI.skin.GetStyle("PaneOptions"));
                popupStyle.imagePosition = ImagePosition.ImageOnly;
            }

            label = EditorGUI.BeginProperty(position, label, property);
            position = EditorGUI.PrefixLabel(position, label);

            EditorGUI.BeginChangeCheck();
            #endregion

            #region Get Properties
            SerializedProperty useConstant = property.FindPropertyRelative("useConstant");
            SerializedProperty constantValue = property.FindPropertyRelative("constantValue");
            SerializedProperty variable = property.FindPropertyRelative("variable");
            #endregion

            #region Calculate rect for button
            Rect buttonRect = new Rect(position);
            buttonRect.yMin += popupStyle.margin.top;
            buttonRect.width = popupStyle.fixedWidth + popupStyle.margin.right;
            position.xMin = buttonRect.xMax;
            #endregion

            #region Store previous indent and set to 0
            int indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            int result = EditorGUI.Popup(buttonRect, useConstant.boolValue ? 0 : 1, popupMenuOptions, popupStyle);
            useConstant.boolValue = result == 0;

            EditorGUI.PropertyField(position, useConstant.boolValue ? variable : constantValue, GUIContent.none);

            if (EditorGUI.EndChangeCheck()) { property.serializedObject.ApplyModifiedProperties(); }

            EditorGUI.indentLevel = indent;
            EditorGUI.EndProperty();
            #endregion
        }
    }
}