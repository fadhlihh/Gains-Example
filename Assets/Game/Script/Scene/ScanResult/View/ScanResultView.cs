using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace Gains.Module.ScanResult
{
    public class ScanResultView : MonoBehaviour
    {
        [SerializeField]
        private Button _continueButton;

        public void SetCallbacks(UnityAction onClickContinue)
        {
            _continueButton.onClick.RemoveAllListeners();
            _continueButton.onClick.AddListener(onClickContinue);
        }
    }
}
