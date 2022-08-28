using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gains.Module.DailyQuestData
{
    [System.Serializable]
    public class DailyQuest
    {
        public string ID;
        public string Title;
        public int RequiredProgress;
        public int Progress;
        public string Description;
        public int Reward;
        public int IsClaimed;
    }
}
