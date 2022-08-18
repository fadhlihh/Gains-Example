using UnityEngine;
using UnityEngine.SceneManagement;
using Gains.Utility;

namespace Gains.Module.Scan
{
    public class ScanController : MonoBehaviour
    {
        public QRCodeDecodeController _qrCodeDecoder;
        private void Start()
        {
            _qrCodeDecoder.StartWork();
        }
        public void OnScanProduct(string result)
        {
            SceneManager.LoadScene(GameScene.ScanResult, LoadSceneMode.Single);
        }
    }
}
