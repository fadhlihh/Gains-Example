using UnityEngine;
using UnityEngine.SceneManagement;
using Gains.Utility;

namespace Gains.Module.Home
{
    public class HomeController : MonoBehaviour
    {
        void Awake()
        {
            SceneManager.LoadSceneAsync(GameScene.Navigation, LoadSceneMode.Additive);
        }
    }
}