using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Gains.Module.ResultSummary;
using Gains.Module.DataEntry;

namespace Gains.Module.Confirmation
{
    public class ConfirmationPopUp : MonoBehaviour
    {
        [SerializeField]
        private Button _yesButton;
        [SerializeField]
        private Button _noButton;
        [SerializeField]
        private SimpleResultSummary _resultSummaryPopUp;
        [SerializeField]
        private ComplexDataEntry _complexDataEntryPopUp;

        public void Show()
        {
            _yesButton.onClick.RemoveAllListeners();
            _yesButton.onClick.AddListener(OnYes);
            _noButton.onClick.RemoveAllListeners();
            _noButton.onClick.AddListener(OnNo);
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        private void OnYes()
        {
            Hide();
            _complexDataEntryPopUp.Hide();
            _resultSummaryPopUp.Show();
        }

        private void OnNo()
        {
            Hide();
        }
    }
}
