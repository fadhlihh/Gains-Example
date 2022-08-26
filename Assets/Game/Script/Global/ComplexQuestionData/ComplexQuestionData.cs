using UnityEngine;
using Gains.Utility;

namespace Gains.Module.ComplexQuestions
{
    public class ComplexQuestionData : SingletonBehaviour<ComplexQuestionData>
    {
        private ComplexQuestionList _complexQuestionList;
        public ComplexQuestionList ComplexQuestionList => _complexQuestionList;

        public void Awake()
        {
            TextAsset dataSource = Resources.Load<TextAsset>(@"Data/ComplexQuestions");
            _complexQuestionList = JsonUtility.FromJson<ComplexQuestionList>(dataSource.text);
            Debug.Log(_complexQuestionList.ComplexQuestions.Count);
        }
    }
}
