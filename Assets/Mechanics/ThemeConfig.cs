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
        
        [SerializeField] private Color textBgColorNormal;
        [SerializeField] private Color textBgColorHighlighted;
        public string BgColor => ColorUtility.ToHtmlStringRGB(textBgColorNormal);
        public string HlColor => ColorUtility.ToHtmlStringRGB(textBgColorHighlighted);
    }
}
