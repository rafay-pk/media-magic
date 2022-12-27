using System.Text;
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
            var _string = new StringBuilder();
            _string
                .Append("<mark=#")
                .Append(theme.BgColor)
                .Append(theme.Opacity)
                .Append(">")
                .Append(arg_path)
                .Append("</mark>");
            _gameObject.GetComponent<Folder>().Initialize(_string.ToString());
        }
    }
}
