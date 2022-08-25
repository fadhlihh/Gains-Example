using UnityEngine;

namespace Gains.Module.Scan
{
    public class ScanData : ScriptableObject
    {
        public string Result {get; private set;}
        
        public void SetResult(string result){
            Result = result;
        }
    }
}
