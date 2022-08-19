using UnityEngine;
using UnityEngine.SceneManagement;
using Gains.Utility;

namespace Gains.Module.MainMenu
{
    public class MainMenuController : MonoBehaviour
    {
        void Awake()
        {
            SceneManager.LoadSceneAsync(GameScene.Navigation, LoadSceneMode.Additive);
        }
    }
}
