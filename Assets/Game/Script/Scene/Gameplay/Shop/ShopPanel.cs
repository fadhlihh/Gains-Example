using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Gains.Module.Exchanges;
using Gains.Module.WIP;

namespace Gains.Module.Shop
{
    public class ShopPanel : MonoBehaviour
    {
        [SerializeField]
        private Toggle _exchangeToggle;
        [SerializeField]
        private TextMeshProUGUI _exchangeText;
        [SerializeField]
        private Button _cashoutButton;
        [SerializeField]
        private ExchangePanel _exchangePanel;
        [SerializeField]
        private WorkInProgress _workInProgressPopUp;

        public void Show()
        {
            _exchangeToggle?.onValueChanged.RemoveAllListeners();
            _exchangeToggle?.onValueChanged.AddListener(OnExchange);
            _cashoutButton?.onClick.RemoveAllListeners();
            _cashoutButton?.onClick.AddListener(OnCashout);
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        private void OnExchange(bool value)
        {
            if (value)
            {
                _exchangeText.color = new Color32(255, 255, 255, 255);
                _exchangePanel.Show();
            }
            else
            {
                _exchangeText.color = new Color32(74, 172, 247, 255);
                _exchangePanel.Hide();
            }
        }

        private void OnCashout()
        {
            _workInProgressPopUp.Show();
        }
    }
}
