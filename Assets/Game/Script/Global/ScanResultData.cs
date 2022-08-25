using UnityEngine;
using Gains.Utility;

namespace Gains.Module.ScanData
{
    public class ScanResultData : SingletonBehaviour<ScanResultData>
    {
        public string Result {get; private set;}
        
        public void SetResult(string result){
            Result = result;
        }
    }
}
