using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Gains.Module.SimpleQuestions;
using Gains.Module.ResultSummary;
using Gains.Module.ProgressionData;
using System.Collections.Generic;

namespace Gains.Module.DataEntry
{
    public class SimpleDataEntry : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _questionText;
        [SerializeField]
        private TextMeshProUGUI _optionLeftText;
        [SerializeField]
        private TextMeshProUGUI _optionRightText;
        [SerializeField]
        private Button _optionLeftButton;
        [SerializeField]
        private Button _optionRightButton;
        [SerializeField]
        private MandatoryDataEntry _mandatoryDataEntryPopUp;
        [SerializeField]
        private SimpleResultSummary _resultSummary;
        [SerializeField]
        private List<Image> _pageIndicator = new List<Image>();

        private int _questionIndex = 0;
        private int _page = 0;

        private void Awake()
        {
            ShowPage(0);
        }

        private void ShowPage(int page)
        {
            _pageIndicator[_page++].color = new Color32(120, 164, 214, 255);
            _questionText.text = SimpleQuestionData.Instance.SimpleQuestionList.SimpleQuestions[page].Question;
            _optionLeftText.text = SimpleQuestionData.Instance.SimpleQuestionList.SimpleQuestions[page].Option1;
            _optionRightText.text = SimpleQuestionData.Instance.SimpleQuestionList.SimpleQuestions[page].Option2;
            _optionLeftButton.onClick.RemoveAllListeners();
            _optionRightButton.onClick.RemoveAllListeners();
            _optionLeftButton.onClick.AddListener(OnAnswerLeft);
            _optionRightButton.onClick.AddListener(OnAnswerRight);
        }

        private void OnAnswerLeft()
        {
            switch (_questionIndex)
            {
                case 0:
                    _questionIndex += 2;
                    break;
                case 1:
                    _questionIndex += 2;
                    break;
                case 3:
                    _questionIndex = 0;
                    _page = 0;
                    int playerScanCount = ProgressData.Instance.Progress.ScanCount;
                    if (playerScanCount == 0)
                    {
                        ShowResultSummary();
                    }
                    else
                    {
                        ShowComplexDataEntry();
                    }
                    break;
                default:
                    _questionIndex++;
                    break;
            }
            ShowPage(_questionIndex);
        }

        private void OnAnswerRight()
        {
            switch (_questionIndex)
            {
                case 1:
                    _questionIndex += 2;
                    break;
                case 3:
                    _questionIndex = 0;
                    _page = 0;
                    int playerScanCount = PlayerPrefs.GetInt("PlayerScanCount");
                    if (playerScanCount == 1)
                    {
                        ShowResultSummary();
                    }
                    else
                    {
                        ShowComplexDataEntry();
                    }
                    break;
                default:
                    _questionIndex++;
                    break;
            }
            ShowPage(_questionIndex);
        }

        private void ShowResultSummary()
        {
            gameObject.SetActive(false);
            _resultSummary.Show();
        }

        private void ShowComplexDataEntry()
        {
            gameObject.SetActive(false);
            _mandatoryDataEntryPopUp.Show();
        }
    }
}
