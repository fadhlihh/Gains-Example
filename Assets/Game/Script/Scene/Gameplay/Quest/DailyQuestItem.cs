using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Gains.Module.ProgressionData;

namespace Gains.Module.DailyQuests
{
    public class DailyQuestItem : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _titleText;
        [SerializeField]
        private TextMeshProUGUI _descriptionText;
        [SerializeField]
        private TextMeshProUGUI _progressText;
        [SerializeField]
        private TextMeshProUGUI _rewardText;
        [SerializeField]
        private Slider _progressSlider;
        [SerializeField]
        private Button _claimButton;

        private string _id;
        private int _reward;

        public void Init(string id, string name, string description, int reward, int progress, int requiredProgress, bool isClaimable)
        {
            _id = id;
            _reward = reward;
            _progressSlider.gameObject.SetActive(!isClaimable);
            _progressText.gameObject.SetActive(!isClaimable);
            _claimButton.gameObject.SetActive(isClaimable);
            if (isClaimable)
            {
                GetComponent<Image>().color = new Color32(23, 145, 253, 255);
            }
            else
            {
                GetComponent<Image>().color = new Color32(4, 94, 157, 255);
            }
            _titleText.text = name;
            _descriptionText.text = description;
            _rewardText.text = reward.ToString();
            _progressText.text = $"{progress.ToString()}/{requiredProgress.ToString()}";
            _progressSlider.maxValue = requiredProgress;
            _progressSlider.value = progress;
            _claimButton.onClick.RemoveAllListeners();
            _claimButton.onClick.AddListener(OnClaim);
        }

        public void OnClaim()
        {
            Debug.Log(_id);
            ProgressData.Instance.ClaimDailyQuest(_id);
            ProgressData.Instance.AddCoin(_reward);
            gameObject.SetActive(false);
        }
    }
}
