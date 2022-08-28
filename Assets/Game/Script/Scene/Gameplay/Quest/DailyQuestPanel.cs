using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gains.Module.ProgressionData;
using Gains.Module.DailyQuestData;

namespace Gains.Module.DailyQuests
{
    public class DailyQuestPanel : MonoBehaviour
    {
        [SerializeField]
        private Transform _dailyQuestListContainer;
        [SerializeField]
        private DailyQuestItem _dailyQuestItemPrefab;

        private List<DailyQuestItem> _dailyQuestList = new List<DailyQuestItem>();

        public void Show()
        {
            GenerateDailyQuestList();
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        private void Awake()
        {
            Show();
        }

        private void GenerateDailyQuestList()
        {
            ClearList();
            foreach (DailyQuest item in ProgressData.Instance.Progress.DailyQuests)
            {
                if (item.IsClaimed == 0)
                {
                    DailyQuestItem dailyQuestItem = Instantiate<DailyQuestItem>(_dailyQuestItemPrefab, _dailyQuestListContainer);
                    bool isClaimable = item.Progress >= item.RequiredProgress;
                    dailyQuestItem.Init(item.ID, item.Title, item.Description, item.Reward, item.Progress, item.RequiredProgress, isClaimable);
                    _dailyQuestList.Add(dailyQuestItem);
                }
            }
        }

        private void ClearList()
        {
            if (_dailyQuestList.Count > 0)
            {
                foreach (DailyQuestItem item in _dailyQuestList)
                {
                    Destroy(item.gameObject);
                }
                _dailyQuestList.Clear();
            }
        }
    }
}
