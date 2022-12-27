using Plugins.Editor;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Mechanics
{
    public class Folder : MonoBehaviour
    {
        public TMP_Text tmpText;
        [SerializeField] private Button btn;

        public void Initialize(string arg_path)
        {
            tmpText = GetComponent<TMP_Text>();
            btn = GetComponent<Button>();
            
            btn.onClick.AddListener(OnButtonPress);
            tmpText.text = arg_path;
        }

        public void OnButtonPress()
        {
            StateManager.Instance.SelectFolder(this);
        }
    }
}
