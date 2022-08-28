using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Gains.Utility;
using Gains.Module.Quest;
using Gains.Module.WIP;

namespace Gains.Module.Home
{
    public class HomePanel : MonoBehaviour
    {
        [SerializeField]
        private Button _scanButton;
        [SerializeField]
        private Button _questButton;
        [SerializeField]
        private Button _inviteButton;
        [SerializeField]
        private Button _newsButton;
        [SerializeField]
        private QuestPopUp _questPopUp;
        [SerializeField]
        private WorkInProgress _workInProgressPanel;

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        private void Awake()
        {
            _scanButton?.onClick.RemoveAllListeners();
            _scanButton?.onClick.AddListener(OnScan);
            _questButton?.onClick.RemoveAllListeners();
            _questButton?.onClick.AddListener(OnQuest);
            _inviteButton?.onClick.RemoveAllListeners();
            _inviteButton?.onClick.AddListener(OnInvite);
            _newsButton?.onClick.RemoveAllListeners();
            _newsButton?.onClick.AddListener(OnNews);
        }

        private void OnScan()
        {
            SceneManager.LoadScene(GameScene.Scan, LoadSceneMode.Single);
        }

        private void OnQuest()
        {
            _questPopUp.Show();
        }

        private void OnInvite()
        {
            _workInProgressPanel.Show();
        }

        private void OnNews()
        {
            _workInProgressPanel.Show();
        }
    }
}
