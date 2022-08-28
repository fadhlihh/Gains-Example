using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Gains.Module.ScanData;
using Gains.Module.NutrimonsData;
using Gains.Module.ProgressionData;
using Gains.Utility;

namespace Gains.Module.ResultSummary
{
    public class SimpleResultSummary : MonoBehaviour
    {
        public TextMeshProUGUI _elementText;
        public Button _claimButton;

        public void Show()
        {
            CalculateMonster();
            _claimButton.onClick.RemoveAllListeners();
            _claimButton.onClick.AddListener(OnClaim);
            _elementText.text = ProgressData.Instance.Progress.NewNutrimon.Element;
            gameObject.SetActive(true);
        }

        public void OnClaim()
        {
            int playerScanCount = ProgressData.Instance.Progress.ScanCount;
            ProgressData.Instance.SetScanCount(++playerScanCount);
            if (playerScanCount <= 1)
            {
                SceneManager.LoadScene(GameScene.Login, LoadSceneMode.Single);
            }
            else
            {
                ProgressData.Instance.AddDailyQuestProgress("QUE01");
                SceneManager.LoadScene(GameScene.Gameplay, LoadSceneMode.Single);
            }
        }

        private void CalculateMonster()
        {
            ProgressData.Instance.SetNewNutrimon();
        }
    }
}
