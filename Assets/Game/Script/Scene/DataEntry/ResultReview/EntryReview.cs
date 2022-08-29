using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Gains.Module.EntryResult;
using Gains.Module.ResultSummary;
using Gains.Module.ProgressionData;

namespace Gains.Module.EntryResultReview
{
    public class EntryReview : MonoBehaviour
    {
        [SerializeField]
        private TMP_InputField _productNameInput;
        [SerializeField]
        private TMP_InputField _serveSizeInput;
        [SerializeField]
        private TMP_InputField _totalEnergy;
        [SerializeField]
        private TMP_InputField _fat;
        [SerializeField]
        private TMP_InputField _fiber;
        [SerializeField]
        private TMP_InputField _sugar;
        [SerializeField]
        private TMP_InputField _natrium;
        [SerializeField]
        private TMP_InputField _protein;
        [SerializeField]
        private Button _finishButton;
        [SerializeField]
        private ComplexResultSummary _resultSummary;

        public void Show()
        {
            _productNameInput.text = DataEntryResult.Instance.Results[0];
            _serveSizeInput.text = DataEntryResult.Instance.Results[1];
            _totalEnergy.text = DataEntryResult.Instance.Results[2];
            _fat.text = DataEntryResult.Instance.Results[3];
            _fiber.text = DataEntryResult.Instance.Results[4];
            _sugar.text = DataEntryResult.Instance.Results[5];
            _natrium.text = DataEntryResult.Instance.Results[6];
            _protein.text = DataEntryResult.Instance.Results[7];
            _finishButton.onClick.RemoveAllListeners();
            _finishButton.onClick.AddListener(OnFinish);
            gameObject.SetActive(true);
        }

        public void OnFinish()
        {
            ValidateResult();
            ProgressData.Instance.AddDailyQuestProgress("QUE03");
            ProgressData.Instance.AddAchievementProgress("ACH02");
            gameObject.SetActive(false);
            _resultSummary.Show(true);
        }

        public void ValidateResult()
        {
            DataEntryResult.Instance.Results[0] = _productNameInput.text;
            DataEntryResult.Instance.Results[1] = _serveSizeInput.text;
            DataEntryResult.Instance.Results[2] = _totalEnergy.text;
            DataEntryResult.Instance.Results[3] = _fat.text;
            DataEntryResult.Instance.Results[4] = _fiber.text;
            DataEntryResult.Instance.Results[5] = _sugar.text;
            DataEntryResult.Instance.Results[6] = _natrium.text;
            DataEntryResult.Instance.Results[7] = _protein.text;
        }
    }
}
