using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Gains.Module.DailyQuests;
using Gains.Module.Achievements;

namespace Gains.Module.Quest
{
    public class QuestPopUp : MonoBehaviour
    {
        [SerializeField]
        private Toggle _dailyQuestToggle;
        [SerializeField]
        private Toggle _achievementToggle;
        [SerializeField]
        private DailyQuestPanel _dailyQuestPanel;
        [SerializeField]
        private AchivementPanel _achievementPanel;
        [SerializeField]
        private TextMeshProUGUI _dailyQuestText;
        [SerializeField]
        private TextMeshProUGUI _achievementText;
        [SerializeField]
        private Button _closeButton;

        public void Show()
        {
            _dailyQuestToggle?.onValueChanged.RemoveAllListeners();
            _dailyQuestToggle?.onValueChanged.AddListener(OnDailyQuest);
            _achievementToggle?.onValueChanged.RemoveAllListeners();
            _achievementToggle?.onValueChanged.AddListener(OnAchievement);
            _closeButton?.onClick.RemoveAllListeners();
            _closeButton?.onClick.AddListener(OnClose);
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        private void OnDailyQuest(bool value)
        {
            if (value)
            {
                _dailyQuestText.color = new Color32(255, 255, 255, 255);
                _dailyQuestPanel.Show();
            }
            else
            {
                _dailyQuestText.color = new Color32(74, 172, 247, 255);
                _dailyQuestPanel.Hide();
            }
        }

        private void OnAchievement(bool value)
        {
            if (value)
            {
                _achievementText.color = new Color32(255, 255, 255, 255);
                _achievementPanel.Show();
            }
            else
            {
                _achievementText.color = new Color32(74, 172, 247, 255);
                _achievementPanel.Hide();
            }
        }

        private void OnClose()
        {
            Hide();
        }
    }
}
