using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

namespace Gains.Module.Scan
{
    public class ScanView : MonoBehaviour
    {
        [SerializeField]
        private Button _scanButton;
        [SerializeField]
        private TextMeshProUGUI _scanStatusText;


        public void SetCallbacks(UnityAction onClickScan)
        {
            _scanButton.onClick.RemoveAllListeners();
            _scanButton.onClick.AddListener(onClickScan);
        }

        public void UpdateScanStatusText(string result)
        {
            if (string.IsNullOrEmpty(result))
            {
                _scanStatusText.text = "Scan gagal, coba lagi!";
            }
            else
            {
                _scanStatusText.text = "Scan berhasil";
            }
        }
    }
}
