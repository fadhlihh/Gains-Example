using UnityEngine;
using Gains.Utility;

namespace Gains.Module.ComplexQuestions
{
    public class ComplexQuestionData : SingletonBehaviour<ComplexQuestionData>
    {
        private ComplexQuestionList _complexQuestionList;
        public ComplexQuestionList ComplexQuestionList => _complexQuestionList;

        private void Awake()
        {
            LoadData();
        }

        private void LoadData()
        {
            TextAsset dataSource = Resources.Load<TextAsset>(@"Data/ComplexQuestions");
            _complexQuestionList = JsonUtility.FromJson<ComplexQuestionList>(dataSource.text);
        }
    }
}
