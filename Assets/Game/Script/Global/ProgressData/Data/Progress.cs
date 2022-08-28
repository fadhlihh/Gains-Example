using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gains.Module.NutrimonsData;
using Gains.Module.DailyQuestData;
using Gains.Module.AchievementData;

namespace Gains.Module.ProgressionData
{
    [System.Serializable]
    public class Progress
    {
        public string PlayerID;
        public int Coin;
        public int Energy;
        public int Balance;
        public int ScanCount;
        public List<Nutrimon> Nutrimons = new List<Nutrimon>();
        public Nutrimon SelectedNutrimon;
        public Nutrimon NewNutrimon;
        public List<DailyQuest> DailyQuests = new List<DailyQuest>();
        public List<Achievement> Achievements = new List<Achievement>();
    }
}
