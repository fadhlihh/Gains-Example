using UnityEngine;
using UnityEngine.SceneManagement;
using Gains.Module.ScanData;
using Gains.Utility;

namespace Gains.Module.Scan
{
    public class Scan : MonoBehaviour
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
            ScanResultData.Instance.SetResult(result);
            SceneManager.LoadScene(GameScene.DataEntry, LoadSceneMode.Single);
        }
    }
}