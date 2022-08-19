using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainController : MonoBehaviour
{
    [SerializeField]
    private Button _playButton;
    void Awake()
    {
        GameObject eventSystem = new GameObject("Event System");
        eventSystem.AddComponent<EventSystem>();
        eventSystem.AddComponent<StandaloneInputModule>();
        DontDestroyOnLoad(eventSystem);
    }

    // Update is called once per frame
    void Update()
    {
        _playButton.onClick.RemoveAllListeners();
        _playButton.onClick.AddListener(ChangeScene);
    }

    void ChangeScene()
    {
        SceneManager.LoadScene("Intro", LoadSceneMode.Additive);
    }
}
