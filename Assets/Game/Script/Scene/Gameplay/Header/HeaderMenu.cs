using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Gains.Module.ProgressionData;
using Gains.Module.WIP;

namespace Gains.Module.Header
{
    public class HeaderMenu : MonoBehaviour
    {
        [SerializeField]
        private Button _profileButton;
        [SerializeField]
        private Button _settingButton;
        [SerializeField]
        private TextMeshProUGUI _usernameText;
        [SerializeField]
        private TextMeshProUGUI _energyText;
        [SerializeField]
        private TextMeshProUGUI _coinText;
        [SerializeField]
        private WorkInProgress _workInProgressPopUp;

        private void Awake()
        {
            _profileButton.onClick.RemoveAllListeners();
            _profileButton.onClick.AddListener(OnProfile);
            _settingButton.onClick.RemoveAllListeners();
            _settingButton.onClick.AddListener(OnSetting);
        }

        private void Update()
        {
            _coinText.text = ProgressData.Instance.Progress.Coin.ToString();
        }

        public void OnProfile()
        {
            _workInProgressPopUp.Show();
        }

        public void OnSetting()
        {
            _workInProgressPopUp.Show();
        }
    }
}
