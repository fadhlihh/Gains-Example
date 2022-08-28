using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gains.Module.NutrimonsData
{
    [System.Serializable]
    public class Nutrimon
    {
        public string ID;
        public string Name;
        public float Star;
        public string Type;
        public string Faction;
        public string Element;
        public string Description;
        public int Level;
        public int MaxLevel;
        public string Evolution1;
        public string Evolution2;
    }
}
