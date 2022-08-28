using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gains.Utility;

namespace Gains.Module.NutrimonsData
{
    public class NutrimonData : SingletonBehaviour<NutrimonData>
    {
        private NutrimonList _nutrimonList;
        public NutrimonList NutrimonList => _nutrimonList;
        private void Awake()
        {
            LoadData();
        }

        private void LoadData()
        {
            TextAsset dataSource = Resources.Load<TextAsset>(@"Data/Nutrimons");
            _nutrimonList = JsonUtility.FromJson<NutrimonList>(dataSource.text);
        }
    }
}
