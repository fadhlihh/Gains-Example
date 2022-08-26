using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Gains.Module.SimpleQuestions;
using Gains.Module.ResultSummary;

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

        private int _page = 0;

        private void Awake()
        {
            ShowPage(0);    
        }

        private void ShowPage(int page){
            _questionText.text = SimpleQuestionData.Instance.SimpleQuestionList.SimpleQuestions[page].Question;
            _optionLeftText.text = SimpleQuestionData.Instance.SimpleQuestionList.SimpleQuestions[page].Option1;
            _optionRightText.text = SimpleQuestionData.Instance.SimpleQuestionList.SimpleQuestions[page].Option2;
            _optionLeftButton.onClick.RemoveAllListeners();
            _optionRightButton.onClick.RemoveAllListeners();
            _optionLeftButton.onClick.AddListener(OnAnswerLeft);
            _optionRightButton.onClick.AddListener(OnAnswerRight);
        }

        private void OnAnswerLeft(){
            Debug.Log("click");
            switch(_page){
                case 0:
                    _page +=2;
                    break;
                case 1:
                    _page += 2;
                    break;
                case 3:
                    _page = 0;
                    int playerScanCount = PlayerPrefs.GetInt("PlayerScanCount");
                    if(playerScanCount == 1){
                        ShowResultReview();
                    }else{
                        ShowComplexDataEntry();
                    }
                    break;
                default:
                    _page++;
                    break;
            }
            ShowPage(_page);
        }
        
        private void OnAnswerRight(){
            Debug.Log("click");
            switch(_page){
                case 1:
                    _page += 2;
                    break;
                case 3:
                    int playerScanCount = PlayerPrefs.GetInt("PlayerScanCount");
                    if(playerScanCount == 1){
                        ShowResultReview();
                    }else{
                        ShowComplexDataEntry();
                    }
                    break;
                default:
                    _page++;
                    break;
            }
            ShowPage(_page);
        }

        private void ShowComplexDataEntry(){
            gameObject.SetActive(false);
            _resultSummary.Show();
        }

        private void ShowResultReview(){
            gameObject.SetActive(false);
            _mandatoryDataEntryPopUp.Show();
        }
    }
}
