using UnityEngine;

namespace Gains.Module.ExchangeData
{
    [System.Serializable]
    public class Exchange
    {
        public string ID;
        public string Name;
        public int Cost;
        public int Balance;
        public int Quota;
        public int ClaimCount;
    }
}
