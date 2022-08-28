using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Gains.Utility;
using Gains.Module.SignUp;
using Gains.Module.ProgressionData;

namespace Gains.Module.Login
{
    public class LoginPopUp : MonoBehaviour
    {
        [SerializeField]
        private TMP_InputField _emailInput;
        [SerializeField]
        private TMP_InputField _passwordInput;
        [SerializeField]
        private Toggle _rememberMeToggle;
        [SerializeField]
        private Button _loginButton;
        [SerializeField]
        private Button _signUpButton;
        [SerializeField]
        private SignUpPopUp _signUpPopUp;

        public void Show()
        {
            _loginButton?.onClick.RemoveAllListeners();
            _signUpButton?.onClick.RemoveAllListeners();
            _loginButton?.onClick.AddListener(OnLogin);
            _signUpButton?.onClick.AddListener(OnShowSignUp);
            gameObject.SetActive(true);
        }

        private void Awake()
        {
            Show();
        }

        private void OnShowSignUp()
        {
            gameObject.SetActive(false);
            _emailInput.text = "";
            _passwordInput.text = "";
            _signUpPopUp.Show();
        }

        private void OnLogin()
        {
            AuthenticatePlayer();
        }

        private void AuthenticatePlayer()
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
