using UnityEngine;
using Gains.Utility;
using System.Collections.Generic;

namespace Gains.Module.SimpleQuestions
{
    public class SimpleQuestionData : SingletonBehaviour<SimpleQuestionData>
    {
        private SimpleQuestionList _simpleQuestionList;
        public SimpleQuestionList SimpleQuestionList => _simpleQuestionList;
        private void Awake()
        {
            LoadData();
        }

        private void LoadData()
        {
            TextAsset dataSource = Resources.Load<TextAsset>(@"Data/SimpleQuestions");
            _simpleQuestionList = JsonUtility.FromJson<SimpleQuestionList>(dataSource.text);
        }
    }
}
