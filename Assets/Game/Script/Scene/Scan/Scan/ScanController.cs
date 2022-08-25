using UnityEngine;
using UnityEngine.SceneManagement;
using Gains.Utility;

namespace Gains.Module.Scan
{
    public class ScanController : MonoBehaviour
    {
        [SerializeField]
        private QRCodeDecodeController _qrCodeDecoder;
        private void Start()
        {
            _qrCodeDecoder.StartWork();
        }

        public void OnScanProduct(string result)
        {
            _qrCodeDecoder.StopWork();
            Debug.Log(result);
            // SceneManager.LoadScene(GameScene.ScanResult, LoadSceneMode.Single);
        }
    }
}
