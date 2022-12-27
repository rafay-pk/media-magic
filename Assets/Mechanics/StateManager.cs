using System.Collections.Generic;
using System.Linq;
using Michsky.MUIP;
using Plugins.Editor;
using SimpleFileBrowser;
using UnityEngine;
using UnityEngine.UI;

namespace Mechanics
{
    public class StateManager : Singleton<StateManager>
    {
        [SerializeField] private List<Button> folders, contents;
        [SerializeField] [ReadOnly] private Button activeFolder, activeContent;

        [SerializeField] private ButtonManager addFolderButton;

        private void Awake()
        {
            addFolderButton.onClick.AddListener(SelectFolder);
        }

        public static void SelectFolder()
        {
            FileBrowser.ShowLoadDialog
            (
                paths =>
                {
                    paths.ToList().ForEach(print);
                    Populator.Instance.Populate(paths.First());
                }, 
                null, FileBrowser.PickMode.Folders
            );
        }
    }
}
