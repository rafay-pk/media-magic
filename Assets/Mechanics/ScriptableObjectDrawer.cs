using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Plugins.Editor
{
    [CustomPropertyDrawer(typeof(ScriptableObject), true)]
    public class ScriptableObjectDrawer : PropertyDrawer
    {
        // Static foldout dictionary
        private static readonly Dictionary<System.Type, bool> foldoutByType = new Dictionary<System.Type, bool>();

        // Cached scriptable object editor
        private UnityEditor.Editor editor = null;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            // Draw label
            EditorGUI.PropertyField(position, property, label, true);
        
            // Draw foldout arrow
            var foldout = false;
            if (property.objectReferenceValue != null)
            {
                // Store foldout values in a dictionary per object type
                var foldout_exists = foldoutByType.TryGetValue(property.objectReferenceValue.GetType(), out foldout);
                foldout = EditorGUI.Foldout(position, foldout, GUIContent.none);
                if (foldout_exists)
                    foldoutByType[property.objectReferenceValue.GetType()] = foldout;
                else
                    foldoutByType.Add(property.objectReferenceValue.GetType(), foldout);
            }

            // Draw foldout properties
            if (!foldout) return;
            
            // Make child fields be indented
            EditorGUI.indentLevel++;
            
            // Draw object properties
            if (!editor)
                UnityEditor.Editor.CreateCachedEditor(property.objectReferenceValue, null, ref editor);
            editor.OnInspectorGUI();
            
            // Set indent back to what it was
            EditorGUI.indentLevel--;
        }
    }
}