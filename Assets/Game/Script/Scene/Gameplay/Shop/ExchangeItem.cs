using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Gains.Module.ProgressionData;

namespace Gains
{
    public class ExchangeItem : MonoBehaviour
    {
        [SerializeField]
        private Button _exchangeButton;
        [SerializeField]
        private Slider _exchangeSlider;
        [SerializeField]
        private TextMeshProUGUI _exchangeLimitText;
        [SerializeField]
        private Transform _limitContainer;

        public void Init()
        {
            _exchangeButton.onClick.RemoveAllListeners();
            _exchangeButton.onClick.AddListener(OnExchange);
        }

        private void Awake()
        {
            Init();
        }

        private void OnExchange()
        {
            ProgressData.Instance.AddCoin(-5000);
            _exchangeLimitText.text = "29/30";
            _exchangeSlider.value = 29;
            _limitContainer.gameObject.SetActive(true);
        }
    }
}
