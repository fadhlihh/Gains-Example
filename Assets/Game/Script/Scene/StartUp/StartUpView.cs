using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace Gains.Module.StartUp
{
    public class StartUpView : MonoBehaviour
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
            Debug.Log("Halo");
            _titleContainer.enabled = false;
            _welcomeContainer.enabled = true;
        }
    }
}
