using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

using Gains.Utility;

namespace Gains.Module.ResultSummary
{
    public class SimpleResultSummary : MonoBehaviour
    {
        public TextMeshProUGUI _elementText;
        public Button _claimButton;

        public void Show(){
            _claimButton.onClick.RemoveAllListeners();
            _claimButton.onClick.AddListener(OnClaim);
            CheckMonster();
            gameObject.SetActive(true);
        }

        public void OnClaim(){
            SceneManager.LoadScene(GameScene.Gameplay,LoadSceneMode.Single);
        }

        public void CheckMonster(){
            
        }
    }
}
