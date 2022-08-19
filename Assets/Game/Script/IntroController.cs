using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroController : MonoBehaviour
{
    [SerializeField]
    private Button _continueButton, _backButton;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _continueButton.onClick.RemoveAllListeners();
        _continueButton.onClick.AddListener(ChangeScene);
        _backButton.onClick.RemoveAllListeners();
        _backButton.onClick.AddListener(BackScene);
    }

    void ChangeScene()
    {
        SceneManager.LoadScene("Scan", LoadSceneMode.Single);
    }

    void BackScene()
    {
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }
}
