using UnityEngine;
using Gains.Utility;
using System.Collections.Generic;

namespace Gains.Module.SimpleQuestions
{
    public class SimpleQuestionData : SingletonBehaviour<SimpleQuestionData>
    {
        private SimpleQuestionList _simpleQuestionList;
        public SimpleQuestionList SimpleQuestionList => _simpleQuestionList;
        public void Awake()
        {
            TextAsset dataSource = Resources.Load<TextAsset>(@"Data/SimpleQuestions");
            _simpleQuestionList = JsonUtility.FromJson<SimpleQuestionList>(dataSource.text);
            Debug.Log(_simpleQuestionList.SimpleQuestions.Count);
        }
    }
}
