using UnityEngine;
using Gains.Module.ProgressionData;
using Gains.Module.ResultSummary;

namespace Gains.Module.DataEntry
{
    public class DataEntryPopUp : MonoBehaviour
    {
        [SerializeField]
        private GameObject _simpleDataEntryPopUp;
        [SerializeField]
        private ComplexResultSummary _complexResultPopUp;

        private void Awake()
        {
            CheckScanCount();
        }

        private void CheckScanCount()
        {
            int playerScanCount = ProgressData.Instance.Progress.ScanCount;
            if ((playerScanCount == 0 || ((playerScanCount + 1) % 2 == 0)))
            {
                _simpleDataEntryPopUp.SetActive(true);
            }
            else
            {
                _complexResultPopUp.Show(false);
            }
        }
    }
}
