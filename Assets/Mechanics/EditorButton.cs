using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace Plugins.Editor
{

    [AttributeUsage(AttributeTargets.Field)]
    public class InspectorButtonAttribute : PropertyAttribute
    {
        public readonly string MethodName;

        public InspectorButtonAttribute(string method_name)
        {
            MethodName = method_name;
        }
    }

    #if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(InspectorButtonAttribute))]
    public class InspectorButtonPropertyDrawer : PropertyDrawer
    {
        private MethodInfo eventMethodInfo = null;

        public override void OnGUI(Rect position, SerializedProperty prop, GUIContent label)
        {
            var inspector_button_attribute = (InspectorButtonAttribute)attribute;
            var width = EditorGUIUtility.currentViewWidth - 22f;
            var button_rect = new Rect(position.x, position.y, width, position.height);
            
            if (!GUI.Button(button_rect, label.text)) return;
            
            var event_owner_type = prop.serializedObject.targetObject.GetType();
            var event_name = inspector_button_attribute.MethodName;

            if (eventMethodInfo == null)
                eventMethodInfo = event_owner_type.GetMethod(event_name, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

            if (eventMethodInfo != null)
                eventMethodInfo.Invoke(prop.serializedObject.targetObject, null);
            else
                Debug.LogWarning($"InspectorButton: Unable to find method {event_name} in {event_owner_type}");
        }
    }
    #endif
}