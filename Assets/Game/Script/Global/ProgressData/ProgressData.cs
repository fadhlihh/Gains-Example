using System.IO;
using UnityEngine;
using Gains.Utility;
using Gains.Module.NutrimonsData;
using Gains.Module.ScanData;
using Gains.Module.DailyQuestData;
using Gains.Module.AchievementData;
using Gains.Module.ExchangeData;

namespace Gains.Module.ProgressionData
{
    public class ProgressData : SingletonBehaviour<ProgressData>
    {
        private Progress _progress;
        public Progress Progress => _progress;

        public void SetScanCount(int scanCount)
        {
            _progress.ScanCount = scanCount;
            Save();
        }

        public void AddDailyQuestProgress(string id)
        {
            if (TryGetDailyQuestIndex(id, out int index))
            {
                _progress.DailyQuests[index].Progress++;
                Save();
            }
        }

        public void ClaimDailyQuest(string id)
        {
            if (TryGetDailyQuestIndex(id, out int index))
            {
                Debug.Log("Index" + index);
                _progress.DailyQuests[index].IsClaimed = 1;
                Save();
            }
        }

        public void AddAchievementProgress(string id)
        {
            if (TryGetAchievementIndex(id, out int index))
            {
                _progress.Achievements[index].Progress++;
                Save();
            }
        }

        public void ClaimAchievement(string id)
        {
            if (TryGetAchievementIndex(id, out int index))
            {
                _progress.Achievements[index].IsClaimed = 1;
                Save();
            }
        }

        public void ClaimExchange(string id){
            if (TryGetExchangeIndex(id, out int index))
            {
                _progress.Exchanges[index].ClaimCount++;
                _progress.Coin -= _progress.Exchanges[index].Cost;
                Save();
            }
        }

        public void SetNewNutrimon()
        {
            float productRating = ScanResultData.Instance.Product.Rating;
            Nutrimon newNutrimon = NutrimonData.Instance.NutrimonList.Nutrimons.Find(item => item.Star == productRating);
            bool isNutrimonExists = _progress.Nutrimons.Exists(item => string.Equals(item.ID, newNutrimon.ID));
            if (!isNutrimonExists)
            {
                AddDailyQuestProgress("QUE02");
            }
            _progress.NewNutrimon = newNutrimon;
            _progress.Nutrimons.Add(newNutrimon);
            _progress.SelectedNutrimon = _progress.Nutrimons[0];
            Save();
        }

        public void ResetNewNutrimon()
        {
            _progress.NewNutrimon = null;
            Save();
        }

        public void AddBalance(int value)
        {
            _progress.Balance += value;
            Save();
        }

        public void AddCoin(int value)
        {
            _progress.Coin += value;
            Save();
        }

        public void AddEnergy(int value)
        {
            _progress.Energy += value;
        }

        private void Awake()
        {
            Load();
        }

        private void Load()
        {
            string directory = Path.Combine(Application.persistentDataPath, "Save");
            string path = Path.Combine(directory, "Progress.json");
            if (File.Exists(path))
            {
                string progressFile = File.ReadAllText(path);
                Progress progress = JsonUtility.FromJson<Progress>(progressFile);
                _progress = progress;
            }
            else
            {
                Directory.CreateDirectory(directory);
                InitProgress();
            }
        }

        private void InitProgress()
        {
            TextAsset initProgressFile = Resources.Load<TextAsset>(@"Data/Progression");
            Progress progress = JsonUtility.FromJson<Progress>(initProgressFile.text);
            _progress = progress;
            Save();
        }

        private void Save()
        {
            string path = $"{Application.persistentDataPath}/Save/Progress.json";
            string progressData = JsonUtility.ToJson(_progress);
            File.WriteAllText(path, progressData);
        }

        private bool TryGetDailyQuestIndex(string id, out int index)
        {
            index = -1;
            DailyQuest quest = _progress.DailyQuests.Find(item => string.Equals(item.ID, id));
            if (quest != null)
            {
                index = _progress.DailyQuests.IndexOf(quest);
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool TryGetAchievementIndex(string id, out int index)
        {
            index = -1;
            Achievement achievement = _progress.Achievements.Find(item => string.Equals(item.ID, id));
            if (achievement != null)
            {
                index = _progress.Achievements.IndexOf(achievement);
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool TryGetExchangeIndex(string id, out int index)
        {
            index = -1;
            Exchange exchange = _progress.Exchanges.Find(item => string.Equals(item.ID, id));
            if (exchange != null)
            {
                index = _progress.Exchanges.IndexOf(exchange);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
