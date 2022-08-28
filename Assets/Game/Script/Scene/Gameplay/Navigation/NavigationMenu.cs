using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Gains.Module.Home;
using Gains.Module.Nutrimons;
using Gains.Module.Shop;
using Gains.Module.WIP;

namespace Gains.Module.Navigation
{
    public class NavigationMenu : MonoBehaviour
    {
        [SerializeField]
        private Toggle _homeToggle;
        [SerializeField]
        private Toggle _nutrimonToggle;
        [SerializeField]
        private Button _rangkingToggle;
        [SerializeField]
        private Toggle _shopToggle;
        [SerializeField]
        private HomePanel _homePanel;
        [SerializeField]
        private NutrimonPanel _nutrimonPanel;
        [SerializeField]
        private ShopPanel _shopPanel;
        [SerializeField]
        private WorkInProgress _workInProgressPopUp;
        private void Awake()
        {
            _homeToggle.onValueChanged.RemoveAllListeners();
            _homeToggle.onValueChanged.AddListener(OnHome);
            _nutrimonToggle.onValueChanged.RemoveAllListeners();
            _nutrimonToggle.onValueChanged.AddListener(OnNutrimon);
            _rangkingToggle.onClick.RemoveAllListeners();
            _rangkingToggle.onClick.AddListener(OnRanking);
            _shopToggle.onValueChanged.RemoveAllListeners();
            _shopToggle.onValueChanged.AddListener(OnShop);
        }

        private void OnHome(bool value)
        {
            if (value)
            {
                _homePanel.Show();
            }
            else
            {
                _homePanel.Hide();
            }
        }

        private void OnNutrimon(bool value)
        {
            if (value)
            {
                _nutrimonPanel.Show();
            }
            else
            {
                _nutrimonPanel.Hide();
            }
        }

        private void OnRanking()
        {
            _workInProgressPopUp.Show();
        }

        private void OnShop(bool value)
        {
            if (value)
            {
                _shopPanel.Show();
            }
            else
            {
                _shopPanel.Hide();
            }
        }
    }
}
