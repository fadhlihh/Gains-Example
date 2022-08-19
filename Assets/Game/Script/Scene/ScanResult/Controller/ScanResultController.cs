using UnityEngine;
using UnityEngine.SceneManagement;
using Gains.Utility;

namespace Gains.Module.ScanResult
{
    public class ScanResultController : MonoBehaviour
    {
        [SerializeField]
        private ScanResultView _view;

        private void Awake()
        {
            _view.SetCallbacks(OnClickContinue);
        }

        private void OnClickContinue()
        {
            SceneManager.LoadScene(GameScene.MainMenu, LoadSceneMode.Single);
        }
    }
}
