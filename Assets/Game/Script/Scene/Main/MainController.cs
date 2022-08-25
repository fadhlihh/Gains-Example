using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Gains.Boot;

namespace Gains
{
    public class MainController : MonoBehaviour
{
    void Awake()
    {
        GameObject eventSystem = new GameObject("Event System");
        eventSystem.AddComponent<EventSystem>();
        eventSystem.AddComponent<StandaloneInputModule>();
        DontDestroyOnLoad(eventSystem);

        GameObject globalDataObject =new GameObject("GlobalData");
        globalDataObject.AddComponent<GlobalData>();
        DontDestroyOnLoad(globalDataObject);

        SceneManager.LoadScene("StartUp", LoadSceneMode.Single);
    }
}

}

