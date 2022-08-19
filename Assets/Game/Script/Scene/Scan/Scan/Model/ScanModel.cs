using UnityEngine;

namespace Gains.Module.Scan
{
    public class ScanModel
    {
        public string Result { get; private set; }

        public void SetResult(string result)
        {
            Debug.Log("Model");
            Result = result;
        }
    }
}
