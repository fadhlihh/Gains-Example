using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Gains.Utility;

namespace Gains.Module.StartUp
{
public class StartUpController : MonoBehaviour
    {
        [SerializeField]
        private StartUpView _view;
        void Awake()
        {
            _view.SetCallbacks(LoadScan);
        }
        
        void LoadScan()
        {
            SceneManager.LoadScene(GameScene.Scan, LoadSceneMode.Single);
        }


    }
}
