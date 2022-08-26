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
            CheckProduct(result);
        }

        private void Start()
        {
            _qrCodeDecoder.StartWork();
        }

        private void CheckProduct(string barcode)
        {
            if (ScanResultData.Instance.TryGetProduct(barcode, out Product product))
            {
                Debug.Log(product.Name);
                int playerScanCount = PlayerPrefs.GetInt("PlayerScanCount");
                PlayerPrefs.SetInt("PlayerScanCount", ++playerScanCount);
                SceneManager.LoadScene(GameScene.DataEntry, LoadSceneMode.Single);
            }
            else
            {
                Debug.Log("False");
                _qrCodeDecoder.Reset();
                _qrCodeDecoder.StartWork();
            }
        }
    }
}