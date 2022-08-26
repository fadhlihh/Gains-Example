using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gains.Utility;

namespace Gains.Module.NutrimonData
{
    public class NutrimonData : SingletonBehaviour<NutrimonData>
    {
        private NutrimonList _nutrimonList;
        public NutrimonList NutrimonList => _nutrimonList;
        public void Awake()
        {
            TextAsset dataSource = Resources.Load<TextAsset>(@"Data/Nutrimons");
            _nutrimonList = JsonUtility.FromJson<NutrimonList>(dataSource.text);
            Debug.Log(_nutrimonList.Nutrimons.Count);
        }
    }
}
