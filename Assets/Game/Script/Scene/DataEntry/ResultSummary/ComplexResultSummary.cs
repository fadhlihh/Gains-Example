using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Gains.Utility;
using Gains.Module.EntryResult;
using Gains.Module.ScanData;
using Gains.Module.ProgressionData;
using System.Collections.Generic;

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
        private TextMeshProUGUI _fatText;
        [SerializeField]
        private TextMeshProUGUI _fiberText;
        [SerializeField]
        private TextMeshProUGUI _sugarText;
        [SerializeField]
        private TextMeshProUGUI _natriumText;
        [SerializeField]
        private TextMeshProUGUI _proteinText;
        [SerializeField]
        private TextMeshProUGUI _elementText;
        [SerializeField]
        private Button _finishButton;
        [SerializeField]
        private List<Image> _productRating = new List<Image>();
        [SerializeField]
        private List<Image> _monsterStars = new List<Image>();

        public void Show(bool isInputData)
        {
            CalculateMonster();
            CheckProductRating();
            CheckMonsterStar();
            if (isInputData)
            {
                _productNameInput.text = DataEntryResult.Instance.Results[0];
                _serveSizeInput.text = DataEntryResult.Instance.Results[1];
                _totalEnergy.text = DataEntryResult.Instance.Results[2];
                _fatText.text = DataEntryResult.Instance.Results[3];
                _fiberText.text = DataEntryResult.Instance.Results[4];
                _sugarText.text = DataEntryResult.Instance.Results[5];
                _natriumText.text = DataEntryResult.Instance.Results[6];
                _proteinText.text = DataEntryResult.Instance.Results[7];
            }
            else
            {
                _productNameInput.text = ScanResultData.Instance.Product.Name;
                _serveSizeInput.text = ScanResultData.Instance.Product.ServingSize.Value.ToString();
                _totalEnergy.text = ScanResultData.Instance.Product.TotalEnergy.Value.ToString();
                _fatText.text = ScanResultData.Instance.Product.Fat.Value.ToString();
                _fiberText.text = ScanResultData.Instance.Product.Fiber.Value.ToString();
                _sugarText.text = ScanResultData.Instance.Product.Sugar.Value.ToString();
                _natriumText.text = ScanResultData.Instance.Product.Natrium.Value.ToString();
                _proteinText.text = ScanResultData.Instance.Product.Protein.Value.ToString();
            }
            _elementText.text = ProgressData.Instance.Progress.NewNutrimon.Element;
            _finishButton.onClick.RemoveAllListeners();
            _finishButton.onClick.AddListener(OnClaim);
            gameObject.SetActive(true);
        }

        private void CalculateMonster()
        {
            ProgressData.Instance.SetNewNutrimon();
        }

        private void CheckProductRating()
        {
            float productRating = ScanResultData.Instance.Product.Rating;
            int index = 0;
            while (index < Mathf.FloorToInt(productRating))
            {
                _productRating[index].sprite = Resources.Load<Sprite>(@"Sprites/Stars/stage_character_star");
                index++;
            }
            if ((productRating % 1) != 0)
            {
                _productRating[index].sprite = Resources.Load<Sprite>(@"Sprites/Stars/stage_character_star_half");
            }
        }

        private void CheckMonsterStar()
        {
            float monsterStars = ProgressData.Instance.Progress.NewNutrimon.Star;
            int index = 0;
            while (index < Mathf.FloorToInt(monsterStars))
            {
                _monsterStars[index].sprite = Resources.Load<Sprite>(@"Sprites/Stars/stage_character_star");
                index++;
            }
            if ((monsterStars % 1) != 0)
            {
                _monsterStars[index].sprite = Resources.Load<Sprite>(@"Sprites/Stars/stage_character_star_half");
            }
        }

        private void OnClaim()
        {
            int playerScanCount = ProgressData.Instance.Progress.ScanCount;
            ProgressData.Instance.SetScanCount(++playerScanCount);
            ProgressData.Instance.AddDailyQuestProgress("QUE01");
            ProgressData.Instance.AddDailyQuestProgress("QUE03");
            SceneManager.LoadScene(GameScene.Gameplay, LoadSceneMode.Single);
        }
    }
}
