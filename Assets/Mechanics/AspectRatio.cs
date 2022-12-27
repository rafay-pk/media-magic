using TMPro;
using UnityEngine;

namespace Mechanics
{
    public class AspectRatio : MonoBehaviour
    {
        public TMP_Text text;

        private void Start()
        {
            Application.targetFrameRate = 60;
        }

        private void Update()
        {
            text.text = Screen.height > Screen.width ? "Vertical" : "Horizontal"; 
        }
    }
}
