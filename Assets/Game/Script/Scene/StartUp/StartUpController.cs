using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartUpController : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _continueButton;
    [SerializeField] private GameObject _startUpView;
    [SerializeField] private GameObject _WelcomeView;

    // Update is called once per frame
    void Update()
    {
        _startButton.onClick.RemoveAllListeners();
        _startButton.onClick.AddListener(WelcomeView);
        _continueButton.onClick.RemoveAllListeners();
        _continueButton.onClick.AddListener(ChangeScene);
    }

    void WelcomeView()
    {
        _startUpView.SetActive(false);
        _WelcomeView.SetActive(true);
    }
    void ChangeScene()
    {
        SceneManager.LoadScene("Scan", LoadSceneMode.Single);
    }
}
