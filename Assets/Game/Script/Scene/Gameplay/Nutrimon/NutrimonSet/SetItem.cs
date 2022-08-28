using UnityEngine;
using UnityEngine.UI;

namespace Gains.Module.NutrimonSet
{
    public class SetItem : MonoBehaviour
    {
        [SerializeField]
        private Button _detailButton;
        [SerializeField]
        private SetDetail _detailPopUp;

        public void Init()
        {
            _detailButton?.onClick.RemoveAllListeners();
            _detailButton?.onClick.AddListener(OnClickDetail);
        }

        private void Awake()
        {
            Init();
        }

        private void OnClickDetail()
        {
            _detailPopUp.Show();
        }
    }
}
