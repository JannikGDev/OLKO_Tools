using SOVariables;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Editor
{
    [CustomPropertyDrawer(typeof(BoolVariable))]
    public class BoolValuePropertyDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            int lines = 2;
            return EditorGUIUtility.singleLineHeight * lines + EditorGUIUtility.standardVerticalSpacing * (lines - 1);
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);
            
            Rect rectLabel = new Rect(
                position.min.x, 
                position.min.y, 
                EditorGUIUtility.labelWidth, 
                EditorGUIUtility.singleLineHeight);
            EditorGUI.LabelField(rectLabel, label);
            
            Rect rectValue = new Rect(
                position.min.x + EditorGUIUtility.labelWidth, 
                position.min.y,
                EditorGUIUtility.fieldWidth, 
                EditorGUIUtility.singleLineHeight);
            SerializedProperty propUseReference = property.FindPropertyRelative("value");
            propUseReference.boolValue = EditorGUI.Toggle(
                rectValue,
                propUseReference.boolValue);
            
            var rectReference = new Rect(position.min.x + 20f,
                position.min.y + EditorGUIUtility.singleLineHeight,
                position.width - 20f,
                EditorGUIUtility.singleLineHeight);
            var useReference = DrawReference(rectReference, property, label);
            
            EditorGUI.EndProperty();
        }

        private bool DrawReference(Rect position, SerializedProperty property, GUIContent label)
        {
            float toggleWidth = 20f;
            
            Rect rectLabel = new Rect(
                position.min.x, 
                position.min.y, 
                EditorGUIUtility.labelWidth, 
                EditorGUIUtility.singleLineHeight);
            EditorGUI.LabelField(rectLabel, "Use reference");
            
            Rect rectValue = new Rect(
                position.min.x + EditorGUIUtility.labelWidth, 
                position.min.y, 
                toggleWidth, 
                EditorGUIUtility.singleLineHeight);
            SerializedProperty propUseReference = property.FindPropertyRelative("useReference");
            propUseReference.boolValue =  EditorGUI.Toggle(rectValue, propUseReference.boolValue);
            if (propUseReference.boolValue)
            {
                Rect rectReference = new Rect(
                    position.min.x + EditorGUIUtility.labelWidth + toggleWidth, 
                    position.min.y, 
                    position.size.x - toggleWidth - EditorGUIUtility.labelWidth, 
                    EditorGUIUtility.singleLineHeight);
                SerializedProperty propReference = property.FindPropertyRelative("reference");
                propReference.objectReferenceValue = (BoolValue)EditorGUI.ObjectField(
                    rectReference,
                    propReference.objectReferenceValue, 
                    typeof(BoolValue), 
                    false);
            }

            return propUseReference.boolValue;
        }
    }
}