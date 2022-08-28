using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Gains.Utility;
using Gains.Module.Login;
using Gains.Module.ProgressionData;

namespace Gains.Module.SignUp
{
    public class SignUpPopUp : MonoBehaviour
    {
        [SerializeField]
        private TMP_InputField _emailInput;
        [SerializeField]
        private TMP_InputField _passwordInput;
        [SerializeField]
        private Button _signUpButton;
        [SerializeField]
        private Button _loginButton;
        [SerializeField]
        private LoginPopUp _loginPopUp;

        public void Show()
        {
            gameObject.SetActive(true);
            _loginButton.onClick.RemoveAllListeners();
            _signUpButton.onClick.RemoveAllListeners();
            _signUpButton.onClick.AddListener(OnSignUp);
            _loginButton.onClick.AddListener(OnShowLogin);
        }

        private void OnShowLogin()
        {
            gameObject.SetActive(false);
            _emailInput.text = "";
            _passwordInput.text = "";
            _loginPopUp.Show();
        }

        private void OnSignUp()
        {
            RegisterPlayer();
        }

        private void RegisterPlayer()
        {
            if (ProgressData.Instance.Progress.ScanCount == 1)
            {
                ProgressData.Instance.AddAchievementProgress("ACH01");
            }
            ProgressData.Instance.AddDailyQuestProgress("QUE01");
            SceneManager.LoadScene(GameScene.Gameplay, LoadSceneMode.Single);
        }
    }
}
