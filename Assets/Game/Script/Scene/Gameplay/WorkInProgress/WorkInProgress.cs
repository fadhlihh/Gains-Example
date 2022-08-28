using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Gains.Module.WIP
{
    public class WorkInProgress : MonoBehaviour
    {
        [SerializeField]
        private Button _backButton;

        public void Show()
        {
            _backButton.onClick.RemoveAllListeners();
            _backButton.onClick.AddListener(OnBack);
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        private void OnBack()
        {
            Hide();
        }
    }
}
