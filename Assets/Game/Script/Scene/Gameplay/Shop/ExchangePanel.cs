using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gains.Module.ExchangeData;
using Gains.Module.ProgressionData;

namespace Gains.Module.Exchanges
{
    public class ExchangePanel : MonoBehaviour
    {
        [SerializeField]
        private Transform _exchangeListContainer;
        [SerializeField]
        private ExchangeItem _exchangeItemPrefab;

        private List<ExchangeItem> _exchangeList = new List<ExchangeItem>();

        public void Show()
        {
            GenerateExchangeList();
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        private void Awake(){
            Show();
        }

        private void GenerateExchangeList()
        {
            ClearList();
            int counter = 0;
            Debug.Log(ProgressData.Instance.Progress.Exchanges.Count);
            foreach (Exchange item in ProgressData.Instance.Progress.Exchanges)
            {
                ExchangeItem exchangeItem = Instantiate<ExchangeItem>(_exchangeItemPrefab, _exchangeListContainer);
                exchangeItem.Init(item.ID,item.Name,item.Cost,item.Balance,item.Quota, item.ClaimCount);
                _exchangeList.Add(exchangeItem);
                counter++;
            }
        }

        private void ClearList()
        {
            if (_exchangeList.Count > 0)
            {
                foreach (ExchangeItem item in _exchangeList)
                {
                    Destroy(item.gameObject);
                }
                _exchangeList.Clear();
            }
        }
    }
}
