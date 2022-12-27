using System.Text;
using Plugins.Editor;
using TMPro;
using UnityEngine;

namespace Mechanics
{
    public class Populator : Singleton<Populator>
    {
        [SerializeField] private ThemeConfig theme;
        [SerializeField] private RectTransform folderList;
        [SerializeField] private GameObject folderPrefab;

        public void Populate(string arg_path)
        {
            var _gameObject = Instantiate(folderPrefab, folderList);
            print(theme.Opacity);
            var _string = new StringBuilder();
            _string
                .Append("<mark=#")
                .Append(ColorUtility.ToHtmlStringRGB(theme.textBgColorNormal))
                .Append(theme.Opacity)
                .Append(">")
                .Append(arg_path)
                .Append("</mark>");
            _gameObject.GetComponent<TMP_Text>().text = _string.ToString();
        }
    }
}
