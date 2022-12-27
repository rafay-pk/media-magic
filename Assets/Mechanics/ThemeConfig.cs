using Plugins.Editor;
using UnityEngine;
using UnityEngine.Serialization;

namespace Mechanics
{
    [CreateAssetMenu]
    public class ThemeConfig : ScriptableObject
    {
        [Header("Text Background Colors")]
        
        [Range(0, 99)] [SerializeField] private int opacityBlend;
        public string Opacity => opacityBlend.ToString("00");
        
        public Color textBgColorNormal;
        public Color textBgColorHighlighted;
    }
}
