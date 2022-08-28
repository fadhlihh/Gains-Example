using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Gains.Module.NutrimonCollection;
using Gains.Module.NutrimonSet;
using Gains.Module.WIP;

namespace Gains.Module.Nutrimons
{
    public class NutrimonPanel : MonoBehaviour
    {
        [SerializeField]
        private Toggle _nutrimonCollectionToggle;
        [SerializeField]
        private TextMeshProUGUI _nutrimonCollectionText;
        [SerializeField]
        private Toggle _nutrimonSetToggle;
        [SerializeField]
        private TextMeshProUGUI _nutrimonSetText;
        [SerializeField]
        private NutrimonCollectionPanel _nutrimonCollectionPanel;
        [SerializeField]
        private NutrimonSetPanel _nutrimonSetPanel;
        [SerializeField]
        private WorkInProgress _workInProgressPopUp;

        public void Show()
        {
            _nutrimonCollectionToggle.onValueChanged.RemoveAllListeners();
            _nutrimonCollectionToggle.onValueChanged.AddListener(OnNutrimonCollection);
            _nutrimonSetToggle.onValueChanged.RemoveAllListeners();
            _nutrimonSetToggle.onValueChanged.AddListener(OnNutrimonSet);
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        private void OnNutrimonCollection(bool value)
        {
            if (value)
            {
                _nutrimonCollectionText.color = new Color32(255, 255, 255, 255);
                _nutrimonCollectionPanel.Show();
            }
            else
            {
                _nutrimonCollectionText.color = new Color32(74, 172, 247, 255);
                _nutrimonCollectionPanel.Hide();
            }
        }

        private void OnNutrimonSet(bool value)
        {
            if (value)
            {
                _nutrimonSetText.color = new Color32(255, 255, 255, 255);
                _nutrimonSetPanel.Show();
            }
            else
            {
                _nutrimonSetText.color = new Color32(74, 172, 247, 255);
                _nutrimonSetPanel.Hide();
            }
        }
    }
}
