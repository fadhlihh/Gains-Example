using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using Gains.Utility;

namespace Gains.Module.Main
{
    public class MainController : MonoBehaviour
    {
        [SerializeField]
        private GameObject _globalData;
        private void Awake()
        {
            Application.targetFrameRate = 60;
            CreateEventSystem();
            InitGlobalData();
            LaunchInitScene();
        }

        private void CreateEventSystem()
        {
            GameObject eventSystem = new GameObject("Event System");
            eventSystem.AddComponent<EventSystem>();
            eventSystem.AddComponent<StandaloneInputModule>();
            DontDestroyOnLoad(eventSystem);
        }

        private void InitGlobalData()
        {
            GameObject globalData = Instantiate<GameObject>(_globalData);
            DontDestroyOnLoad(globalData);
        }

        private void LaunchInitScene()
        {
            SceneManager.LoadScene(GameScene.StartUp, LoadSceneMode.Single);
        }
    }
}
