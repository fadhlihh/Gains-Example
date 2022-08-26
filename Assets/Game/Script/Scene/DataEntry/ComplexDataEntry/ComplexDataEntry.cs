using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Gains.Module.ComplexQuestions;
using Gains.Module.EntryResult;
using Gains.Module.EntryResultReview;

namespace Gains.Module.DataEntry
{
    public class ComplexDataEntry : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _questionText;
        [SerializeField]
        private TMP_InputField _answerInput;
        [SerializeField]
        private Button _continueButton;
        [SerializeField]
        private EntryReview _entryReviewPopUp;

        private int _page = 0;

        public void Show(){
            ShowPage(0);
        }

        private void ShowPage(int page){
            _questionText.text = ComplexQuestionData.Instance.ComplexQuestionList.ComplexQuestions[page].Question;
            _answerInput.text = "";
            _continueButton.onClick.RemoveAllListeners();
            _continueButton.onClick.AddListener(OnContinue);
            gameObject.SetActive(true);
        }

        private void OnContinue(){
            DataEntryResult.Instance.Results.Add(_answerInput.text);
            if(_page < ComplexQuestionData.Instance.ComplexQuestionList.ComplexQuestions.Count-1){
                _page++;
                ShowPage(_page);
            }else{
                _page = 0;
                ShowResultReview();
            }
        }

        public void ShowResultReview(){
            gameObject.SetActive(false);
            Debug.Log( DataEntryResult.Instance.Results.Count);
            _entryReviewPopUp.Show();
        } 
    }
}

