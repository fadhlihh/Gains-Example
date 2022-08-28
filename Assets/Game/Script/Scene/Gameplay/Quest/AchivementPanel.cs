using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gains.Module.AchievementData;
using Gains.Module.ProgressionData;

namespace Gains.Module.Achievements
{
    public class AchivementPanel : MonoBehaviour
    {
        [SerializeField]
        private Transform _achievementListContainer;
        [SerializeField]
        private AchievementItem _achievementItemPrefab;

        private List<AchievementItem> _achievementList = new List<AchievementItem>();

        public void Show()
        {
            GenerateAchievementList();
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        private void GenerateAchievementList()
        {
            ClearList();
            foreach (Achievement item in ProgressData.Instance.Progress.Achievements)
            {
                if (item.IsClaimed == 0)
                {
                    AchievementItem achievementItem = Instantiate<AchievementItem>(_achievementItemPrefab, _achievementListContainer);
                    bool isClaimable = item.Progress >= item.RequiredProgress;
                    achievementItem.Init(item.ID, item.Title, item.Description, item.Reward, item.Progress, item.RequiredProgress, isClaimable);
                    _achievementList.Add(achievementItem);
                }
            }
        }

        private void ClearList()
        {
            if (_achievementList.Count > 0)
            {
                foreach (AchievementItem item in _achievementList)
                {
                    Destroy(item.gameObject);
                }
                _achievementList.Clear();
            }
        }
    }
}
