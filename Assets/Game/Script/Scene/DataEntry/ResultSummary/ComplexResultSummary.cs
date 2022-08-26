using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Gains.Utility;
using Gains.Module.EntryResult;

namespace Gains.Module.ResultSummary
{
    public class ComplexResultSummary : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _productNameInput;
        [SerializeField]
        private TextMeshProUGUI _serveSizeInput;
        [SerializeField]
        private TextMeshProUGUI _totalEnergy;
        [SerializeField]
        private TextMeshProUGUI _fat;
        [SerializeField]
        private TextMeshProUGUI _fiber;
        [SerializeField]
        private TextMeshProUGUI _sugar;
        [SerializeField]
        private TextMeshProUGUI _natrium;
        [SerializeField]
        private TextMeshProUGUI _protein;
        [SerializeField]
        private TextMeshProUGUI _element;
        [SerializeField]
        private Button _finishButton;

        public void Show(){
            _productNameInput.text = DataEntryResult.Instance.Results[0];
            _serveSizeInput.text = DataEntryResult.Instance.Results[1];
            _totalEnergy.text = DataEntryResult.Instance.Results[2];
            _fat.text = DataEntryResult.Instance.Results[3];
            _fiber.text = DataEntryResult.Instance.Results[4];
            _sugar.text = DataEntryResult.Instance.Results[5];
            _natrium.text = DataEntryResult.Instance.Results[6];
            _protein.text = DataEntryResult.Instance.Results[7];
            _finishButton.onClick.RemoveAllListeners();
            _finishButton.onClick.AddListener(OnClaim);
            gameObject.SetActive(true);
        }

        private void OnClaim(){
            SceneManager.LoadScene(GameScene.Gameplay,LoadSceneMode.Single);
        }
    }
}
