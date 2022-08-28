using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Gains.Module.NutrimonSet
{
    public class RepeatableSetPanel : MonoBehaviour
    {
        [SerializeField]
        private Button _previousButton;
        [SerializeField]
        private Button _nextButton;
        [SerializeField]
        private OneTimeSetPanel _oneTimeSetPanel;

        public void Show()
        {
            _previousButton.onClick.RemoveAllListeners();
            _previousButton.onClick.AddListener(OnPrevious);
            _nextButton.onClick.RemoveAllListeners();
            _nextButton.onClick.AddListener(OnNext);
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        private void Awake()
        {
            Show();
        }

        private void OnPrevious()
        {
            Hide();
            _oneTimeSetPanel.Show();
        }

        private void OnNext()
        {
            Hide();
            _oneTimeSetPanel.Show();
        }
    }
}
