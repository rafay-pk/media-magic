using UnityEditor;
using UnityEngine;

namespace Plugins.Editor
{
    public static class CopyPath
    {
        [MenuItem("Assets/Copy Full Path Location", false, 19)]
        private static void CopyPathToClipboard()
        {
            var obj = Selection.activeObject;
        
            if (obj == null) return;
            if (!AssetDatabase.Contains(obj)) return;

            GUIUtility.systemCopyBuffer = 
                (Application.dataPath + 
                 AssetDatabase
                     .GetAssetPath(obj)
                     .TrimStart('A', 's', 's', 'e', 't')
                ).Replace('/', '\\');
        }
    }
}