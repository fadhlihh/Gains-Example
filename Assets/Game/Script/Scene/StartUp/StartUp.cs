using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Gains.Utility;

namespace Gains.Module.StartUp
{
    public class StartUp : MonoBehaviour
    {
        [SerializeField] 
        private Button _startButton;
        [SerializeField] 
        private Button _continueButton;
        [SerializeField] 
        private Canvas _titleContainer;
        [SerializeField] 
        private Canvas _welcomeContainer;

        public void SetCallbacks(UnityAction loadScan)
        {
            _startButton.onClick.RemoveAllListeners();
            _startButton.onClick.AddListener(ShowWelcomeView);
            _continueButton.onClick.RemoveAllListeners();
            _continueButton.onClick.AddListener(loadScan);
        }

        private void ShowWelcomeView()
        {
            _titleContainer.enabled = false;
            _welcomeContainer.enabled = true;
        }

        void LoadScan()
        {
            SceneManager.LoadScene(GameScene.Scan, LoadSceneMode.Single);
        }
    }
}
