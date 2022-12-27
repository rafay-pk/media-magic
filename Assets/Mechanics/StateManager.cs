using System.Collections.Generic;
using System.Linq;
using Michsky.MUIP;
using Plugins.Editor;
using SimpleFileBrowser;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Mechanics
{
    public class StateManager : Singleton<StateManager>
    {
        [SerializeField] private ThemeConfig theme;
        // [SerializeField] private List<Button> folders, contents;
        [SerializeField] private Folder activeFolder;
        // [SerializeField] [ReadOnly] private Content activeContent; 

        [SerializeField] private ButtonManager addFolderButton;

        private void Awake()
        {
            addFolderButton.onClick.AddListener(BrowseFolder);
        }

        public static void BrowseFolder()
        {
            FileBrowser.ShowLoadDialog
            (
                paths => Populator.Instance.Populate(paths.First()),
                null, FileBrowser.PickMode.Folders
            );
        }

        public void SelectFolder(Folder arg_folder)
        {
            TMP_Text _ref;
            if (activeFolder)
            {
                _ref = activeFolder.tmpText;
                _ref.text = _ref.text.Replace(theme.HlColor, theme.BgColor);
            }
            activeFolder = arg_folder;
            _ref = arg_folder.tmpText;
            _ref.text = _ref.text.Replace(theme.BgColor, theme.HlColor);
        }
    }
}
