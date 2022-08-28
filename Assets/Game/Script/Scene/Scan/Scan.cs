using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Gains.Module.ScanData;
using Gains.Module.ProductData;
using Gains.Module.ProgressionData;
using Gains.Utility;

namespace Gains.Module.Scan
{
    public class Scan : MonoBehaviour
    {
        [SerializeField]
        private QRCodeDecodeController _qrCodeDecoder;
        [SerializeField]
        private GameObject _popUpContainer;
        [SerializeField]
        private GameObject _scanSuccessPopUp;
        [SerializeField]
        private GameObject _scanFailedPopUp;
        [SerializeField]
        private Button _continueButton;
        [SerializeField]
        private Button _backButton;

        public void OnScanProduct(string result)
        {
            _qrCodeDecoder.StopWork();
            CheckProduct(result);
        }

        private void Start()
        {
            _qrCodeDecoder.StartWork();
            _continueButton?.onClick.RemoveAllListeners();
            _backButton?.onClick.RemoveAllListeners();
            _continueButton?.onClick.AddListener(OnContinue);
            _backButton?.onClick.AddListener(OnBack);
        }

        private void CheckProduct(string barcode)
        {
            if (ScanResultData.Instance.TryGetProduct(barcode, out Product product))
            {
                _popUpContainer.SetActive(true);
                _scanSuccessPopUp.SetActive(true);
            }
            else
            {
                _popUpContainer.SetActive(true);
                _scanFailedPopUp.SetActive(true);
            }
        }

        private void OnContinue()
        {
            SceneManager.LoadScene(GameScene.DataEntry, LoadSceneMode.Single);
        }

        private void OnBack()
        {
            _qrCodeDecoder.Reset();
            _qrCodeDecoder.StartWork();
            _popUpContainer.SetActive(false);
            _scanFailedPopUp.SetActive(false);
        }
    }
}