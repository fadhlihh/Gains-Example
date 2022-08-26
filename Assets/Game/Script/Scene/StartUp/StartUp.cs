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
        private GameObject _titleContainer;
        [SerializeField] 
        private GameObject _welcomeContainer;

        public void Awake()
        {
            _startButton.onClick.RemoveAllListeners();
            _startButton.onClick.AddListener(ShowWelcomeView);
            _continueButton.onClick.RemoveAllListeners();
            _continueButton.onClick.AddListener(LoadScan);
        }

        private void ShowWelcomeView()
        {
            // _titleContainer.enabled = false;
            // _welcomeContainer.enabled = true;
            _titleContainer.SetActive(false);
            _welcomeContainer.SetActive(true);
        }

        void LoadScan()
        {
            SceneManager.LoadScene(GameScene.Scan, LoadSceneMode.Single);
        }
    }
}
