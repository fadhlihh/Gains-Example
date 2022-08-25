using UnityEngine;
using UnityEngine.SceneManagement;
using Gains.Module.ScanData;
using Gains.Module.ProductData;
using Gains.Utility;

namespace Gains.Module.Scan
{
    public class Scan : MonoBehaviour
    {
        [SerializeField]
        private QRCodeDecodeController _qrCodeDecoder;

        public void OnScanProduct(string result)
        {
            _qrCodeDecoder.StopWork();
            // ScanResultData.Instance.SetResult(result);
            if (ScanResultData.Instance.TryGetProduct(result, out Product product))
            {
                Debug.Log(product.Name);
            }
            else
            {
                Debug.Log("False");
            }
            // SceneManager.LoadScene(GameScene.DataEntry, LoadSceneMode.Single);
        }

        private void Start()
        {
            _qrCodeDecoder.StartWork();
        }

        private void CheckProduct(string barcode)
        {

        }
    }
}