using UnityEngine;
using UnityEngine.UI;
using Gains.Module.WIP;

namespace Gains.Module.NutrimonSet
{
    public class SetItem : MonoBehaviour
    {
        [SerializeField]
        private Button _detailButton;
        [SerializeField]
        private Button _claimButton;
        [SerializeField]
        private SetDetail _detailPopUp;
        [SerializeField]
        WorkInProgress _workInPorgressPopUp;

        public void Init()
        {
            _detailButton?.onClick.RemoveAllListeners();
            _detailButton?.onClick.AddListener(OnClickDetail);
            _claimButton?.onClick.RemoveAllListeners();
            _claimButton?.onClick.AddListener(OnClaim);
        }

        private void Awake()
        {
            Init();
        }

        private void OnClickDetail()
        {
            _detailPopUp.Show();
        }

        private void OnClaim(){
            _workInPorgressPopUp.Show();
        }
    }
}
