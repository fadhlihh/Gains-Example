using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Gains.Module.ProgressionData;

namespace Gains.Module.Exchanges
{
    public class ExchangeItem : MonoBehaviour
    {
        [SerializeField]
        private Button _exchangeButton;
        [SerializeField]
        private Slider _exchangeSlider;
        [SerializeField]
        private Image _exchangeIcon;
        [SerializeField]
        private TextMeshProUGUI _costText;
        [SerializeField]
        private TextMeshProUGUI _balanceText;
        [SerializeField]
        private TextMeshProUGUI _exchangeLimitText;
        [SerializeField]
        private Transform _limitContainer;
        [SerializeField]
        private Transform _unaffordableContainer;

        private string _id;
        private int _cost;
        private int _claimCount;

        public void Init(string id, string name, int cost, int balance, int quota, int claimCount)
        {
            _id = id;
            _cost = cost;
            _claimCount = claimCount;
            _exchangeIcon.sprite = Resources.Load<Sprite>($"Sprites/Icons/{name}");
            _costText.text = cost.ToString();
            _balanceText.text = cost.ToString();
            _exchangeSlider.maxValue = quota;
            _exchangeSlider.value = quota - claimCount;
            _exchangeLimitText.text = $"{_exchangeSlider.value.ToString()}/{_exchangeSlider.maxValue.ToString()}";
            if(claimCount > 0){
                _limitContainer.gameObject.SetActive(true);
            }
            _exchangeButton.onClick.RemoveAllListeners();
            _exchangeButton.onClick.AddListener(OnExchange);
        }

        private void Update(){
            if((_cost > ProgressData.Instance.Progress.Coin) && (_claimCount <= 0)){
                _unaffordableContainer.gameObject.SetActive(true);
            }else{
                _unaffordableContainer.gameObject.SetActive(false);
            }
        }

        private void OnExchange()
        {
            ProgressData.Instance.ClaimExchange(_id);
            _claimCount++;
            _exchangeSlider.value--;
            _exchangeLimitText.text = $"{_exchangeSlider.value.ToString()}/{_exchangeSlider.maxValue.ToString()}";
            _limitContainer.gameObject.SetActive(true);
        }
    }
}
