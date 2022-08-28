using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Gains.Module.ComplexQuestions;
using Gains.Module.EntryResult;
using Gains.Module.EntryResultReview;
using Gains.Module.Confirmation;

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
        private Button _skipButton;
        [SerializeField]
        private EntryReview _entryReviewPopUp;
        [SerializeField]
        private ConfirmationPopUp _confirmationPopUp;
        [SerializeField]
        private List<Image> _pageIndicator = new List<Image>();

        private int _questionIndex = 0;

        public void Show()
        {
            ShowPage(0);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void ShowResultReview()
        {
            Hide();
            Debug.Log(DataEntryResult.Instance.Results.Count);
            _entryReviewPopUp.Show();
        }

        private void ShowPage(int page)
        {
            _pageIndicator[page].color = new Color32(120, 164, 214, 255);
            _questionText.text = ComplexQuestionData.Instance.ComplexQuestionList.ComplexQuestions[page].Question;
            _answerInput.text = "";
            _continueButton.onClick.RemoveAllListeners();
            _continueButton.onClick.AddListener(OnContinue);
            _skipButton.onClick.RemoveAllListeners();
            _skipButton.onClick.AddListener(OnSkip);
            gameObject.SetActive(true);
        }

        private void OnContinue()
        {
            DataEntryResult.Instance.Results.Add(_answerInput.text);
            if (_questionIndex < ComplexQuestionData.Instance.ComplexQuestionList.ComplexQuestions.Count - 1)
            {
                _questionIndex++;
                ShowPage(_questionIndex);
            }
            else
            {
                _questionIndex = 0;
                ShowResultReview();
            }
        }

        private void OnSkip()
        {
            _confirmationPopUp.Show();
        }
    }
}

