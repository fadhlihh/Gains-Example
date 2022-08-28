using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Gains.Module.EntryResult;

namespace Gains.Module.DataEntry
{
    public class MandatoryDataEntry : MonoBehaviour
    {
        [SerializeField]
        private TMP_InputField _answerInput1;
        [SerializeField]
        private TMP_InputField _answerInput2;
        [SerializeField]
        private Button _continueButton;
        [SerializeField]
        private ComplexDataEntry _complexDataEntryPopUp;


        public void Show()
        {
            _continueButton.onClick.RemoveAllListeners();
            _continueButton.onClick.AddListener(OnContinue);
            gameObject.SetActive(true);
        }

        public void OnContinue()
        {
            DataEntryResult.Instance.Results.Add(_answerInput1.text);
            DataEntryResult.Instance.Results.Add(_answerInput2.text);
            gameObject.SetActive(false);
            _complexDataEntryPopUp.Show();
        }
    }
}
